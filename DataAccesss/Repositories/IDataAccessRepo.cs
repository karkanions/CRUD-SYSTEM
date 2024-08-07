using DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IDataAccessRepo<T> where T : class
    {
        ////initialize
        //void IGenericDataRepository(NLog.Logger log);
        ////initialize

        //Gets
        IList<T> GetData(PaginatedStatus paginigStatusparams, FilterItems filter);
        IList<T> GetAllPagenated(PaginatedStatus paginigStatus);
        IList<T> GetListPagenated(Func<T, bool> where, PaginatedStatus paginigStatusparams, Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetListFromSQL(string sSQL);
        List<string> Changes(params T[] items);
        List<string> ChangesFromList(List<T> items);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetById(Object[] keyValues);

        //CRUD
        void Insert(params T[] items);
        //void DeleteIfExistsAndInsert(params T[] items);
        void Update(params T[] items);
        void Delete(params T[] items);

        //CRUD
        Task InsertAsync(params T[] items);
        //Task DeleteIfExistsAndInsertAsync(params T[] items);
        Task UpdateAsync(params T[] items);
        Task DeleteAsync(params T[] items);

        //Table
        //void InitializeTable();
        //IEnumerable<T> GetAll();
        //T GetById(object id);
        //void Insert(T obj);
        //void Update(T obj);
        //void Delete(object id);
        //void Save();
        int GetCount();
        int GetCountFromSQL(string sSQL);

    }
}

