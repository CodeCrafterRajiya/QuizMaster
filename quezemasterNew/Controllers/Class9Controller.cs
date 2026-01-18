using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.ViewModel.Test;
using quezemasterNew.Models.ViewModel;
using System.Data;
using quezemasterNew.Models.Class9;
using quezemasterNew.BussinesLogic;
using Microsoft.AspNetCore.Authorization;

namespace quezemasterNew.Controllers
{
    [Authorize]
    public class Class9Controller : Controller
    {

        Class9Helper _Class9Helper = new Class9Helper();


        public async Task<IActionResult> Index(string Subject)
        {
            Class9ViewModel BPSCDetails = new Class9ViewModel();
            BPSCDetails.SubjectName = Subject;
            return View(BPSCDetails);
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClass9(Class9ViewModel data)
        {
            try
            {
                if (data != null)
                {
                    await _Class9Helper.SaveClass9QuestionDetails(Class9Details: data);
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
            QuestionPepar10ViewModel Class9PaperDetails = new QuestionPepar10ViewModel();

            try
            {

                Class9PaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {

                    await _Class9Helper.FillQuestionPaperClaass9Details(Class9PaperDetails: Class9PaperDetails, PrimaryId: PrimaryId);
                }


                Class9PaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();


                Class9PaperDetails.lsListQuestion = await _Class9Helper.FillQuestionpaperClass9DetailsById(LsQuestionDetais: Class9PaperDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            {

            }

            return View(Class9PaperDetails);


        }

        public async Task<IActionResult> QuestionAddForm20DetailsAsync(QuestionPepar10ViewModel data)
        {
            try
            {

                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _Class9Helper.SavetblQuestionPeparEnglishClass9Details(QuestionDetails: data);

                    }
                }
                else
                {


                    await _Class9Helper.UpdatetblQuestionPeparEnglishClass9Details(PrimaryId: data.PrimaryId, QuestionDetails: data);

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
                if(id>0)
                {
                    await _Class9Helper.DeletetblQuestionPeparEnglishClass9Details(PrimaryId: id);
                }
            
            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }

        public async Task<IActionResult> TestOnlineAsync(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsClass9Details = new List<Class9QuestionSetViewModel>();
            try
            {


                if (!string.IsNullOrEmpty(SubjectName))
                {
                    LsClass9Details = await _Class9Helper.FillClass9QuestionSetDetailsBySubjectName(LsClass9Details: LsClass9Details, SubjectName: SubjectName);
                }

            }
            catch (Exception ex)
            {


            }

        


            return View(LsClass9Details);
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


                    TblClass9EnglisgTestFinalDetail finalResute = new TblClass9EnglisgTestFinalDetail();


                    finalResute.QuestionNo = test11.QuestionNo;

                    if (string.IsNullOrEmpty(test11.Answer) == false)
                    {
                        string[] Answer = test11.Answer.ToString().Split('-');
                        if(Answer.Length == 2)
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

                    string currentuser = User.Identity.Name;
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

                    await _Class9Helper.SavetblClass9EnglisgTestFinalDetails(finalResute: finalResute);

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }




                if (string.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    List<TblClass9EnglisgTestFinalDetail> LsClass9EnglisgTestFinalDetails = new List<TblClass9EnglisgTestFinalDetail>();

                    LsClass9EnglisgTestFinalDetails = await _Class9Helper.GetClass9EnglishTest20Details(LsClass9EnglisgTestFinalDetails: LsClass9EnglisgTestFinalDetails);




                    string TestIndexId = await _Class9Helper.SaveTestSeriesClass9Details(Class9TestSeriesDetails: test11);

                    await _Class9Helper.UpdateClass9EnlishFinalTestDetails(TestIndexId: TestIndexId, LsClass9EnglisgTestFinalDetails: LsClass9EnglisgTestFinalDetails);

                    return RedirectToAction("ResultDetails", "Class9", new { id = TestIndexId });
                }

           

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
            
              
                List<TblQuestionPeparEnglishClass9Detail> Class9QuestionDetails = new List<TblQuestionPeparEnglishClass9Detail>();

                Class9QuestionDetails = await _Class9Helper.GetClass9QuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                lsdata.QuizName = Class9QuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";

                if (testa == 0)
                    {

                        if (Class9QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class9QuestionDetails)
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
                        var questionList1 = Class9QuestionDetails.Where(x => x.Id == testa).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (Class9QuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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
            List<ResultDetailsViewModel> LsClass9EnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    LsClass9EnglishTestResult = await _Class9Helper.GetClass9EnglishTestFinalResultDetails(LsClass9EnglishTestResult: LsClass9EnglishTestResult, id);

                }

            }
            catch (Exception ex)
            {

            }

            return View("ResultDetails", LsClass9EnglishTestResult);
        }


    }
}
