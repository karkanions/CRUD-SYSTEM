using Bussiness.Mapping;
using Bussiness.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
   
   
    public class ParametersInputs
    {
        private AutomapperSettings mapper = new AutomapperSettings();
        private NLog.Logger logger;
        public ParametersInputs(NLog.Logger logger)
        {
            this.logger = logger;
        }
        public IList<TablesDto> GetListOfTablesInputs()
        {
            var bb = new DataAccess.ParametersInputs(logger);
            IList<DataAccess.DBEntities.Tables> dbT = bb.GetListOfTablesInputs(Environment.UserName);
            var tables = mapper.mapper.Map<List<Parameters.TablesDto>>(dbT);
            //var tables = mapper.mapper.Map<List<Parameters.TablesDto>>(bb.GetListOfTablesInputs(Environment.UserName));
            var cc = new DataAccess.ParametersInputs(logger);
            foreach (var t in tables)
            {
                t.TableColumns = mapper.mapper.Map<List<Parameters.ColumnsDto>>(cc.ColumnsInputs(t.ID));
            }
            return tables.OrderBy(x => x.OrderID).ToList();
        }
        public IList<ColumnsDto> GetListOfColumnsInputs()
        {
            var cc = new DataAccess.ParametersInputs(logger);
            IList<DataAccess.DBEntities.Columns> c = cc.ColumnsInputs(2);
            var TableColumns = mapper.mapper.Map<List<Parameters.ColumnsDto>>(c);
            return TableColumns;
        }
        //public int PagginationParameters()
        //{
        //    var s = new DataAccess.ParametersInputs(logger);
        //    var tables = mapper.mapper.Map<List<Parameters.TablesDto>>(s.GetCountOfTableInputs());
        //    foreach (var t in tables)
        //    {

        //        t.PageSize = 10;


        //    }

        //    return Convert.ToInt32(tables);


        //}
        //public IList<ColumnsDto> ColumnsInput()
        //{
        //    var cc = new DataAccess.ParametersInputs(logger);
        //    return mapper.mapper.Map<List<Parameters.ColumnsDto>>(cc.ColumnsInputs());


        //}
    }
}
