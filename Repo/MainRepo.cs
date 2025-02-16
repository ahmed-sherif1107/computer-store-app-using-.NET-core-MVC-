using lab01ASPWebApp.ContextDB;
using lab01ASPWebApp.Models;
using lab01ASPWebApp.Repo.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lab01ASPWebApp.Repo
{
    public class MainRepo<T> : IRepo<T> where T : class
    {
        protected AppDBContext context;
        public MainRepo(AppDBContext context)
        {
            this.context = context;
        }



        public T GetById(int id)
        {
            return context.Set<T>().Find(id); // will find id in ant table in the database passed to it 
                                              // this is tha same as me typing : context.items.find(id) , context.categories.find(), ......etc
        }


        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();  //it will preview all the elements on the screen 
        }




        //-----------------------------------------------------------------------------------------------------------------------------//





        public async Task<T> GetByIdAsync(int id) //asynchronous  method , i have to write 'async' before method name
        {
            return await context.Set<T>().FindAsync(id); // i HAVE to write await before the command. and write async after the name of Find
                                                         // async is used to reduce the time taken for a program to execute.
        }






        public IEnumerable<T> GetAll(params string[] includes) // = "Categories" , "Products"
        {
            IQueryable<T> query = context.Set<T>(); // = context.items 
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include); // = context.Items.include("Categories") , context.Items.include("Products")
                }
            }
            return query.ToList(); // return everything to a list to the user 
        }




        public async Task<IEnumerable<T>> GetAllAsync() //asynchronous  method , i have to write 'async' before method name
        {
            {
                return await context.Set<T>().ToListAsync(); // i HAVE to write await before the command. and write async after the name of Tolist
            }
        }




        public async Task<IEnumerable<T>> GetAllAsync(params string[] includes)
        {
            IQueryable<T> query = context.Set<T>(); // = context.items 
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include); // = context.Items.include("Categories") , context.Items.include("Products")
                }
            }
            return await query.ToListAsync(); // return everything to a list to the user
        }







        public T GetOne(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().SingleOrDefault(expression); // returns the value searched for OR returns the defult value if not found.
        }
        
        //*********************************************************************************************************************************//
        public void AddSingle(T item)
        {
           context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void UpdateSingle(T item)
        {
            context.Set<T>().Update(item);
            context.SaveChanges();
        }

        public void DeleteSingle(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> list)
        {
            context.Set<T>().AddRange(list);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> list)
        {
            context.Set<T>().UpdateRange();
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> list)
        {
            context.Set<T>().RemoveRange(list);
            context.SaveChanges();
        }

       
    }
}
