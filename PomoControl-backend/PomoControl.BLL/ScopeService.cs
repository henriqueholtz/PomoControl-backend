using PomoControl.Service.Generics;
using PomoControl.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace PomoControl.Service
{
    public class ScopeService : IBaseService
    {
        public GenericResult Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetByCode<T>(int code) where T : class
        {
            throw new NotImplementedException();
        }

        public GenericResult Insert<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public GenericResult Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
