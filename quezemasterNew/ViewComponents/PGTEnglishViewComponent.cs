using Microsoft.AspNetCore.Mvc;
using quezemasterNew.BussinesLogic;
using quezemasterNew.Models;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.ViewModel;

namespace quezemasterNew.ViewComponents
{
    public class PGTEnglishViewComponent : ViewComponent
    {
        TGTPGTLTEnglishHelper _TGTPGTHelper = new TGTPGTLTEnglishHelper();
        public async Task<IViewComponentResult> InvokeAsync(string ViewComponentType, TGTPGTLTViewModel TGTPGTLTEnglishDetails)
        {
            try
            {
                switch (ViewComponentType)
                {
                    case "PGTEnglishForm":
                        return View("_PGTEnglishForm", TGTPGTLTEnglishDetails);

                    case "PGTEnglishList":

                        List<TGTPGTLTViewModel> lsQuezDetsils = new List<TGTPGTLTViewModel>();
                        lsQuezDetsils = await _TGTPGTHelper.FillClassPGTLQuizDetails(lsQuezDetsils: lsQuezDetsils);

                        return View("_PGTEnglishListDetails", lsQuezDetsils);
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
