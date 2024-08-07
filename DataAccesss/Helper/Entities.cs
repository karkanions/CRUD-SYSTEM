using System.Data.Entity;

namespace DataAccess.Helper
{
    public partial class DataInput : DbContext
    {
        public override int SaveChanges()
        {
            var a = 0;
            //var addedAuditedEntities = Entities.dbContext.ChangeTracker.Entries()
            //        .Where(p => p.State == EntityState.Added)
            //        .Select(p => p.Entity);
            //var modifiedAuditedEntities = Entities.dbContext.ChangeTracker.Entries()
            //        .Where(p => p.State == EntityState.Modified)
            //        .Select(p => p.Entity);
            //var deletedAuditedEntities = Entities.dbContext.ChangeTracker.Entries()
            //        .Where(p => p.State == EntityState.Deleted)
            //        .Select(p => p.Entity);
            //var now = DateTime.Now;

            //using (var ctx = new Entities(GetConnectionString(&quot; Model & quot;)))
            //{
            //    foreach (var added in addedAuditedEntities)
            //    {
            //        if (added.GetType() == typeof(Table1))
            //        {
            //            //var i = (Table1)added;
            //            //i.DATA_INS = now;
            //            //i.USER_INS = UserName;
            //        }
            //        else if (added.GetType() == typeof(Table2))
            //        {
            //
            //        }
            //        else
            //        {
            //            foreach (var modified in modifiedAuditedEntities)
            //            {
            //                if (modified is Table1)
            //                {
            //                    //var i = (Table1)modified;
            //                    //i.DATA_MOD = now;
            //                    //i.USER_MOD = UserName;
            //                }
            //                else if (modified is Table2)
            //                {
            //
            //                }
            //                else
            //                {
            //                    try
            //                    {
            //                        {
            //                            base.SaveChanges();
            //                            return 1;
            //                        }
            //                    }
            //                    catch (Exception e)
            //                    {
            //                        //manage error here
            //                        return -1;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return a;
        }
    }
}