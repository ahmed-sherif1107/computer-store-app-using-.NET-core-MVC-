using lab01ASPWebApp.Models;
using lab01ASPWebApp.Repo.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace lab01ASPWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private IRepo<Category> _repo;



        public CategoryController(IRepo<Category> repo) 
        {
            _repo = repo;
        }



        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }




        // اللي فوق هو هو اللي تحت بس اللي تحت اسرع 
        //public async Task<IActionResult> Index() // async here , i have to write the return type between 'Task<>'
        //{
        //    var SingleCategory = _repo.GetOne(x=>x.Name == "computer"); // to search for a computer . -- whats the use of this then ?
        //    var AllCategories =  await _repo.GetAllAsync("Items"); // i have to write 'await' here 
        //    return  View(AllCategories); 
        //}





        //public IActionResult create()
        //{
        //    return View(_repo.GetAll());
        //}
        //public async Task<IActionResult>  createAsync()
        //{
        //    return View(await _repo.GetAllAsync()); // i have to write 'await' here
        //}


        //Get 
        public IActionResult Create()
        {
            return View();
        }


        //  POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category) 
        {
            if (!ModelState.IsValid ) 
            {
                return View(category);
            }
            _repo.AddSingle(category);
            return RedirectToAction("Index");
        }


        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null||id==0)
            {
                return NotFound();
            }
            var category = _repo.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //  POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _repo.UpdateSingle(category);
            return RedirectToAction("Index");
        }



        //Get
        public IActionResult Delete(int? id)
        {

            if (id == null|| id==0)
            {
                return NotFound();
            }
            var category = _repo.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //  POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
           
            _repo.DeleteSingle(category);
            return RedirectToAction("Index");
        }




    }
}
