using Microsoft.AspNetCore.Mvc;
using quezemasterNew.BussinesLogic;
using quezemasterNew.Models;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.ViewModel;

namespace quezemasterNew.ViewComponents
{
    public class LTEnglishViewComponent : ViewComponent
    {
        TGTPGTLTEnglishHelper _TGTPGTHelper = new TGTPGTLTEnglishHelper();
        public async Task<IViewComponentResult> InvokeAsync(string ViewComponentType, TGTPGTLTViewModel LTEnglishDetails)
        {
            try
            {
                switch (ViewComponentType)
                {
                    case "LTEnglishForm":
                        return View("_LTEnglishForm", LTEnglishDetails);

                    case "LTEnglishList":

                        List<TGTPGTLTViewModel> LsLTQuizDetails = new List<TGTPGTLTViewModel>();
                        LsLTQuizDetails = await _TGTPGTHelper.FillClassLTQuizDetails(LsLTQuizDetails: LsLTQuizDetails);

                        return View("_LTEnglishListDetails", LsLTQuizDetails);
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
