using Microsoft.AspNetCore.Mvc;
using quezemasterNew.BussinesLogic;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.ViewModel;

namespace quezemasterNew.ViewComponents
{
    public class Class9DetailsViewComponent : ViewComponent
    {
        Class9Helper _Class9Helper = new Class9Helper();
        public async Task<IViewComponentResult> InvokeAsync(string ViewComponentType, Class9ViewModel Class9EnglishDetails)
        {
            try
            {
                switch (ViewComponentType)
                {
                    case "BPSCEnglishForm":
                        return View("_BPSCEnglishForm", Class9EnglishDetails);

                    case "BPSCEnglishList":
                        List<Class9ViewModel> LsClass9QuezDetails = new List<Class9ViewModel>();

                        LsClass9QuezDetails = await _Class9Helper.FillClass9QuizDetailsBySubjectName(LsClass9QuezDetails: LsClass9QuezDetails, Subject: Subject);

                        return View("_BPSCEnglishListDetails", LsClass9QuezDetails);
                }
            }
            catch (Exception ex)
            {

            }

            // Optional fallback
            return Content("Invalid ViewComponentType supplied.");
        }
    }
}
