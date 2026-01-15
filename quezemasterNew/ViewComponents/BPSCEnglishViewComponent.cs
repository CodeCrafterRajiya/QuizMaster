using Microsoft.AspNetCore.Mvc;
using quezemasterNew.BussinesLogic;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.ViewModel;

namespace quezemasterNew.ViewComponents
{
    public class BPSCEnglishViewComponent : ViewComponent
    {
        BPSCEnglishPageHelper BPSCHelper = new BPSCEnglishPageHelper();
        public async Task<IViewComponentResult> InvokeAsync(string ViewComponentType, Class9ViewModel BPSCEnglishDetails)
        {
            try
            {
                switch (ViewComponentType)
                {
                    case "BPSCEnglishForm":
                        return View("_BPSCEnglishForm", BPSCEnglishDetails);

                    case "BPSCEnglishList":

                        List<Class9ViewModel> LsCass9Records = new List<Class9ViewModel>();
                        LsCass9Records = await BPSCHelper.GetBPSCSaveDetails(LsCass9Records, SubjectName: BPSCEnglishDetails.SubjectName);

                        return View("_BPSCEnglishListDetails", LsCass9Records);
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
