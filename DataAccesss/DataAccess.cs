using DataAccess.Repositories;
using DataAccess.DBEntities;
using System.Collections.Generic;

namespace DataAccess
{
    public class DataAccess
    {
        private NLog.Logger logger;

        public static object Helper { get; internal set; }

        public DataAccess(NLog.Logger logger)
        {
            this.logger = logger;
        }

        //public IList<TestingInput> GetListOfTestingInput()
        //{
        //    Repositories.DataAccessRepo<TestingInput> rep = new Repositories.DataAccessRepo<TestingInput>(logger);
        //    return rep.GetAll();
        //}
        //public IList<CampaignPool> GetCampaignPools()
        //{
        //    Repositories.DataAccessRepo<CampaignPool> get = new DataAccessRepo<CampaignPool>(logger);
        //    return get.GetAll();
        //}
    }
}
