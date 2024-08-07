using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ParametersInputs
    {
        private NLog.Logger logger;
        public ParametersInputs(NLog.Logger logger)
        {
            this.logger = logger;
        }
        public IList<Tables> GetListOfTablesInputs(string username)
        {
            Repositories.DataAccessRepo<Tables> rep = new Repositories.DataAccessRepo<Tables>(logger);
            string SQL = string.Format(@"SELECT *
                                        FROM params.Tables
                                        WHERE id in
                                            (SELECT TableID
                                             FROM PARAMS.TableXGroups txg
                                             INNER JOIN params.TableGroups tg ON txg.GroupID = tg.ID
                                             AND tg.Enable = 1
                                             AND txg.Enable = 1
                                             WHERE txg.Groupid in
                                                 (SELECT GroupID
                                                  FROM params.UsersXGroups uxg
                                                  INNER JOIN params.Groups g ON g.ID = uxg.GroupID
                                                  AND uxg.Enable = 1
                                                  AND g.Enable = 1
                                                  WHERE uxg.UserID in
                                                      (SELECT ID
                                                       FROM params.Users u
                                                       WHERE lower(u.UserName) = lower('{0}')
                                                         AND ENABLE = 1) )
			                                             AND txg.Enable = 1 )", username);
            return rep.GetAll();
            //return rep.GetListFromSQL(SQL);
        }
        public IList<DBEntities.Columns> ColumnsInputs(int tableid)
        {
            
            Repositories.DataAccessRepo<Columns> rep = new Repositories.DataAccessRepo<DBEntities.Columns>(logger);
            return rep.GetList(x => x.TableID == tableid);

        }
        public int GetCountOfTableInputs()
        {
            Repositories.DataAccessRepo<Tables> rep = new Repositories.DataAccessRepo<Tables>(logger);
            return rep.GetCount();


        }

    }
}
