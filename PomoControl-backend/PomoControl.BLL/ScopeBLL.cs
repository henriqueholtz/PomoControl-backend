﻿using PomoControl.BLL.Generics;
using PomoControl.BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace PomoControl.BLL
{
    public class ScopeBLL : IBaseBLL
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
