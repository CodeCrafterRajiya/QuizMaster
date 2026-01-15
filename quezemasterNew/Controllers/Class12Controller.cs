using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel.Test;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models;
using System.Data;
using quezemasterNew.BussinesLogic;
using System.Threading.Tasks;

namespace quezemasterNew.Controllers
{
    public class Class12Controller : Controller
    {
        Class12Helper _Class12Helper= new Class12Helper();

        public async Task<IActionResult> Index(string Subject)
        {

            List<Class9ViewModel> LsClass12Details = new List<Class9ViewModel>();

            LsClass12Details = await _Class12Helper.FillClass12QuizDetailsBySubjectName(LsClass12Details: LsClass12Details, Subject: Subject);

            return View(LsClass12Details);
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClass12(Class9ViewModel data)
        {

            try
            {

                if (data != null)
                {
                    await _Class12Helper.SaveClass12QuizDetails(data: data);
                }
             
            }
            catch (Exception ex)
            {


            }

            return RedirectToAction("Index", new { Subject  = data.SubjectName });
        }


        public async Task<IActionResult> AddQuestion(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel Class12PaperDetails = new QuestionPepar10ViewModel();

            try
            {

                Class12PaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {
                 
                    await _Class12Helper.FillQuestionPaperClaass12Details(Class12PaperDetails: Class12PaperDetails, PrimaryId: PrimaryId);

                }


                Class12PaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();

                Class12PaperDetails.lsListQuestion = await _Class12Helper.FillQuestionpaperClass12DetailsById(LsQuestionDetais: Class12PaperDetails.lsListQuestion, Id: id);

            }
            catch (Exception ex)
            {

            }

            return View(Class12PaperDetails);

        }

        public async Task<IActionResult> QuestionAddForm20Details(QuestionPepar10ViewModel data)
        {
            try
            {


                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _Class12Helper.SavetblQuestionPeparEnglishClass12Details(QuestionDetails: data);

                    }
                }
                else
                {

                    await _Class12Helper.UpdatetblQuestionPeparEnglishClass12Details(PrimaryId: data.PrimaryId, QuestionDetails: data);


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

                if (id > 0)
                {
                    await _Class12Helper.DeletetblQuestionPeparEnglishClass12Details(PrimaryId: id);
                }
            
            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }


        public async Task<IActionResult> DeleteTest(int id,string Subject)
        {
            try
            {

                if (id > 0)
                {
                    await _Class12Helper.DeletetblQuezIndexClass12Details(PrimaryId: id);
                }

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("Index", new { Subject = Subject });
        }



        public async Task<IActionResult> TestOnline(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsClass12Details = new List<Class9QuestionSetViewModel>();

            try
            {
                if(!string.IsNullOrEmpty(SubjectName))
                {
                    LsClass12Details = await _Class12Helper.FillClass12QuestionSetDetailsBySubjectName(LsClass12Details: LsClass12Details, SubjectName: SubjectName);
                }
            }
            catch(Exception ex)
            {

            }

  

            return View(LsClass12Details);
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


                    TblClass12EnglisgTestFinalDetail finalResute = new TblClass12EnglisgTestFinalDetail();


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


                    await _Class12Helper.SavetblClass12EnglisgTestFinalDetails(finalResute: finalResute);
                

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }

               
                if (String.IsNullOrEmpty(test11.FinalTest) == false)
                {


                    List<TblClass12EnglisgTestFinalDetail> LsClass12EnglisgTestFinalDetails = new List<TblClass12EnglisgTestFinalDetail>();

                    LsClass12EnglisgTestFinalDetails = await _Class12Helper.GetClass12EnglishTest20Details(LsClass12EnglisgTestFinalDetails: LsClass12EnglisgTestFinalDetails);




                    string TestIndexId = await _Class12Helper.SaveTestSeriesClass12Details(Class12TestSeriesDetails: test11);

                    await _Class12Helper.UpdateClass12EnlishFinalTestDetails(TestIndexId: TestIndexId, LsClass12EnglisgTestFinalDetails: LsClass12EnglisgTestFinalDetails);

                    return RedirectToAction("ResultDetails", "Class12", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
          
                List<TblQuestionPeparEnglishClass12Detail> Class12QuestionDetails = new List<TblQuestionPeparEnglishClass12Detail>();

                Class12QuestionDetails = await _Class12Helper.GetClass12QuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                lsdata.QuizName = Class12QuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";


                if (testa == 0)
                    {

                        if (Class12QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class12QuestionDetails)
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
                        var questionList1 = Class12QuestionDetails.Where(x => x.Id == testa).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (Class12QuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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
            List<ResultDetailsViewModel> LsClass12EnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {
                LsClass12EnglishTestResult = await _Class12Helper.GetClass12EnglishTestFinalResultDetails(LsClass12EnglishTestResult: LsClass12EnglishTestResult, id);

         
            }
            catch (Exception ex)
            {

            }

            return View("ResultDetails", LsClass12EnglishTestResult);
        }
    }
}
