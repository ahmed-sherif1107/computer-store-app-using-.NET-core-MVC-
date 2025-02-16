using System.Linq.Expressions;

namespace lab01ASPWebApp.Repo.Base
{
    public interface IRepo<T> where T : class  // the type must be interface
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);//synchrinization method - i write Task<type> before method name

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>>  GetAllAsync();//synchrinization method
        Task<IEnumerable<T>> GetAllAsync(params string[] includes);

        T GetOne(Expression<Func<T,bool>> expression); // it helps me to search on anything (name , id , phone .....) just by passing it as an expression


    
        // to help pass multiple paramiters in one call , i create this class (this is used to help include a db table in another / or to be seen by it) 
        IEnumerable<T> GetAll(params string[] includes );// ("Category", "Items","Employee",......)

        void AddSingle (T item);
        void UpdateSingle (T item);
        void DeleteSingle (T item);
        void AddList (IEnumerable<T> list);
        void UpdateList (IEnumerable<T> list);
        void DeleteList (IEnumerable<T> list);
    }
}
