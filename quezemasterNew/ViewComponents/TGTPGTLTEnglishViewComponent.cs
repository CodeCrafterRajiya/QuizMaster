using Microsoft.AspNetCore.Mvc;
using quezemasterNew.BussinesLogic;
using quezemasterNew.Models;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.ViewModel;

namespace quezemasterNew.ViewComponents
{
    public class TGTPGTLTEnglishViewComponent : ViewComponent
    {
        TGTPGTLTEnglishHelper _TGTPGTHelper = new TGTPGTLTEnglishHelper();
        public async Task<IViewComponentResult> InvokeAsync(string ViewComponentType, TGTPGTLTViewModel AptitudeUppDetails)
        {
            try
            {
                switch (ViewComponentType)
                {
                    case "TGTPGTLTEnglishForm":
                        return View("_TGTPGTLTEForm", AptitudeUppDetails);

                    case "TGTPGTLTEnglishList":

                        List<TGTPGTLTViewModel> lsQuezDetsils = new List<TGTPGTLTViewModel>();
                        lsQuezDetsils = await _TGTPGTHelper.FillClassTGTLQuizDetails(lsQuezDetsils: lsQuezDetsils);
                        return View("_TGTPGTLTEListDetails", lsQuezDetsils);
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
