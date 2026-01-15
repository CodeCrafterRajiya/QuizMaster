using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using quezemasterNew.BussinesLogic;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel;

namespace quezemasterNew.ViewComponents
{
    public class GeneralAptitudeUPPViewComponent : ViewComponent
    {
        QuezIndex10DetailHelper QuezIndexHelper = new QuezIndex10DetailHelper();
        public async Task<IViewComponentResult> InvokeAsync( string ViewComponentType, TblQuezIndex20Detail AptitudeUppDetails)
        {
            try
            {
                switch (ViewComponentType)
                {
                    case "GeneralAptitudeUPPForm":
                        return View("_GeneralAptitudeUPPForm", AptitudeUppDetails);

                    case "GeneralAptitudeUPPList":

                        List<QuezIndex20DetailsViewModel> lsQuezDetsils = new List<QuezIndex20DetailsViewModel>();
                        lsQuezDetsils = await QuezIndexHelper.GetQuezIndex10UPPDetails(LsQuezDetails: lsQuezDetsils);

                        return View("_GeneralAptitudeUPPListDetails", lsQuezDetsils);
                }
            }
            catch(Exception ex)
            {

            }

            // Optional fallback
            return Content("Invalid ViewComponentType supplied.");
        }
    }

}
