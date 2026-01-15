using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using quezemasterNew.BussinesLogic;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;


namespace quezemasterNew.Controllers
{
    public class QuezIndex10DetailController : Controller
    {
        private readonly QuizeMasterNewContext _context;

        QuezIndex10DetailHelper _QuezIndex10Helper = new QuezIndex10DetailHelper();
        public QuezIndex10DetailController(QuizeMasterNewContext context)
        {
            _context = context;
        }

        // GET: QuezIndex10Detail
        public async Task<IActionResult> Index()
        {


            TblQuezIndex20Detail QuezIndexUPPDetails = new TblQuezIndex20Detail();

              return View("Index", QuezIndexUPPDetails);
        }

        // GET: QuezIndex10Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblQuezIndex20Details == null)
            {
                return NotFound();
            }

            var tblQuezIndex10Detail = await _context.TblQuezIndex20Details
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblQuezIndex10Detail == null)
            {
                return NotFound();
            }

            return View(tblQuezIndex10Detail);
        }

        // GET: QuezIndex10Detail/Create
        [HttpPost]
        public async Task<IActionResult> Create(TblQuezIndex20Detail model)
        {
            string result = "Error";
            try
            {
                if (model != null)
                {
                    if(model.Id>0)
                    {
                     bool IsDataUpdate = await _QuezIndex10Helper.UpdateGeneralAptitudeUppDetails(GeneralAptitudeUppModel: model);

                        result = IsDataUpdate ? "UpdateSuccess" : "UpdateError";
                    }
                    else
                    {
                        bool IsDataSave = await _QuezIndex10Helper.SaveGeneralAptitudeUppDetails(GeneralAptitudeUppModel: model);

                        result = IsDataSave ? "SaveSuccess" : "SaveError";
                    }
                  

                }
            }
            catch(Exception ex)
            {
                
            }
            ViewData["QuezGAUPPResult"] = result;
            return ViewComponent("GeneralAptitudeUPP", new { ViewComponentType = "GeneralAptitudeUPPList", AptitudeUppDetails = model });

        }

        
        // GET: QuezIndex10Detail/Edit/5
        public async Task<IActionResult> EditGeneralAptitudeUPPData(int UPPId)
        {

            TblQuezIndex20Detail QuezIndexDetails = new TblQuezIndex20Detail();
            if(UPPId>0)
            {
                QuezIndexDetails = await _QuezIndex10Helper.GetQuezIndex10UPPDetailsUsingId(UPPId: UPPId);
            }

            return ViewComponent("GeneralAptitudeUPP", new { ViewComponentType = "GeneralAptitudeUPPForm", AptitudeUppDetails = QuezIndexDetails });
            
        }

  
        // GET: QuezIndex10Detail/Delete/5
        public async Task<IActionResult> Delete(int? UPPId)
        {
            string result = "DeleteError";
            TblQuezIndex20Detail QuezIndexUPPDetails = new TblQuezIndex20Detail();
            if (UPPId != null)
            {
                if (UPPId > 0)
                {
                    bool IsDataUpdate = await _QuezIndex10Helper.DeleteGeneralAptitudeUppDetails(UPPId: UPPId);

                    result = IsDataUpdate ? "DeleteSuccess" : "DeleteError";
                }
            }
            ViewData["QuezGAUPPResult"] = result;
            return ViewComponent("GeneralAptitudeUPP", new { ViewComponentType = "GeneralAptitudeUPPList", AptitudeUppDetails = QuezIndexUPPDetails });

        }

        private bool TblQuezIndex10DetailExists(int id)
        {
          return (_context.TblQuezIndex20Details?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
