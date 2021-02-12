using System.Collections.Generic;

namespace PomoControl.DAL.Interfaces
{
    interface IBaseDAL
    {
        int Insert<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        bool Delete<T>(T entity) where T : class;
        T GetByCode<T>(int code) where T : class;
        List<T> GetAll<T>() where T : class;
    }
}
