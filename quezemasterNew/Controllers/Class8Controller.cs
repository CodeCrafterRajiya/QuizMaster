using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel.Test;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models;
using System.Data;
using quezemasterNew.BussinesLogic;

namespace quezemasterNew.Controllers
{
    public class Class8Controller : Controller
    {
     

        Class8Helper _Class8Helper = new Class8Helper();

        public async Task<IActionResult> Index(string Subject)
        {

            List<Class9ViewModel> LsClass8QuezDetails = new List<Class9ViewModel>();

            LsClass8QuezDetails = await _Class8Helper.FillClass8QuizDetailsBySubjectName(LsClass8QuezDetails: LsClass8QuezDetails, Subject: Subject);

            return View(LsClass8QuezDetails);
      
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClass8Async(Class9ViewModel data)
        {
            try
            {
                if (data != null)
                {
                    await _Class8Helper.SaveClass8QuestionDetails(Class8Details: data);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
           

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddQuestionAsync(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel Class8PaperDetails = new QuestionPepar10ViewModel();

            try
            {

                Class8PaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {

                    await _Class8Helper.FillQuestionPaperClaass8Details(Class8PaperDetails: Class8PaperDetails, PrimaryId: PrimaryId);
                }


                Class8PaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();


                Class8PaperDetails.lsListQuestion = await _Class8Helper.FillQuestionpaperClass8DetailsById(LsQuestionDetais: Class8PaperDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            {

            }

            return View(Class8PaperDetails);

        }

        public async Task<IActionResult> QuestionAddForm20DetailsAsync(QuestionPepar10ViewModel data)
        {
            try
            {

                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _Class8Helper.SavetblQuestionPeparEnglishClass8Details(QuestionDetails: data);

                    }
                }
                else
                {


                    await _Class8Helper.UpdatetblQuestionPeparEnglishClass8Details(PrimaryId: data.PrimaryId, QuestionDetails: data);

                }

            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("AddQuestion", new { id = data.ConnectedQuestion });
        }

        public async Task<IActionResult> DeleteQuestionAsync(int id, int ConnectionId)
        {
            try
            {
                await _Class8Helper.DeletetblQuestionPeparEnglishClass8Details(PrimaryId: id);

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }

        public async Task<IActionResult> TestOnlineAsync(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsClass8Details = new List<Class9QuestionSetViewModel>();
            try
            {


                if (!string.IsNullOrEmpty(SubjectName))
                {
                    LsClass8Details = await _Class8Helper.FillClass8QuestionSetDetailsBySubjectName(LsClass8Details: LsClass8Details, SubjectName: SubjectName);
                }

            }
            catch (Exception ex)
            {


            }

            return View(LsClass8Details);
        }

        public async Task<IActionResult> OnlineTestAsync(int id, Test10DetailsViewModel test11)
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


                    TblClass8EnglisgTestFinalDetail finalResute = new TblClass8EnglisgTestFinalDetail();


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

                    if (String.IsNullOrEmpty(finalResute.AnswerA) == false)
                    {
                        if (finalResute.AnswerA == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((String.IsNullOrEmpty(finalResute.AnswerB) == false))
                    {
                        if (finalResute.AnswerB == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((String.IsNullOrEmpty(finalResute.AnswerC) == false))
                    {
                        if (finalResute.AnswerC == test11.CurrectAnswer)
                        {
                            finalResute.CurrectAnswer = test11.CurrectAnswer;
                        }
                    }
                    else if ((String.IsNullOrEmpty(finalResute.AnswerD) == false))
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

                    if (String.IsNullOrEmpty(finalResute.CurrentUser) == true)
                    {
                        finalResute.CurrentUser = "";
                    }
                    if (String.IsNullOrEmpty(finalResute.AnswerA) == true)
                    {
                        finalResute.AnswerA = "";
                    }
                    if (String.IsNullOrEmpty(finalResute.AnswerB) == true)
                    {
                        finalResute.AnswerB = "";
                    }
                    if (String.IsNullOrEmpty(finalResute.AnswerC) == true)
                    {
                        finalResute.AnswerC = "";
                    }
                    if (String.IsNullOrEmpty(finalResute.AnswerD) == true)
                    {
                        finalResute.AnswerD = "";
                    }
                    if (String.IsNullOrEmpty(finalResute.QuestionNo) == true)
                    {
                        finalResute.QuestionNo = "";
                    }

                    if (String.IsNullOrEmpty(finalResute.CurrectAnswer) == true)
                    {
                        finalResute.CurrectAnswer = "";
                    }

                    if (String.IsNullOrEmpty(finalResute.TestSerise) == true)
                    {
                        finalResute.TestSerise = "";
                    }

                    finalResute.Remark = "";
                    finalResute.Remark1 = "";
                    finalResute.Remark2 = "";
                    finalResute.Remark3 = "";
                    finalResute.Remark4 = "";


                    await _Class8Helper.SavetblClass8EnglisgTestFinalDetails(finalResute: finalResute);

                 

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }



                if (string.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    List<TblClass8EnglisgTestFinalDetail> LsClass8EnglisgTestFinalDetails = new List<TblClass8EnglisgTestFinalDetail>();

                    LsClass8EnglisgTestFinalDetails = await _Class8Helper.GetClass8EnglishTest20Details(LsClass8EnglisgTestFinalDetails: LsClass8EnglisgTestFinalDetails);




                    string TestIndexId = await _Class8Helper.SaveTestSeriesClass8Details(Class8TestSeriesDetails: test11);

                    await _Class8Helper.UpdateClass8EnlishFinalTestDetails(TestIndexId: TestIndexId, LsClass8EnglisgTestFinalDetails: LsClass8EnglisgTestFinalDetails);

                    return RedirectToAction("ResultDetails", "Class8", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
                List<TblQuestionPeparEnglishClass8Detail> Class8QuestionDetails = new List<TblQuestionPeparEnglishClass8Detail>();

                Class8QuestionDetails = await _Class8Helper.GetClass8QuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                lsdata.QuizName = Class8QuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";

                    if (testa == 0)
                    {

                        if (Class8QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class8QuestionDetails)
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
                        var questionList1 = Class8QuestionDetails.Where(x => x.Id == testa).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (Class8QuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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


            return View("OnlineTest", lsdata);
        }

        public async Task<IActionResult> ResultDetailsAsync(string id)
        {
            List<ResultDetailsViewModel> LsClass8EnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    LsClass8EnglishTestResult = await _Class8Helper.GetClass8EnglishTestFinalResultDetails(LsClass8EnglishTestResult: LsClass8EnglishTestResult, id);

                }

            }
            catch (Exception ex)
            {

            }

            return View("ResultDetails", LsClass8EnglishTestResult);
        }
    }
}
