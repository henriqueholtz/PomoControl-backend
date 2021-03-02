using PomoControl.Service.Generics;
using System.Collections.Generic;

namespace PomoControl.Service.Interfaces
{
    interface IBaseService
    {
        GenericResult Insert<T>(T entity) where T : class;
        GenericResult Update<T>(T entity) where T : class;
        GenericResult Delete<T>(T entity) where T : class;

        List<T> GetAll<T>(T entity) where T : class;
        T GetByCode<T>(int code) where T : class;
    }
}
