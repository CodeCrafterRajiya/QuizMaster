using Microsoft.AspNetCore.Mvc;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel.Test;

namespace QuizMaster.Controllers
{
    public class Test10DetailsController : Controller
    {
        QuizeMasterNewContext _context = new QuizeMasterNewContext();


        public IActionResult Index(int id, Test10DetailsViewModel test11)
        {


            return View();
        }


        public IActionResult Result10Details()
        {


            return View();
        }
    }
}
