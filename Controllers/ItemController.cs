using lab01ASPWebApp.ContextDB;
using lab01ASPWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab01ASPWebApp.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {


        private readonly AppDBContext dbContext;// dependancy injection 


        public ItemController(AppDBContext dp)
        {
            dbContext = dp;
        }



        public IActionResult Index()
        {
            IEnumerable<Items> ItemList = dbContext.items.Include(x => x.Category).ToList();// to add and store my items on the page to a list with type 'IEnumerable<Items>'
                                                                                            // here the items will also include the items in the categories table
            return View(ItemList);
        }



        public void SelectItemList(int? id=1) // if the user doesnt choose a category the dafaylt will be 0
        {
            //List<Category> categories = new List<Category>()
            //{
            // new Category { Id =1 ,Name="select"}
            // , new Category { Id =2 ,Name="mobile"}
            // , new Category { Id =3 ,Name="computer"}
            // , new Category { Id =4 ,Name="tablet"}

            //}; // creating the category list
            List<Category> categories = dbContext.categories.ToList();
            SelectList list =new SelectList(categories , "Id", "Name", id); //represents a list that lets its users select a single item (from html<select>) with the specified collection odf the SelectItemList objects
            ViewBag.CategoryList = list;
        }


        //GET
        public IActionResult Create()
        {
            SelectItemList();
            return View();
        }



        //POST -- sets value to the database and posts it on the website 
        [HttpPost] // used to post the solution on the site
        public IActionResult Create(Items item)
        {


            //if (item.Name.ToLower() == "ahmed") //to create a custom error , tolower() is used to make al the latters entered in lower case , to avoid tricks :)
            if (item.Name == "ahmed")  // but it causes errors so we will avoid it :(
            {
                ModelState.AddModelError("custom error", "name cannot be ahmed !!!");  // creating the custom error
            }



            if (!ModelState.IsValid)
            {
                return View(item);  //if the user enters a non-valid input , the page will reload with the same data and no actions will be done
            }



            dbContext.items.Add(item);   // to add items to db
            dbContext.SaveChanges();     //to save changes to db
            TempData["Success"] = "Item Created Successfully";
            return RedirectToAction("Index"); // will go to the method Index in the 17th line here and pass its values to it .
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound(); // returns ERROR 404 if there is no id 
            }
            var item = dbContext.items.Find(Id); // to find the id in the list in the db 
            if (item == null)
            {
                return NotFound(); // returns ERROR 404 if there is no elements 
            }
            SelectItemList(item.CategoryId);
            return View(item);
        }



        //POST -- sets value to the database and posts it on the website 
        [HttpPost] // used to post the solution on the site
        public IActionResult Edit(Items item)
        {


            //if (item.Name.ToLower() == "ahmed") //to create a custom error , tolower() is used to make al the latters entered in lower case , to avoid tricks :)
            if (item.Name == "ahmed")  // but it causes errors so we will avoid it :(
            {
                ModelState.AddModelError("custom error", "name cannot be ahmed !!!");  // creating the custom error
            }



            if (!ModelState.IsValid)
            {
                return View(item);  //if the user enters a non-valid input , the page will reload with the same data and no actions will be done
            }



            dbContext.items.Update(item);   // to update items to db
            dbContext.SaveChanges();     //to save changes to db
            TempData["Successs"] = "Item Edited Successfully";
            return RedirectToAction("Index"); // will go to the method Index in the 17th line here and pass its values to it .
        }




        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET
        public IActionResult Delete(int? Id)
        {
            return View();  
        }



        //POST -- sets value to the database and posts it on the website 
        [HttpPost] // used to post the solution on the site
        public IActionResult Delete(Items item)
        { 
            dbContext.items.Remove(item);   // to delete items in db
            dbContext.SaveChanges();     //to save changes to db

            return RedirectToAction("Index"); // will go to the method Index in the 17th line here and pass its values to it .
        }


    }
}
