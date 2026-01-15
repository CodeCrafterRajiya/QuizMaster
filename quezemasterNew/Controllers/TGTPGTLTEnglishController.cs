using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quezemasterNew.BussinesLogic;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.UPPViewModel;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Data;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quezemasterNew.Controllers
{
    [Authorize]
    public class TGTPGTLTEnglishController : Controller
    {

        TGTPGTLTEnglishHelper _TGTPGTHelper = new TGTPGTLTEnglishHelper();

        QuizeMasterNewContext _context = new QuizeMasterNewContext();

        SqlConnection sqlCon = null;
        public async Task<IActionResult> TGTIndexAsync()
        {

            TGTPGTLTViewModel QuezIndexUPPDetails = new TGTPGTLTViewModel();
            return View(QuezIndexUPPDetails);

        }

        public IActionResult CreateTGT()
        {

            return View();
        }

        public async Task<IActionResult> InsertTGT(TGTPGTLTViewModel data)
        {

            

            string result = "Error";
            try
            {
                if (data != null)
                {
                    if (data.Id > 0)
                    {
                        bool IsDataUpdate = await _TGTPGTHelper.UpdateTGTQuizDetails(data: data);

                        result = IsDataUpdate ? "UpdateSuccess" : "UpdateError";
                    }
                    else
                    {
                        bool IsDataSave = await _TGTPGTHelper.InsertTGTQuizDetails(data: data);

                        result = IsDataSave ? "SaveSuccess" : "SaveError";
                    }


                }
            }
            catch (Exception ex)
            {

            }
            ViewData["TGTPGTResult"] = result;
            return ViewComponent("TGTPGTLTEnglish", new { ViewComponentType = "TGTPGTLTEnglishList", AptitudeUppDetails = data });


        }

        public async Task<IActionResult> AddQuestionTGTAsync(int id, int PrimaryId)
        {

            QuestionPepar10ViewModel ClassTGTPaperDetails = new QuestionPepar10ViewModel();

            try
            {

                ClassTGTPaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {

                    await _TGTPGTHelper.FillQuestionPaperClaassTGTPaperDetails(ClassTGTPaperDetails: ClassTGTPaperDetails, PrimaryId: PrimaryId);
                }


                ClassTGTPaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();


                ClassTGTPaperDetails.lsListQuestion = await _TGTPGTHelper.FillQuestionpaperClassTGTPaperDetailsById(LsQuestionDetais: ClassTGTPaperDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            {

            }


            return View(ClassTGTPaperDetails);

        }

        public async Task<IActionResult> QuestionAddForm10DetailsAsync(QuestionPepar10ViewModel data)
        {
            try
            {


                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _TGTPGTHelper.SavetblQuestionPeparEnglishClassTGTDetails(QuestionDetails: data);

                    }
                }
                else
                {


                    await _TGTPGTHelper.UpdatetblQuestionPeparEnglishClassTGTDetails(PrimaryId: data.PrimaryId, QuestionDetails: data);

                }

            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("AddQuestionTGT", new { id = data.ConnectedQuestion });
        }

        public async Task<IActionResult> DeleteQuestionTGTAsync(int id, int ConnectionId)
        {
            try
            {
                if (id > 0)
                {
                    await _TGTPGTHelper.DeletetblQuestionPeparEnglishClassTGTDetails(PrimaryId: id);
                }

               

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestionTGT", new { id = ConnectionId });
        }

        public async Task<IActionResult> TGTTestOnlineAsync()
        {

            List<TGTQuestionSetViewModel> LsTGTDetails = new List<TGTQuestionSetViewModel>();


            try
            {


                LsTGTDetails = await _TGTPGTHelper.FillClassTGTQuestionSetDetailsBySubjectName(LsTGTDetails: LsTGTDetails);
                

            }
            catch (Exception ex)
            {


            }

            return View(LsTGTDetails);
        }

        public async Task<IActionResult> TGTOnlineTestAsync(int id, Test10DetailsViewModel test11)
        {

            int testa = 0;
            if (id == 0)
            {
                id = test11.ConnectionQuestion;
                testa = test11.TestId + 1;

            }

            try
            {
                if (test11.TestId != 0)
                {


                    TblTgtenglisgTestFinalDetail finalResute = new TblTgtenglisgTestFinalDetail();


                    finalResute.QuestionNo = test11.QuestionNo;

                    if (string.IsNullOrEmpty(test11.Answer) == false)
                    {
                        string[] Answer = test11.Answer.ToString().Split('-');
                        if (Answer.Length == 2)
                        {
                            if (Answer[0] == "A")
                            {
                                finalResute.AnswerA = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "B")
                            {
                                finalResute.AnswerB = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "C")
                            {
                                finalResute.AnswerC = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "D")
                            {
                                finalResute.AnswerD = Answer[1].ToString().Trim();
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(finalResute.AnswerA) == false)
                    {
                        if (finalResute.AnswerA == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerB) == false))
                    {
                        if (finalResute.AnswerB == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerC) == false))
                    {
                        if (finalResute.AnswerC == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerD) == false))
                    {
                        if (finalResute.AnswerD == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }

                    finalResute.ConnectedQuestion = test11.ConnectionQuestion;

                    var currentuser = User.Identity.Name;
                    if (string.IsNullOrEmpty(currentuser) == false)
                    {
                        finalResute.CurrentUser = currentuser;
                    }
                    else
                    {
                        finalResute.CurrentUser = "Na";
                    }


                    finalResute.TestQuestionId = test11.TestId;
                    finalResute.DatetimeStamp = DateTime.Now;

                    if (string.IsNullOrEmpty(finalResute.CurrentUser) == true)
                    {
                        finalResute.CurrentUser = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerA) == true)
                    {
                        finalResute.AnswerA = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerB) == true)
                    {
                        finalResute.AnswerB = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerC) == true)
                    {
                        finalResute.AnswerC = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerD) == true)
                    {
                        finalResute.AnswerD = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.QuestionNo) == true)
                    {
                        finalResute.QuestionNo = "";
                    }

                    if (string.IsNullOrEmpty(finalResute.CurrectAnswer) == true)
                    {
                        finalResute.CurrectAnswer = "";
                    }

                    if (string.IsNullOrEmpty(finalResute.TestSerise) == true)
                    {
                        finalResute.TestSerise = "";
                    }

                    finalResute.Remark = "";
                    finalResute.Remark1 = "";
                    finalResute.Remark2 = "";
                    finalResute.Remark3 = "";
                    finalResute.Remark4 = "";

                    await _TGTPGTHelper.SavetblClassTGTEnglisgTestFinalDetails(finalResute: finalResute);

                

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }

           
             


                if (string.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    List<TblTgtenglisgTestFinalDetail> LsClassTGTDetails = new List<TblTgtenglisgTestFinalDetail>();

                    LsClassTGTDetails = await _TGTPGTHelper.GetClassTGTEnglishTest20Details(LsClassTGTDetails: LsClassTGTDetails);




                    string TestIndexId = await _TGTPGTHelper.SaveTestSeriesClassTGTDetails(ClassTGTTestSeriesDetails: test11);

                    await _TGTPGTHelper.UpdateClassTGTEnlishFinalTestDetails(TestIndexId: TestIndexId, LsClassTGTDetails: LsClassTGTDetails);


                    return RedirectToAction("TGTResultDetails", "TGTPGTLTEnglish", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {


                List<TblQuestionPeparEnglishTgtdetail> ClassTGTQuestionDetails = await _TGTPGTHelper.GetClassTGTQuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                lsdata.QuizName = ClassTGTQuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";


                    if (testa == 0)
                    {

                        if (ClassTGTQuestionDetails.Count() > 0)
                        {
                            foreach (var item in ClassTGTQuestionDetails)
                            {
                                lsdata.TestId = item.Id;
                                lsdata.QuestionId = item.Id;
                                lsdata.QuestionNo = item.QuestionNo;
                                lsdata.AnswerA = item.AnswerA;
                                lsdata.AnswerB = item.AnswerB;
                                lsdata.AnswerC = item.AnswerC;
                                lsdata.CurrectAnswer = item.CurrectAnswer;
                                lsdata.AnswerD = item.AnswerD;
                                lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);
                                break;
                            }
                        }

                    }
                    else
                    {
                        var questionList1 = ClassTGTQuestionDetails.Where(x => x.Id == testa ).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (ClassTGTQuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo;
                                    lsdata.AnswerA = item.AnswerA;
                                    lsdata.CurrectAnswer = item.CurrectAnswer;
                                    lsdata.AnswerB = item.AnswerB;
                                    lsdata.AnswerC = item.AnswerC;
                                    lsdata.AnswerD = item.AnswerD;
                                    lsdata.FinalTest = "Final Test";
                                    lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);

                                    break;

                                }
                                else
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo;
                                    lsdata.AnswerA = item.AnswerA;
                                    lsdata.AnswerB = item.AnswerB;
                                    lsdata.AnswerC = item.AnswerC;
                                    lsdata.CurrectAnswer = item.CurrectAnswer;
                                    lsdata.AnswerD = item.AnswerD;
                                    lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);

                                    break;
                                }


                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {


            }


            return View("TGTOnlineTest", lsdata);
        }

        public async Task<IActionResult> TGTResultDetailsAsync(string id)
        {


            List<ResultDetailsViewModel> LsClassTGTEnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    LsClassTGTEnglishTestResult = await _TGTPGTHelper.GetClassTGTEnglishTestFinalResultDetails(LsClassTGTEnglishTestResult: LsClassTGTEnglishTestResult, id);

                }

            }
            catch (Exception ex)
            {

            }

            return View("TGTResultDetails", LsClassTGTEnglishTestResult);
        }



        // GET: QuezIndex10Detail/Edit/5
        public async Task<IActionResult> EditTGTDetailsData(int TGTId)
        {

            TGTPGTLTViewModel TGTDetails = new TGTPGTLTViewModel();
            if (TGTId > 0)
            {
                TGTDetails = await _TGTPGTHelper.FillClassTGTLQuizDetailsUsingId(TGTId: TGTId);
            }
            return ViewComponent("TGTPGTLTEnglish", new { ViewComponentType = "TGTPGTLTEnglishForm", AptitudeUppDetails = TGTDetails });

        }



        public async Task<IActionResult> DeleteTGTDetails(int? TGTId)
        {
            string result = "DeleteError";
            TGTPGTLTViewModel QuezIndexTGTDetails = new TGTPGTLTViewModel(); ;
            if (TGTId != null)
            {
                if (TGTId > 0)
                {
                    bool IsDataUpdate = await _TGTPGTHelper.DeleteTGTDetails(TGTId: TGTId);

                    result = IsDataUpdate ? "DeleteSuccess" : "DeleteError";
                }
            }
            ViewData["TGTPGTResult"] = result;
            return ViewComponent("TGTPGTLTEnglish", new { ViewComponentType = "TGTPGTLTEnglishList", AptitudeUppDetails = QuezIndexTGTDetails });
        }



        public async Task<IActionResult> PGTIndexAsync()
        {

            TGTPGTLTViewModel PGTDetails = new TGTPGTLTViewModel();
            return View(PGTDetails);

        }


        public async Task<IActionResult> InsertPGTAsync(TGTPGTLTViewModel data)
        {

            string result = "Error";
            try
            {
                if (data != null)
                {
                    if (data.Id > 0)
                    {
                        bool IsDataUpdate = await _TGTPGTHelper.UpdatePGTQuizDetails(data: data);

                        result = IsDataUpdate ? "UpdateSuccess" : "UpdateError";
                    }
                    else
                    {
                        bool IsDataSave = await _TGTPGTHelper.InsertPGTQuizDetails(ClassPGTDetails: data);

                        result = IsDataSave ? "SaveSuccess" : "SaveError";
                    }


                }
            }
            catch (Exception ex)
            {

            }
            ViewData["PGTResult"] = result;
            return ViewComponent("PGTEnglish", new { ViewComponentType = "PGTEnglishList", AptitudeUppDetails = data });

        }

        public async Task<IActionResult> AddQuestionPGTAsync(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel ClassPGTDetails = new QuestionPepar10ViewModel();


            try
            {

                ClassPGTDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {

                    await _TGTPGTHelper.FillQuestionPaperClassPGTDetails(ClassPGTDetails: ClassPGTDetails, PrimaryId: PrimaryId);
                }


                ClassPGTDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();


                ClassPGTDetails.lsListQuestion = await _TGTPGTHelper.FillQuestionpaperClassPGTDetailsById(LsQuestionDetais: ClassPGTDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            { 

            }




    
            return View(ClassPGTDetails);

        }

        public async Task<IActionResult> QuestionAddForm20DetailsPGTAsync(QuestionPepar10ViewModel data)
        {


            try
            {

                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _TGTPGTHelper.SavetblQuestionPeparEnglishClassPGTDetails(QuestionDetails: data);

                    }
                }
                else
                {


                    await _TGTPGTHelper.UpdatetblQuestionPeparEnglishClassPGTDetails(PrimaryId: data.PrimaryId, QuestionDetails: data);

                }
            }
            catch (Exception ex)
            {

            }


            return RedirectToAction("AddQuestionPGT", new { id = data.ConnectedQuestion });
        }

        public async Task<IActionResult> DeleteQuestionPGTAsync(int id, int ConnectionId)
        {

            try
            {
                if (id > 0)
                {
                    await _TGTPGTHelper.DeletetblQuestionPeparEnglishClassPGTDetails(PrimaryId: id);
                }

            }
            catch (Exception EX)
            {
            }

            return RedirectToAction("AddQuestionPGT", new { id = ConnectionId });
        }

        public async Task<IActionResult> PGTTestOnlineAsync()
        {

            List<TGTQuestionSetViewModel> LsClassPGTDetails = new List<TGTQuestionSetViewModel>();


            try
            {

                LsClassPGTDetails = await _TGTPGTHelper.FillClassPGTQuestionSetDetailsBySubjectName(LsClassPGTDetails: LsClassPGTDetails);
               

            }
            catch (Exception ex)
            {


            }


    

            return View(LsClassPGTDetails);
        }

        public async Task<IActionResult> PGTOnlineTestAsync(int id, Test10DetailsViewModel test11)
        {

            int testa = 0;
            if (id == 0)
            {
                id = test11.ConnectionQuestion;
                testa = test11.TestId + 1;

            }

            try
            {
                if (test11.TestId != 0)
                {


                    TblPgtenglisgTestFinalDetail finalResute = new TblPgtenglisgTestFinalDetail();


                    finalResute.QuestionNo = test11.QuestionNo;

                    if (string.IsNullOrEmpty(test11.Answer) == false)
                    {
                        string[] Answer = test11.Answer.ToString().Split('-');
                        if (Answer.Length == 2)
                        {
                            if (Answer[0] == "A")
                            {
                                finalResute.AnswerA = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "B")
                            {
                                finalResute.AnswerB = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "C")
                            {
                                finalResute.AnswerC = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "D")
                            {
                                finalResute.AnswerD = Answer[1].ToString().Trim();
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(finalResute.AnswerA) == false)
                    {
                        if (finalResute.AnswerA == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerB) == false))
                    {
                        if (finalResute.AnswerB == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerC) == false))
                    {
                        if (finalResute.AnswerC == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerD) == false))
                    {
                        if (finalResute.AnswerD == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }

                    finalResute.ConnectedQuestion = test11.ConnectionQuestion;

                    var currentuser = User.Identity.Name;
                    if (string.IsNullOrEmpty(currentuser) == false)
                    {
                        finalResute.CurrentUser = currentuser;
                    }
                    else
                    {
                        finalResute.CurrentUser = "Na";
                    }


                    finalResute.TestQuestionId = test11.TestId;
                    finalResute.DatetimeStamp = DateTime.Now;

                    if (string.IsNullOrEmpty(finalResute.CurrentUser) == true)
                    {
                        finalResute.CurrentUser = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerA) == true)
                    {
                        finalResute.AnswerA = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerB) == true)
                    {
                        finalResute.AnswerB = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerC) == true)
                    {
                        finalResute.AnswerC = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerD) == true)
                    {
                        finalResute.AnswerD = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.QuestionNo) == true)
                    {
                        finalResute.QuestionNo = "";
                    }

                    if (string.IsNullOrEmpty(finalResute.CurrectAnswer) == true)
                    {
                        finalResute.CurrectAnswer = "";
                    }

                    if (string.IsNullOrEmpty(finalResute.TestSerise) == true)
                    {
                        finalResute.TestSerise = "";
                    }

                    finalResute.Remark = "";
                    finalResute.Remark1 = "";
                    finalResute.Remark2 = "";
                    finalResute.Remark3 = "";
                    finalResute.Remark4 = "";


                    await _TGTPGTHelper.SavetblClassPGTEnglisgTestFinalDetails(finalResute: finalResute);



                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }




                if (string.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    List<TblClass9EnglisgTestFinalDetail> LsClassPGTEnglisgTestFinalDetails = new List<TblClass9EnglisgTestFinalDetail>();

                    LsClassPGTEnglisgTestFinalDetails = await _TGTPGTHelper.GetClassPGTEnglishTest20Details(LsClassPGTEnglisgTestFinalDetails: LsClassPGTEnglisgTestFinalDetails);




                    string TestIndexId = await _TGTPGTHelper.SaveTestSeriesClassPGTDetails(ClassPGTTestSeriesDetails: test11);

                    await _TGTPGTHelper.UpdateClassPGTEnlishFinalTestDetails(TestIndexId: TestIndexId, LsClassPGTEnglisgTestFinalDetails: LsClassPGTEnglisgTestFinalDetails);


                    return RedirectToAction("PGTResultDetails", "TGTPGTLTEnglish", new { id = TestIndexId });
                }


            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
                List<TblQuestionPeparEnglishPgtdetail> ClassPGTQuestionDetails = new List<TblQuestionPeparEnglishPgtdetail>();

                ClassPGTQuestionDetails = await _TGTPGTHelper.GetClassPGTQuestionDetailsByConnectedQuestion(ConnectedQuestion: id);



                lsdata.QuizName = ClassPGTQuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";

               
                    if (testa == 0)
                    {

                        if (ClassPGTQuestionDetails.Count() > 0)
                        {
                            foreach (var item in ClassPGTQuestionDetails)
                            {
                                lsdata.TestId = item.Id;
                                lsdata.QuestionId = item.Id;
                                lsdata.QuestionNo = item.QuestionNo;
                                lsdata.AnswerA = item.AnswerA;
                                lsdata.AnswerB = item.AnswerB;
                                lsdata.AnswerC = item.AnswerC;
                                lsdata.CurrectAnswer = item.CurrectAnswer;
                                lsdata.AnswerD = item.AnswerD;
                                lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);
                                break;
                            }
                        }

                    }
                    else
                    {
                        var questionList1 = ClassPGTQuestionDetails.Where(x => x.Id == testa ).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (ClassPGTQuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo;
                                    lsdata.AnswerA = item.AnswerA;
                                    lsdata.CurrectAnswer = item.CurrectAnswer;
                                    lsdata.AnswerB = item.AnswerB;
                                    lsdata.AnswerC = item.AnswerC;
                                    lsdata.AnswerD = item.AnswerD;
                                    lsdata.FinalTest = "Final Test";
                                    lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);

                                    break;

                                }
                                else
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo;
                                    lsdata.AnswerA = item.AnswerA;
                                    lsdata.AnswerB = item.AnswerB;
                                    lsdata.AnswerC = item.AnswerC;
                                    lsdata.CurrectAnswer = item.CurrectAnswer;
                                    lsdata.AnswerD = item.AnswerD;
                                    lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);

                                    break;
                                }


                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {


            }


            return View("PGTOnlineTest", lsdata);
        }

        public async Task<IActionResult> PGTResultDetailsAsync(string id)
        {

            List<ResultDetailsViewModel> LsClassPGTDetails = new List<ResultDetailsViewModel>();


            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    LsClassPGTDetails = await _TGTPGTHelper.GetClassPGTEnglishTestFinalResultDetails(LsClassPGTEnglishTestResult: LsClassPGTDetails, id);

                }

            }
            catch (Exception ex)
            {

            }




            return View("PGTResultDetails", LsClassPGTDetails);
        }


        public async Task<IActionResult> EditPGTDetailsData(int PGTId)
        {

            TGTPGTLTViewModel PGTDetails = new TGTPGTLTViewModel();
            if (PGTId > 0)
            {
                PGTDetails = await _TGTPGTHelper.FillClassPGTLQuizDetailsUsingId(PGTId: PGTId);
            }
            return ViewComponent("PGTEnglish", new { ViewComponentType = "PGTEnglishForm", TGTPGTLTEnglishDetails = PGTDetails });

        }



        public async Task<IActionResult> DeletePGTDetails(int? PGTId)
        {
            string result = "DeleteError";
            TGTPGTLTViewModel QuezIndexPGTDetails = new TGTPGTLTViewModel(); ;
            if (PGTId != null)
            {
                if (PGTId > 0)
                {
                    bool IsDataUpdate = await _TGTPGTHelper.DeletePGTIdDetails(PGTId: PGTId);

                    result = IsDataUpdate ? "DeleteSuccess" : "DeleteError";
                }
            }
            ViewData["PGTResult"] = result;
            return ViewComponent("PGTEnglish", new { ViewComponentType = "PGTEnglishList", AptitudeUppDetails = QuezIndexPGTDetails });
        }





        public async Task<IActionResult> LTIndexAsync()
        {

            TGTPGTLTViewModel PGTDetails = new TGTPGTLTViewModel();
            return View(PGTDetails);
        }

        public IActionResult CreateLT()
        {

            return View();
        }

        public async Task<IActionResult> InsertLTAsync(TGTPGTLTViewModel data)
        {
            string result = "Error";
            try
            {
                if (data != null)
                {
                    if (data.Id > 0)
                    {
                        bool IsDataUpdate = await _TGTPGTHelper.UpdateLTQuizDetails(data: data);

                        result = IsDataUpdate ? "UpdateSuccess" : "UpdateError";
                    }
                    else
                    {
                        bool IsDataSave = await _TGTPGTHelper.InsertLTQuizDetails(ClassLTDetails: data);

                        result = IsDataSave ? "SaveSuccess" : "SaveError";
                    }


                }
            }
            catch (Exception ex)
            {

            }
            ViewData["LTResult"] = result;
            return ViewComponent("LTEnglish", new { ViewComponentType = "LTEnglishList", AptitudeUppDetails = data });


        }

        public async Task<IActionResult> AddQuestionLTAsync(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel ClassLTPaperDetails = new QuestionPepar10ViewModel();


            try
            {

                ClassLTPaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {

                    await _TGTPGTHelper.FillQuestionPaperClaassLTDetails(ClassLTPaperDetails: ClassLTPaperDetails, PrimaryId: PrimaryId);
                }


                ClassLTPaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();


                ClassLTPaperDetails.lsListQuestion = await _TGTPGTHelper.FillQuestionpaperClassLTDetailsById(LsQuestionDetais: ClassLTPaperDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            {

            }

            return View(ClassLTPaperDetails);

        }

        public async Task<IActionResult> QuestionAddForm20DetailsLTAsync(QuestionPepar10ViewModel data)
        {



            try
            {

                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _TGTPGTHelper.SavetblQuestionPeparEnglishClassLTDetails(QuestionDetails: data);

                    }
                }
                else
                {

                    await _TGTPGTHelper.UpdatetblQuestionPeparEnglishClassLTDetails(PrimaryId: data.PrimaryId, QuestionDetails: data);

                }
            }
            catch (Exception ex)
            {

            }



            return RedirectToAction("AddQuestionLT", new { id = data.ConnectedQuestion });
        }

        public async Task<IActionResult> DeleteQuestionLTAsync(int id, int ConnectionId)
        {


            try
            {
                if (id > 0)
                {
                    await _TGTPGTHelper.DeletetblQuestionPeparEnglishClassLTDetails(PrimaryId: id);
                }

            }
            catch (Exception EX)
            {
            }

            
            return RedirectToAction("AddQuestionLT", new { id = ConnectionId });
        }



        public async Task<IActionResult> EditLTDetailsData(int LTId)
        {

            TGTPGTLTViewModel PGTDetails = new TGTPGTLTViewModel();
            if (LTId > 0)
            {
                PGTDetails = await _TGTPGTHelper.FillClassLTEnglishQuizDetailsUsingId(LTId: LTId);
            }
            return ViewComponent("LTEnglish", new { ViewComponentType = "LTEnglishForm", LTEnglishDetails = PGTDetails });

        }



        public async Task<IActionResult> DeleteLTDetails(int? LTId)
        {
            string result = "DeleteError";
            TGTPGTLTViewModel QuezIndexPGTDetails = new TGTPGTLTViewModel(); ;
            if (LTId != null)
            {
                if (LTId > 0)
                {
                    bool IsDataUpdate = await _TGTPGTHelper.DeleteLTIdDetails(LTId: LTId);

                    result = IsDataUpdate ? "DeleteSuccess" : "DeleteError";
                }
            }
            ViewData["LTResult"] = result;
            return ViewComponent("LTEnglish", new { ViewComponentType = "LTEnglishList", LTEnglishDetails = QuezIndexPGTDetails });
        }







        public async Task<IActionResult> LTTestOnlineAsync()
        {



            List<TGTQuestionSetViewModel> LsClassLtDetails = new List<TGTQuestionSetViewModel>();
            try
            {


                LsClassLtDetails = await _TGTPGTHelper.FillClassLTQuestionSetDetails(LsClassLtDetails: LsClassLtDetails);
                

            }
            catch (Exception ex)
            {


            }

            return View(LsClassLtDetails);
        }

        public async Task<IActionResult> LTOnlineTestAsync(int id, Test10DetailsViewModel test11)
        {

            int testa = 0;
            if (id == 0)
            {
                id = test11.ConnectionQuestion;
                testa = test11.TestId + 1;

            }

            try
            {
                if (test11.TestId != 0)
                {


                    TblTgtenglisgTestFinalDetail finalResute = new TblTgtenglisgTestFinalDetail();


                    finalResute.QuestionNo = test11.QuestionNo;

                    if (string.IsNullOrEmpty(test11.Answer) == false)
                    {
                        string[] Answer = test11.Answer.ToString().Split('-');
                        if (Answer.Length == 2)
                        {
                            if (Answer[0] == "A")
                            {
                                finalResute.AnswerA = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "B")
                            {
                                finalResute.AnswerB = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "C")
                            {
                                finalResute.AnswerC = Answer[1].ToString().Trim();
                            }
                            if (Answer[0] == "D")
                            {
                                finalResute.AnswerD = Answer[1].ToString().Trim();
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(finalResute.AnswerA) == false)
                    {
                        if (finalResute.AnswerA == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerB) == false))
                    {
                        if (finalResute.AnswerB == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerC) == false))
                    {
                        if (finalResute.AnswerC == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((string.IsNullOrEmpty(finalResute.AnswerD) == false))
                    {
                        if (finalResute.AnswerD == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }

                    finalResute.ConnectedQuestion = test11.ConnectionQuestion;

                    var currentuser = User.Identity.Name;
                    if (string.IsNullOrEmpty(currentuser) == false)
                    {
                        finalResute.CurrentUser = currentuser;
                    }
                    else
                    {
                        finalResute.CurrentUser = "Na";
                    }


                    finalResute.TestQuestionId = test11.TestId;
                    finalResute.DatetimeStamp = DateTime.Now;

                    if (string.IsNullOrEmpty(finalResute.CurrentUser) == true)
                    {
                        finalResute.CurrentUser = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerA) == true)
                    {
                        finalResute.AnswerA = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerB) == true)
                    {
                        finalResute.AnswerB = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerC) == true)
                    {
                        finalResute.AnswerC = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.AnswerD) == true)
                    {
                        finalResute.AnswerD = "";
                    }
                    if (string.IsNullOrEmpty(finalResute.QuestionNo) == true)
                    {
                        finalResute.QuestionNo = "";
                    }

                    if (string.IsNullOrEmpty(finalResute.CurrectAnswer) == true)
                    {
                        finalResute.CurrectAnswer = "";
                    }

                    if (string.IsNullOrEmpty(finalResute.TestSerise) == true)
                    {
                        finalResute.TestSerise = "";
                    }

                    finalResute.Remark = "";
                    finalResute.Remark1 = "";
                    finalResute.Remark2 = "";
                    finalResute.Remark3 = "";
                    finalResute.Remark4 = "";

                    await _TGTPGTHelper.SavetblClassLTEnglisgTestFinalDetails(finalResute: finalResute);

                  

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }

                if (string.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    List<TblLtenglisgTestFinalDetail> LsClassLTEnglisgTestFinalDetails = new List<TblLtenglisgTestFinalDetail>();

                    LsClassLTEnglisgTestFinalDetails = await _TGTPGTHelper.GetClassLTEnglishTest20Details(LsClassLTEnglisgTestFinalDetails: LsClassLTEnglisgTestFinalDetails);




                    string TestIndexId = await _TGTPGTHelper.SaveTestSeriesClassLTDetails(Class9TestSeriesDetails: test11);

                    await _TGTPGTHelper.UpdateClassLTEnlishFinalTestDetails(TestIndexId: TestIndexId, LsClassLTEnglisgTestFinalDetails: LsClassLTEnglisgTestFinalDetails);
                    return RedirectToAction("LTResultDetails", "TGTPGTLTEnglish", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
                var test1 = _context.TblQuezIndexLtdetails.Where(x => x.Id == id).FirstOrDefault();



                List<TblQuestionPeparEnglishLtdetail> ClassLTQuestionDetails = new List<TblQuestionPeparEnglishLtdetail>();

                ClassLTQuestionDetails = await _TGTPGTHelper.GetClassLTQuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                lsdata.QuizName = ClassLTQuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";


                    if (testa == 0)
                    {

                        if (ClassLTQuestionDetails.Count() > 0)
                        {
                            foreach (var item in ClassLTQuestionDetails)
                            {
                                lsdata.TestId = item.Id;
                                lsdata.QuestionId = item.Id;
                                lsdata.QuestionNo = item.QuestionNo;
                                lsdata.AnswerA = item.AnswerA;
                                lsdata.AnswerB = item.AnswerB;
                                lsdata.AnswerC = item.AnswerC;
                                lsdata.CurrectAnswer = item.CurrectAnswer;
                                lsdata.AnswerD = item.AnswerD;
                                lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);
                                break;
                            }
                        }

                    }
                    else
                    {
                        var questionList1 = ClassLTQuestionDetails.Where(x => x.Id == testa).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (ClassLTQuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo;
                                    lsdata.AnswerA = item.AnswerA;
                                    lsdata.CurrectAnswer = item.CurrectAnswer;
                                    lsdata.AnswerB = item.AnswerB;
                                    lsdata.AnswerC = item.AnswerC;
                                    lsdata.AnswerD = item.AnswerD;
                                    lsdata.FinalTest = "Final Test";
                                    lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);

                                    break;

                                }
                                else
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo;
                                    lsdata.AnswerA = item.AnswerA;
                                    lsdata.AnswerB = item.AnswerB;
                                    lsdata.AnswerC = item.AnswerC;
                                    lsdata.CurrectAnswer = item.CurrectAnswer;
                                    lsdata.AnswerD = item.AnswerD;
                                    lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);

                                    break;
                                }


                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {


            }


            return View("LTOnlineTest", lsdata);
        }

        public async Task<IActionResult> LTResultDetailsAsync(string id)
        {

            var LsResult = new List<ResultDetailsViewModel>();

            List<ResultDetailsViewModel> LsClassLTEnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    LsClassLTEnglishTestResult = await _TGTPGTHelper.GetClassLTEnglishTestFinalResultDetails(LsClassLTEnglishTestResult: LsClassLTEnglishTestResult, id);

                }

            }
            catch (Exception ex)
            {

            }

            return View("LTResultDetails", LsResult);
        }



    }
}
