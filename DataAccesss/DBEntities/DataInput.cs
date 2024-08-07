using DataAccess.Helper;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using static DataAccess.Helper.Enums;

namespace DataAccess.DBEntities
{
    public partial class DataInput : DbContext
    {
        public DataInput()
            : base("name=DataInput")
        {
        }

        public virtual DbSet<CampaignPool> CampaignPool { get; set; }
        public virtual DbSet<Campaigns> Campaigns { get; set; }
        public virtual DbSet<CampaignType> CampaignType { get; set; }
        public virtual DbSet<CampaignWaves> CampaignWaves { get; set; }
        public virtual DbSet<AuditTable> AuditTable { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<TableGroups> TableGroups { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<TableXGroups> TableXGroups { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersXGroups> UsersXGroups { get; set; }
        public virtual DbSet<TestingInput> TestingInput { get; set; }
        public virtual DbSet<TestingInputHistory> TestingInputHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaigns>()
                .HasMany(e => e.CampaignPool)
                .WithRequired(e => e.Campaigns)
                .HasForeignKey(e => e.CampaignId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campaigns>()
                .HasMany(e => e.CampaignWaves)
                .WithOptional(e => e.Campaigns)
                .HasForeignKey(e => e.CampaignId);

            modelBuilder.Entity<CampaignType>()
                .HasMany(e => e.Campaigns)
                .WithRequired(e => e.CampaignType1)
                .HasForeignKey(e => e.CampaignType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampaignWaves>()
                .HasMany(e => e.CampaignPool)
                .WithRequired(e => e.CampaignWaves)
                .HasForeignKey(e => e.WaveId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.UsersXGroups)
                .WithRequired(e => e.Groups)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TableGroups>()
                .HasMany(e => e.TableXGroups)
                .WithRequired(e => e.TableGroups)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tables>()
                .HasMany(e => e.Columns)
                .WithRequired(e => e.Tables)
                .HasForeignKey(e => e.TableID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tables>()
                .HasMany(e => e.TableXGroups)
                .WithRequired(e => e.Tables)
                .HasForeignKey(e => e.TableID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersXGroups)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
        public override int SaveChanges()
        {
            if (ChangeTracker.Entries().FirstOrDefault().Entity.GetType() != typeof(AuditTable))
            {
                List<AuditTable> audits = new List<AuditTable>();
                List<DbEntityEntry> AuditedEntitiesToAudit = ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                foreach (var item in AuditedEntitiesToAudit)
                {
                    //item.Entity.SetLastUpdateDate(DateTime.Now);
                    //item.Entity.SetLastUpdateUser(Environment.UserName);
                    Audit a = GetAuditItem(item);
                    if (a.Differences().Count > 0)
                    {
                        audits.Add(DataBaseAuditItem(a));
                        if (a.ID != 0)
                        {
                            item.Entity.SetLastUpdateDate(DateTime.Now);
                            item.Entity.SetLastUpdateUser(Environment.UserName);
                        }
                        else 
                        {
                            item.Entity.SetLastInsertedDate(DateTime.Now);
                            item.Entity.SetLastInsertedUser(Environment.UserName);
                        }
                        

                    }
                }
                
                var repository = new Repositories.DataAccessRepo<AuditTable>(LogManager.GetCurrentClassLogger());
                repository.Insert(audits.ToArray());


            }
            return base.SaveChanges();
        }
        private static AuditTable DataBaseAuditItem(Audit audit) 
        {
            AuditTable auditTable = new AuditTable();
            auditTable.OriginalValues = JsonConvert.SerializeObject(audit.OriginalValues);
            auditTable.CurrentValues = JsonConvert.SerializeObject(audit.NewValues);

            auditTable.ChangedValues = JsonConvert.SerializeObject(audit.Differences());
           
            auditTable.ID = audit.ID;
            auditTable.ModificationDateTime = (DateTime)audit.ModifiedDate;
            auditTable.ModificationType = (byte)audit.ModificationType;
            auditTable.ReferenceID = audit.ReferenceID;
            auditTable.TableName = audit.TableName;
            auditTable.UserName = audit.UserName;
            
            return auditTable;
        }
        private static Audit GetAuditItem(DbEntityEntry item)
        {
            ModificationType modificationType = StateHelper.GetModificationTypebyEntityState(item.State);
            List<Tuple<object, string>> OriginalValues = new List<Tuple<object, string>>();
            if (item.CurrentValues.GetValue<int>("ID") != 0)
            {
                OriginalValues = (List<Tuple<object, string>>)item.GetDatabaseValues().ExportDbPropertyValues();
            }
            List<Tuple<object, string>> NewValues = (List<Tuple<object, string>>)item.CurrentValues.ExportDbPropertyValues();
            string TableName = item.Entity.GetType().Name;
            int ReferenceID = (int)item.Entity.GetValObjDy("ID");
            if (modificationType == ModificationType.Update)
            {
                //OriginalValues = "";
            }
            if (modificationType == ModificationType.Delete)
            {
                //OriginalValues = NewValues;
                //NewValues = "";
            }
            Audit a = new Audit(OriginalValues, NewValues, modificationType, TableName, ReferenceID);
            //await Task.Run(() => a.Differences(OriginalValues, NewValues));
            return a;
        }
    }
}

