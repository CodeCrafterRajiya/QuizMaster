using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel.Test;

namespace quezemasterNew.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult SheAllTest()
        {


            CommonFunctions common = new CommonFunctions();

            List<AllTestResultViewModel> LsList = new List<AllTestResultViewModel>();
          


            LsList = common.SeeAllResult(LsList, "","Admin");



            return View(LsList.OrderByDescending(x=>x.Date).ToList());
        }

       
    }
}
