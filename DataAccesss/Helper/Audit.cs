using System;
using System.Collections.Generic;
using System.Linq;
using static DataAccess.Helper.Enums;

namespace DataAccess.DBEntities
{
    public  class Audit
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string UserName { get; set; }
        public List<Tuple<object, string>> OriginalValues { get; set; }
        public List<Tuple<object, string>> NewValues { get; set; }
        public List<Tuple<string, object, object>> Differences()
        {
            if (ID == 0)
            {
                return FindDifferences(NewValues, OriginalValues);
            }
            else
            { 
                return FindDifferences(OriginalValues, NewValues);
            }
        }

        public List<Tuple<string, object, object>> FindDifferences(List<Tuple<object, string>> values1, List<Tuple<object, string>> values2)
        {
            List<Tuple<string, object, object>> diff = new List<Tuple<string, object, object>>();
            var Before = values1.Except(values2).ToList();

            foreach (var i in Before)
            {
                Tuple<string, object, object> d = Tuple.Create
                (
                    i.Item2,
                    i.Item1,
                    values2.Where(x => x.Item2 == i.Item2).Select(y => y.Item1).FirstOrDefault()
                );
                diff.Add(d);
            }
            return diff;
        }
        public DateTime? ModifiedDate { get; set; }
        public ModificationType ModificationType { get; set; }
        public string TableName { get; set; }
        public int ReferenceID { get; set; }
        public Audit()
        {
            this.UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.ModifiedDate = DateTime.Now;
        }
        public Audit(List<Tuple<object, string>> OriginalValues, List<Tuple<object, string>> NewValues, ModificationType ModificationType, string TableName, int ReferenceID)
        {
            this.UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.ModifiedDate = DateTime.Now;
            this.OriginalValues = OriginalValues;
            this.NewValues = NewValues;
            this.ModificationType = ModificationType;
            this.TableName = TableName;
            this.ReferenceID = ReferenceID;
        }

       
    }
}


