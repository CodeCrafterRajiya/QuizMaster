using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using quezemasterNew.BussinesLogic;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quezemasterNew.Controllers
{
    public class Class7Controller : Controller
    {

        Class7Helper _Class7Helper = new Class7Helper();


        public async Task<IActionResult> Index(string Subject)
        {

            List<Class9ViewModel> LsClass7QuezDetails = new List<Class9ViewModel>();

            LsClass7QuezDetails = await _Class7Helper.FillClass7QuizDetailsBySubjectName(LsClass7QuezDetails: LsClass7QuezDetails, Subject: Subject);

            return View(LsClass7QuezDetails);

        
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClass7(Class9ViewModel data)
        {

           try
            {
                if(data!=null)
                {
                    await _Class7Helper.SaveClass7QuestionDetails(Class7Details:data);
                }
            }
            catch(Exception ex)
            {
                // Handle exception
            }

            return RedirectToAction("Index");
        }

 

        public async Task<IActionResult> AddQuestion(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel Class7PaperDetails = new QuestionPepar10ViewModel();

            try
            {

                Class7PaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {

                    await _Class7Helper.FillQuestionPaperClaass7Details(Class7PaperDetails: Class7PaperDetails, PrimaryId: PrimaryId);
                }


                Class7PaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();


                Class7PaperDetails.lsListQuestion = await _Class7Helper.FillQuestionpaperClass7DetailsById(LsQuestionDetais: Class7PaperDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            {

            }

            return View(Class7PaperDetails);

        }

        public async Task<IActionResult> QuestionAddForm20Details(QuestionPepar10ViewModel data)
        {
            try
            {

                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _Class7Helper.SavetblQuestionPeparEnglishClass7Details(QuestionDetails: data);

                    }
                }
                else
                {


                    await _Class7Helper.UpdatetblQuestionPeparEnglishClass7Details(PrimaryId: data.PrimaryId, QuestionDetails: data);

                }

            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("AddQuestion", new { id = data.ConnectedQuestion });
        }

        public async Task<IActionResult> DeleteQuestion(int id, int ConnectionId)
        {
            try
            {
                await _Class7Helper.DeletetblQuestionPeparEnglishClass7Details(PrimaryId: id);

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }

        public async Task<IActionResult> TestOnline(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsClass7Details = new List<Class9QuestionSetViewModel>();

            try
            {


                if (!string.IsNullOrEmpty(SubjectName))
                {
                    LsClass7Details = await _Class7Helper.FillClass7QuestionSetDetailsBySubjectName(LsClass7Details: LsClass7Details, SubjectName: SubjectName);
                }

            }
            catch (Exception ex)
            {


            }


            return View(LsClass7Details);
        }

        public async Task<IActionResult> OnlineTest(int id, Test10DetailsViewModel test11)
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


                    TblClass7EnglisgTestFinalDetail finalResute = new TblClass7EnglisgTestFinalDetail();


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

                    await _Class7Helper.SavetblClass7EnglisgTestFinalDetails(finalResute: finalResute);
                    

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }


                if (string.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    List<TblClass7EnglisgTestFinalDetail> LsClass7EnglisgTestFinalDetails = new List<TblClass7EnglisgTestFinalDetail>();

                    LsClass7EnglisgTestFinalDetails = await _Class7Helper.GetClass7EnglishTest20Details(LsClass7EnglisgTestFinalDetails: LsClass7EnglisgTestFinalDetails);




                    string TestIndexId = await _Class7Helper.SaveTestSeriesClass7Details(Class7TestSeriesDetails: test11);

                    await _Class7Helper.UpdateClass7EnlishFinalTestDetails(TestIndexId: TestIndexId, LsClass7EnglisgTestFinalDetails: LsClass7EnglisgTestFinalDetails);

                    return RedirectToAction("ResultDetails", "Class7", new { id = TestIndexId });
                }

      

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
                List<TblQuestionPeparEnglishClass7Detail> Class7QuestionDetails = new List<TblQuestionPeparEnglishClass7Detail>();

                Class7QuestionDetails = await _Class7Helper.GetClass7QuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                lsdata.QuizName = Class7QuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";

                    if (testa == 0)
                    {

                        if (Class7QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class7QuestionDetails)
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
                        var questionList1 = Class7QuestionDetails.Where(x => x.Id == testa).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (Class7QuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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

        public async  Task<IActionResult> ResultDetails(string id)
        {

            List<ResultDetailsViewModel> LsClass7EnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    LsClass7EnglishTestResult = await _Class7Helper.GetClass7EnglishTestFinalResultDetails(LsClass7EnglishTestResult: LsClass7EnglishTestResult, id);

                }

            }
            catch (Exception ex)
            {

            }

            return View("ResultDetails", LsClass7EnglishTestResult);
        }
    }
}
