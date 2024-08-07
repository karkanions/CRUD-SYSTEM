using Bussiness.Helper;
using Bussiness.Mapping;
using Bussiness.Parameters;
using DataAccess.Helper;
using NLog;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Bussiness.Settings
{
    public class BussinessSettings
    {
        private readonly Logger logger;
        public AutomapperSettings mapper = new AutomapperSettings();
        private readonly TablesDto tablesDto;
        public List<Object> DisplayList;

        public BussinessSettings(Logger logger, TablesDto tablesDto, int pageNumber, FilterItems filter)
        {
            this.logger = logger;
            this.tablesDto = tablesDto;
            DataAccess.Helper.PaginatedStatus.paginatedStatus.pageSize = tablesDto.PageSize ?? 10;
            FillListToDisplay(filter, pageNumber);
        }
        public BussinessSettings(Logger logger, TablesDto tablesDto, FilterItems filter,int pageNumber = -1)
        {
            this.logger = logger;
            this.tablesDto = tablesDto;
            Val(tablesDto);
            FillListToDisplay(filter, pageNumber);

        }

        public BussinessSettings(Logger logger, TablesDto tablesDto1, FilterItems pageNumber, FilterItems filter)
        {
            this.logger = logger;
        }

        public bool Val(Bussiness.Parameters.TablesDto l) 
        {
            if (l.Paggination == true)
            {
                return DataAccess.Helper.PaginatedStatus.paginatedStatus.usePagination = true;

            }
            else 
            {
                return DataAccess.Helper.PaginatedStatus.paginatedStatus.usePagination = false;
            }
        }
        public void Save()
        {
            DataAccess.Repositories.IDataAccessRepo<DataInput> r = new DataAccess.Repositories.DataAccessRepo<DataInput>(logger);
            r.Insert();
        }
        public void SetValueToListItem(int row, string colName, object newValue)
        {
            if (colName == "ID")
            {
                return;
            }
            var oldvalue = DisplayList[row].GetPropValue(colName);
            if (oldvalue?.ToString() != newValue?.ToString())
            {
                DisplayList[row].SetPropValue(colName, newValue);
            }
        }
        public void FillListToDisplay(FilterItems filter, int pageNumber)
        {
            DisplayList = GetListOfItems(tablesDto.ClassTypeDataBase, tablesDto.ClassTypeBussinessList, pageNumber, filter);
            //DisplayList = GetListOfItems(tablesDto.ClassTypeDataBase, tablesDto.ClassTypeBussinessList, pageNumber, filter);
        }
        private List<object> GetListOfItems(Type LookUpTypeDatabase, Type LookUpTypeBussiness, int pageNumber, FilterItems filter)
        {
            try
            {
                //DataAccess.Helper.PaginatedStatus.paginatedStatus.pageNumber = pageNumber - 1;
                //DataAccess.Helper.PaginatedStatus.paginatedStatus.usePagination = pageNumber==-1? false : true;
                //if (pageNumber == -1)
                //{
                //    var repository = Activator.CreateInstance(typeof(DataAccess.Repositories.DataAccessRepo<>).MakeGenericType(LookUpTypeDatabase), logger);
                //    MethodInfo method = repository.GetType().GetMethod("GetData");
                //    var lDB = method.Invoke(repository, new object[] { });
                //    var lBussiness = mapper.mapper.Map(lDB, LookUpTypeDatabase, LookUpTypeBussiness);
                //    return mapper.mapper.Map<List<Object>>(lBussiness);
                //}
                //else
                //{
                    DataAccess.Helper.PaginatedStatus.paginatedStatus.pageNumber = pageNumber - 1;
                //DataAccess.Helper.PaginatedStatus.paginatedStatus.usePagination = pageNumber==-1? false : true;
              
                    var repository = Activator.CreateInstance(typeof(DataAccess.Repositories.DataAccessRepo<>).MakeGenericType(LookUpTypeDatabase), logger);
                    MethodInfo method = repository.GetType().GetMethod("GetData");
                    var lDB = method.Invoke(repository, new object[] {
                            DataAccess.Helper.PaginatedStatus.paginatedStatus,
                            filter
                    });
                    var lBussiness = mapper.mapper.Map(lDB, LookUpTypeDatabase, LookUpTypeBussiness);
                    return mapper.mapper.Map<List<Object>>(lBussiness);
                    //}
                    /* logger.Info("c# create an instance of an type variable pass T variable" 
                    /            "Tropos na ferw lista apo antikimena kai na emfanisw ena apo afto me abstract kai reflection" 
                    /            "Reflection gia to data access repo" 
                    /            "Deftero reflection gia na dei to getall times method" 
                    /            "epistrofh tou antikimenou");
                    */
                
            }
            catch (Exception exc)
            {
                logger.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, exc);
                Console.ReadLine();
                return null;
            } 
        }
        public List<Object> GetComBoxList(ColumnsDto column,FilterItems filter)
        {
            return GetListOfItems(column.ClassTypeDataBase, column.ClassTypeBussinessList, -1, filter);

        }
        public void SaveListToDb()
        {
            try
            {
                var repository = Activator.CreateInstance(typeof(DataAccess.Repositories.DataAccessRepo<>).MakeGenericType(tablesDto.ClassTypeDataBase), logger);
                MethodInfo method = repository.GetType().GetMethod("ChangesFromList");
                var updList = mapper.mapper.Map(DisplayList, DisplayList.GetType(), tablesDto.ClassTypeDataBaseList);
                List<string> r = (List<string>)method.Invoke(repository, new object[] { updList });
                if (r.Count > 0)
                {
                    MessageBox.Show(string.Join(System.Environment.NewLine, r), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
                
            }
            catch (Exception exc)
            {
                logger.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, exc);
                Console.ReadLine();
                return; // null;
            }
        }
        public void AddRowToList()
        {
            var instance = Activator.CreateInstance(tablesDto.ClassTypeBussiness);
            DisplayList.Add(instance);
        }
        public int GetNunmberOfPages() 
        {
            DataAccess.Helper.PaginatedStatus.paginatedStatus.pageSize = tablesDto.PageSize ?? 10;
            var repository = Activator.CreateInstance(typeof(DataAccess.Repositories.DataAccessRepo<>).MakeGenericType(tablesDto.ClassTypeDataBase), logger);
            MethodInfo method = repository.GetType().GetMethod("GetCount");
            var lDB = method.Invoke(repository, new object[] { });
            DataAccess.Helper.PaginatedStatus.paginatedStatus.totalRows = Convert.ToInt32(lDB);
            return DataAccess.Helper.PaginatedStatus.paginatedStatus.GetNumberOfPages();
        }
    }
}
