using Bussiness.BussinesEntities;
using Bussiness.Mapping;
using Bussiness.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Bussines 
    {
        private AutomapperSettings mapper = new AutomapperSettings();
        private NLog.Logger logger;
        public Bussines(NLog.Logger logger)
        {
            this.logger = logger;
        }

        //public IList<TestingInputDto> GetListofTablesInputs()
        //{
        //    var db = new DataAccess.DataAccess(logger);
        //    return mapper.mapper.Map<List<BussinesEntities.TestingInputDto>>(db.GetListOfTestingInput());
        //}
        //public IList<CampaignPoolDto> GetCampaignPools()
        //{ 
        //    var db = new DataAccess.DataAccess(logger);
        //    return mapper.mapper.Map<List<BussinesEntities.CampaignPoolDto>>(db.GetCampaignPools());
        //}
    }
}
