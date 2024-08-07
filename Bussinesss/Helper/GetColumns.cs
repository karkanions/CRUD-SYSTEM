using Bussiness.Mapping;
using Bussiness.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Helper
{
    public class GetColumns
    {
        private AutomapperSettings mapper = new AutomapperSettings();
        private NLog.Logger logger;
        public GetColumns(NLog.Logger logger)
        {
            this.logger = logger;
        }
        public void GetColumnParams() 
        {
            

        }
    }
}
