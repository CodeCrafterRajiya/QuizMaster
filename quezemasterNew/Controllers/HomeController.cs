using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using quezemasterNew.BussinesLogic;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Data;
using System.Diagnostics;

namespace quezemasterNew.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        HomePageHelper _HomePageHelper = new HomePageHelper();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult UserIndex()
        {
            return View();
        }
        public IActionResult MyAllTestInStudent()
        {
            CommonFunctions common = new CommonFunctions();

            List<AllTestResultViewModel> LsList = new List<AllTestResultViewModel>();
            var CurrentUser = User.Identity?.Name; // Use null conditional operator to avoid null reference

            if (CurrentUser != null) // Check if CurrentUser is not null
            {
                LsList = common.SeeAllResult(LsList, CurrentUser, "Student");
            }

            return View(LsList.OrderByDescending(x => x.Date).ToList());
        }

        public async Task<IActionResult> UserDetails()
        {
            List<UsersDetails> LsAllUserDetails = new List<UsersDetails>();
            LsAllUserDetails = await _HomePageHelper.GetAllUserDetails(LsAllUserDetails: LsAllUserDetails);
     
            return View(LsAllUserDetails);
        }
         
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



		public async Task<IActionResult> EnquiryFormNew(string data)
		{
            try
            {
				EnquiryModel? model = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<EnquiryModel>(data): new EnquiryModel();

				if (model != null)
				{
					TblEnquiryFormDetail EnquiryForm = new TblEnquiryFormDetail();
					{

                        EnquiryForm.Name = model.Name;
                        EnquiryForm.MobileNo = model.Mobile;
                        EnquiryForm.EmailId = model.Email;
                        EnquiryForm.Message = model.Message;
						EnquiryForm.DateTimeStamp = DateTime.Now;

					}
                    await _HomePageHelper.SaveEnquiryDetails(EnquiryDetails: EnquiryForm);
                }
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
			

			return RedirectToAction("NewDashboard");

		}

		public IActionResult NewDashboard()
        {
            return View();
        }

        public IActionResult Enquiry()
        {
            return View();
        }



        [Authorize]
        public IActionResult GoforTestPage(string TypeTest)
        {

            ViewBag.TestDiv = TypeTest;

            return View();
        }


        public IActionResult LoginHere()
        {
            return View();
        }

        public IActionResult Registrationpage()
        {
            return View();
        }

        public IActionResult Studentdetails()
        {
            return View();
        }
        public async Task<IActionResult> EnquiryDetailsList()
        {
            List<enquiryformviewmodel> LsAllEnquirDetails = new List<enquiryformviewmodel>();
            LsAllEnquirDetails = await _HomePageHelper.GetAllEnquiryDetails(LsAllEnquirDetails);
            return View(LsAllEnquirDetails);
        }

    }

	

}
