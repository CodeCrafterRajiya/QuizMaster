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
    public class Class6Controller : Controller
    {
        QuizeMasterNewContext _context = new QuizeMasterNewContext();
        Class6Helper _Class6Helper =new Class6Helper();
        public async Task<IActionResult> Index(string Subject)
        {

            List<Class9ViewModel> LsClass6QuezDetails = new List<Class9ViewModel>();
            LsClass6QuezDetails = await _Class6Helper.FillClass6QuizDetailsBySubjectName(LsClass6QuezDetails: LsClass6QuezDetails, Subject: Subject);

            return View(LsClass6QuezDetails);
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClass6(Class9ViewModel data)
        {
            try
            {
                if(data!=null)
                {
                    await _Class6Helper.SaveClass6QuizDetails(data: data);
                }
            }
            catch (Exception ex)
            {
            }

    

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddQuestion(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel Class6PaperDetails = new QuestionPepar10ViewModel();

            try
            {

                Class6PaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {
              
                    await _Class6Helper.FillQuestionPaperClaass6Details(Class6PaperDetails: Class6PaperDetails, PrimaryId: PrimaryId);
                }


                Class6PaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();


                Class6PaperDetails.lsListQuestion = await _Class6Helper.FillQuestionpaperClass6DetailsById(LsQuestionDetais: Class6PaperDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            {

            }

            return View(Class6PaperDetails);

        }

        public async Task<IActionResult> QuestionAddForm20Details(QuestionPepar10ViewModel data)
        {
            try
            {


                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _Class6Helper.SavetblQuestionPeparEnglishClass6Details(QuestionDetails: data);

                    }
                }
                else
                {


                    await _Class6Helper.UpdatetblQuestionPeparEnglishClass6Details(PrimaryId: data.PrimaryId, QuestionDetails: data);

                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("AddQuestion", new { id = data.ConnectedQuestion });
        }

        public  async Task<IActionResult> DeleteQuestionAsync(int id, int ConnectionId)
        {
            try
            {

                await _Class6Helper.DeletetblQuestionPeparEnglishClass6Details(PrimaryId: id);

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }

        public async Task<IActionResult> TestOnlineAsync(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsClass6Details = new List<Class9QuestionSetViewModel>();
            try
            {
                if (!string.IsNullOrEmpty(SubjectName))
                {
                    LsClass6Details = await _Class6Helper.FillClass6QuestionSetDetailsBySubjectName(LsClass6Details: LsClass6Details, SubjectName: SubjectName);
                }
            }
            catch(Exception ex)
            {
            }   
         

            return View(LsClass6Details);
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


                    TblClass6EnglisgTestFinalDetail finalResute = new TblClass6EnglisgTestFinalDetail();


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

                    await _Class6Helper.SavetblClass6EnglisgTestFinalDetails(finalResute: finalResute);

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }

         

                if (String.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    List<TblClass6EnglisgTestFinalDetail> LsClass6EnglisgTestFinalDetails = new List<TblClass6EnglisgTestFinalDetail>();

                    LsClass6EnglisgTestFinalDetails = await _Class6Helper.GetClass6EnglishTest20Details(LsClass6EnglisgTestFinalDetails: LsClass6EnglisgTestFinalDetails);




                    string TestIndexId = await _Class6Helper.SaveTestSeriesClass6Details(Class6TestSeriesDetails: test11);

                    await _Class6Helper.UpdateClass6EnlishFinalTestDetails(TestIndexId: TestIndexId, LsClass6EnglisgTestFinalDetails: LsClass6EnglisgTestFinalDetails);

                    return RedirectToAction("ResultDetails", "Class6", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
             
                    List<TblQuestionPeparEnglishClass6Detail> Class6QuestionDetails = new List<TblQuestionPeparEnglishClass6Detail>();

                   Class6QuestionDetails = await _Class6Helper.GetClass6QuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                   lsdata.QuizName = Class6QuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";


                    if (testa == 0)
                    {

                        if (Class6QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class6QuestionDetails)
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
                        var questionList1 = Class6QuestionDetails.Where(x => x.Id == testa).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (Class6QuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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

        public async Task<IActionResult> ResultDetails(string id)
        {

            List<ResultDetailsViewModel> LsClass6EnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    LsClass6EnglishTestResult = await _Class6Helper.GetClass6EnglishTestFinalResultDetails(LsClass6EnglishTestResult: LsClass6EnglishTestResult, id);
                   
                }

            }
            catch (Exception ex)
            {

            }

            return View("ResultDetails", LsClass6EnglishTestResult);
        }

    }
}
