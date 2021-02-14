using PomoControl.DAL.Exceptions;
using PomoControl.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PomoControl.DAL
{
    public class ScopeItemDAL : IBaseDAL
    {
        public bool Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetByCode<T>(int code) where T : class
        {
            throw new NotImplementedException();
        }

        public int Insert<T>(T entity) where T : class
        {
            try
            {
                return 0;
            }
            catch (ExceptionDAL ex)
            {
                return 0;
            }
        }

        public bool Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
