using DataAccess.Helper;
using DataAccess.DBEntities;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace DataAccess.Repositories
{
    public class DataAccessRepo<T> : IDataAccessRepo<T> where T : class
    {
        internal NLog.Logger log;
        private object Property;
        public DataAccessRepo(NLog.Logger log)
        {
            this.log = log;
        }
        public virtual List<string> Changes(params T[] items)
        {//id check 
            var errors = new List<string>();
            using (var context = new DBEntities.DataInput())
            {
                foreach (T item in items)
                {
                    try
                    {
                        var value = typeof(T).GetProperty("ID").GetValue(item);
                        if (value.ToString() == "0")
                        {
                            context.Set<T>().Add(item);
                            context.Entry(item).State = EntityState.Added;
                            //context.SaveChanges();
                        }
                        else
                        {
                            context.Entry(item).State = EntityState.Modified;
                        }
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        // errors.AddRange(GetErrorDetailsToLog(ex));
                        errors.Add(ex.Message);
                        log.Error(ex);
                        //logger.WSCustomLog(LogLevel.Error, parameters, string.Format("DB: Insert : Inner Exception {0}", ex.Message?.ToString()), ex);
                        context.Entry(item).State = EntityState.Unchanged;
                    }
                }
            }

            return errors.Distinct().ToList();
        }

        public virtual List<string> ChangesFromList(List<T> s)
        {
            var i = s.ToArray();
            return Changes(i);
        }
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new DBEntities.DataInput())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }
        public Func<T, bool> GetGetter(FilterItems filter)
        {
            Property = filter.Name;
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");

            // Access the property using the specified property name
            MemberExpression propertyAccess = Expression.Property(parameter, filter.Name);

            // Create the constant expression for the target value
            ConstantExpression value = Expression.Constant(filter.Value);

            // Create the equality expression
            BinaryExpression equality = Expression.Equal(propertyAccess, value);

            // Create the lambda expression
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            // Compile and use the lambda expression
            Func<T, bool> func = lambda.Compile();

            return func;
        }
        public virtual IList<T> GetData(PaginatedStatus paginigStatusparams, FilterItems filter)
        {
            if (filter == null)
            {
                if (!paginigStatusparams.usePagination)
                {
                    return GetAll();
                }
                else
                {
                    return GetAllPagenated(paginigStatusparams);
                }
            }
            else
            {

                if (!paginigStatusparams.usePagination)
                {
                    return GetList(GetGetter(filter), null);
                }
                else
                {
                    return GetListPagenated(GetGetter(filter), paginigStatusparams, null);
                }
            }
        }
        public virtual IList<T> GetAllPagenated(PaginatedStatus paginigStatusparams)
        {
            List<T> list;
            using (var context = new DBEntities.DataInput())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                if (paginigStatusparams.usePagination && paginigStatusparams.orderByColumn == null)
                {
                    list = dbQuery
                    .AsNoTracking()
                    .OrderByColumn("ID")
                    .Skip(paginigStatusparams.pageNumber * paginigStatusparams.pageSize)
                    .Take(paginigStatusparams.pageSize)
                    .ToList<T>();
                }
                else if (paginigStatusparams.usePagination && paginigStatusparams.orderByColumn != null)
                {
                    list = dbQuery
                    .AsNoTracking()
                    .AsQueryable()
                    .OrderByColumnWithDirection(paginigStatusparams.orderByColumn, paginigStatusparams.orderByDirection)
                    .Skip(paginigStatusparams.pageNumber * paginigStatusparams.pageSize)
                    .Take(paginigStatusparams.pageSize)
                    .ToList<T>();
                }
                else if (!paginigStatusparams.usePagination && paginigStatusparams.orderByColumn != null)
                {
                    list = dbQuery
                    .AsNoTracking()
                    .OrderByColumnWithDirection(paginigStatusparams.orderByColumn, paginigStatusparams.orderByDirection)
                    .ToList<T>();
                }
                else
                {
                    list = dbQuery
                        .AsNoTracking()
                        .ToList<T>();
                }
            }
            return list;
        }
        public virtual IList<T> GetListPagenated(Func<T, bool> where,
              PaginatedStatus paginigStatusparams, Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new DBEntities.DataInput())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                if (navigationProperties != null)
                {
                    //Apply eager loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }
                if (paginigStatusparams.usePagination && paginigStatusparams.orderByColumn == null)
                {
                    list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .AsQueryable()
                    .OrderByColumn("ID")
                    .Skip(paginigStatusparams.pageNumber * paginigStatusparams.pageSize)
                    .Take(paginigStatusparams.pageSize)
                    .ToList<T>();
                }
                else if (paginigStatusparams.usePagination && paginigStatusparams.orderByColumn != null)
                {
                    list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .AsQueryable()
                    .OrderByColumnWithDirection(paginigStatusparams.orderByColumn, paginigStatusparams.orderByDirection)
                    .Skip(paginigStatusparams.pageNumber * paginigStatusparams.pageSize)
                    .Take(paginigStatusparams.pageSize)
                    .ToList<T>();
                }
                else if (!paginigStatusparams.usePagination && paginigStatusparams.orderByColumn != null)
                {
                    list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .AsQueryable()
                    .OrderByColumnWithDirection(paginigStatusparams.orderByColumn, paginigStatusparams.orderByDirection)
                    .ToList<T>();
                }
                else
                {
                    list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
                }


            }
            return list;
        }
        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new DBEntities.DataInput())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }
        public virtual IList<T> GetListFromSQL(string sSQL)
        {
            using (var context = new DBEntities.DataInput())
            {
                return context.Database.SqlQuery<T>(sSQL).ToList();
            }
        }
        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new DBEntities.DataInput())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }
        public virtual T GetById(Object[] keyValues)
        {
            using (var context = new DBEntities.DataInput())
            {
                var table = context.Set<T>();
                return table.Find(keyValues);
            }
        }
        private static List<(string Name, object Value)> GetErrorDetailsToLog(T item, Exception ex)
        {
            List<(string Name, object Value)> parameters;
            if (ex.GetType() == typeof(DbEntityValidationException))
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ((DbEntityValidationException)ex).EntityValidationErrors
                                                                        .SelectMany(x => x.ValidationErrors)
                                                                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join(" ; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat("DbEntityValidationException: ", ex.Message, " The validation errors are: ", fullErrorMessage);
                parameters = new List<(string Name, object Value)>()
                            {
                               // ("RequestData", item.GetRequestXML()),
                                ("DatabaseError", exceptionMessage)
                            };
            }
            else if (ex.GetType() == typeof(DbUnexpectedValidationException))
            {
                parameters = new List<(string Name, object Value)>()
                            {
                                //("RequestData", item.GetRequestXML()),
                                ("DatabaseError", "DbUnexpectedValidationException: " + ((DbUnexpectedValidationException)ex).Message)
                            };
            }
            else if (ex.GetType() == typeof(DbUpdateException))
            {
                var errorMessages = ((DbUpdateException)ex).Entries
                                                            .Select(x => new { x.Entity.GetType().Name, x.State })
                                                            .Select(x => $"Entity of type {x.Name} in state {x.State} could not be updated.")
                                                            .Distinct()
                                                            .ToList();

                // Join the list to a single string.
                var fullErrorMessage = string.Join(" ; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat("DbUpdateException: ", ex?.InnerException?.InnerException, " The errors are: ", fullErrorMessage);

                parameters = new List<(string Name, object Value)>()
                            {
                                //("RequestData", item.GetRequestXML()),
                                ("DatabaseError", exceptionMessage)
                            };
            }
            else
            {
                parameters = new List<(string Name, object Value)>()
                {
                    //   ("RequestData", item.GetRequestXML())
                };
            }

            return parameters;
        }
        public virtual void Insert(params T[] items)
        {
            using (var context = new DBEntities.DataInput())
            {
                foreach (T item in items)
                {
                    try
                    {
                        context.Set<T>().Add(item);
                        context.Entry(item).State = EntityState.Added;
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        List<(string Name, object Value)> parameters = GetErrorDetailsToLog(item, ex);
                        //log.WSCustomLog(LogLevel.Error, parameters, string.Format("DB: Insert : Inner Exception {0}", ex.Message?.ToString()), ex);
                        context.Entry(item).State = EntityState.Unchanged;
                    }
                }
            }
        }
        //void IGenericDataRepository<T>.DeleteIfExistsAndInsert(params T[] items)
        //{
        //    using (var context = new DataInput())
        //    {
        //        if (items.Count() > 0)
        //        {
        //            var KeyProperties = context.GetKeyNames(items[0].GetType());
        //            if (KeyProperties.Length > 0)
        //            {
        //                foreach (T item in items)
        //                {
        //                    try
        //                    {
        //                        object[] KeyValue = item.GetPropertyValues(KeyProperties);
        //                        var p = GetById(KeyValue);
        //                        if (p != null)
        //                        {
        //                            //p.GetValuesFrom(item, KeyProperty);
        //                            //context.Entry(item).State = EntityState.Modified;
        //                            context.Entry(p).State = EntityState.Deleted;
        //                        }
        //                        //else
        //                        //{
        //                        context.Set<T>().Add(item);
        //                        context.Entry(item).State = EntityState.Added;
        //                        //}
        //                        context.SaveChanges();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        List<(string Name, object Value)> parameters = GetErrorDetailsToLog(item, ex);
        //                        //log.WSCustomLog(NLog.LogLevel.Error, parameters, string.Format("DB: DeleteIfExistsAndInsert : {0}", ex.Message?.ToString()), ex);
        //                        context.Entry(item).State = EntityState.Unchanged;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        void IDataAccessRepo<T>.Delete(params T[] items)
        {
            int iErrors = 0;
            using (var context = new DBEntities.DataInput())
            {
                foreach (T item in items)
                {
                    try
                    {
                        context.Entry(item).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Delete : "), ex);
                        context.Entry(item).State = EntityState.Unchanged;
                        iErrors++;
                    }
                }
            }
            if (iErrors > 0)
            {
                //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Delete : {1} Rows of {0} has Error.", items.Count(), iErrors));
            }
            else
            {
                //log.WSCustomLog(LogLevel.Info, null, string.Format("DB: Delete : {0} Rows.", items.Count()));
            }
        }
        void IDataAccessRepo<T>.Update(params T[] items)
        {
            int iErrors = 0;
            using (var context = new DBEntities.DataInput())
            {
                foreach (T item in items)
                {
                    try
                    {
                        context.Entry(item).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Update : "), ex);
                        context.Entry(item).State = EntityState.Unchanged;
                        iErrors++;
                    }
                }
            }
            if (iErrors > 0)
            {
                //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Update : {1} Rows of {0} has Error.", items.Count(), iErrors));
            }
            else
            {
                //log.WSCustomLog(LogLevel.Info, null, string.Format("DB: Update : {0} Rows.", items.Count()));
            }
        }
        async Task IDataAccessRepo<T>.InsertAsync(params T[] items)
        {
            using (var context = new DBEntities.DataInput())
            {
                foreach (T item in items)
                {
                    try
                    {
                        context.Set<T>().Add(item);
                        context.Entry(item).State = EntityState.Added;
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        List<(string Name, object Value)> parameters = GetErrorDetailsToLog(item, ex);
                        // log.WSCustomLog(LogLevel.Error, parameters, string.Format("DB: Insert : Inner Exception {0}", ex.Message?.ToString()), ex);
                        context.Entry(item).State = EntityState.Unchanged;
                    }
                }
            }
        }
        //async Task IGenericDataRepository<T>.DeleteIfExistsAndInsertAsync(params T[] items)
        //{
        //    using (var context = new DataInput())
        //    {
        //        if (items.Count() > 0)
        //        {
        //            var KeyProperties = context.GetKeyNames(items[0].GetType());
        //            if (KeyProperties.Length > 0)
        //            {
        //                foreach (T item in items)
        //                {
        //                    try
        //                    {
        //                        object[] KeyValue = item.GetPropertyValues(KeyProperties);
        //                        var p = GetById(KeyValue);
        //                        if (p != null)
        //                        {
        //                            //p.GetValuesFrom(item, KeyProperty);
        //                            //context.Entry(item).State = EntityState.Modified;
        //                            context.Entry(p).State = EntityState.Deleted;
        //                        }
        //                        //else
        //                        //{
        //                        context.Set<T>().Add(item);
        //                        context.Entry(item).State = EntityState.Added;
        //                        //}
        //                        await context.SaveChangesAsync();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        List<(string Name, object Value)> parameters = GetErrorDetailsToLog(item, ex);
        //                        //.WSCustomLog(NLog.LogLevel.Error, parameters, string.Format("DB: DeleteIfExistsAndInsert : Inner Exception {0}", ex.Message?.ToString()), ex);
        //                        context.Entry(item).State = EntityState.Unchanged;
        //                    }
        //                }

        //            }
        //        }
        //    }
        //}
        async Task IDataAccessRepo<T>.DeleteAsync(params T[] items)
        {
            int iErrors = 0;
            using (var context = new DBEntities.DataInput())
            {
                foreach (T item in items)
                {
                    try
                    {
                        context.Entry(item).State = EntityState.Deleted;
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Delete : "), ex);
                        context.Entry(item).State = EntityState.Unchanged;
                        iErrors++;
                    }
                }
            }
            if (iErrors > 0)
            {
                //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Delete : {1} Rows of {0} has Error.", items.Count(), iErrors));
            }
            else
            {
                //log.WSCustomLog(LogLevel.Info, null, string.Format("DB: Delete : {0} Rows.", items.Count()));
            }
        }
        async Task IDataAccessRepo<T>.UpdateAsync(params T[] items)
        {
            int iErrors = 0;
            using (var context = new DBEntities.DataInput())
            {
                foreach (T item in items)
                {
                    try
                    {
                        context.Entry(item).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Update : "), ex);
                        context.Entry(item).State = EntityState.Unchanged;
                        iErrors++;
                    }
                }
            }
            if (iErrors > 0)
            {
                //log.WSCustomLog(LogLevel.Error, null, string.Format("DB: Update : {1} Rows of {0} has Error.", items.Count(), iErrors));
            }
            else
            {
                //log.WSCustomLog(LogLevel.Info, null, string.Format("DB: Update : {0} Rows.", items.Count()));
            }
        }
        //public void InitializeTable()
        //{
        //    using (var context = new DataInput())
        //    {
        //        var TableName = context.GetTableName<T>();
        //        string cmd = $"Delete from { TableName }";
        //        context.ExecuteSQL(cmd);
        //    }
        //}
        public int GetCount()
        {
            using (var context = new DBEntities.DataInput())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading


                return dbQuery
                    .AsNoTracking()
                    .Count();
            }
        }
        public int GetCountFromSQL(string sSQL)
        {
            using (var context = new DBEntities.DataInput())
            {
                return context
                    .Database
                    .SqlQuery<T>(sSQL)
                    .ToList()
                    .Count();
            }
        }
    }
}