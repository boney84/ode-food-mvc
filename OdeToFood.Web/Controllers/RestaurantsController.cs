using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private IRestaurantData _db;

        public RestaurantsController(IRestaurantData db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
           return View(_db.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant model)
        {
            if (model.Cuisine == CuisineType.None)
            {
                ModelState.AddModelError("Cuisine", "Invalid cuisine type");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Get(id);
            if (model == null) 
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant model)
        {
            if (model.Cuisine == CuisineType.None)
            {
                ModelState.AddModelError("Cuisine", "Invalid cuisine type");
            }
            if (ModelState.IsValid && _db.Update(model))
            {
                return RedirectToAction("Details",new {Id= model.Id });
            }
          
            return View();
        }
    }
}