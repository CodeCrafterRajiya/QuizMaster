using Microsoft.AspNetCore.Mvc;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel.Test;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models;
using System.Data;
using System.Threading.Tasks;
using quezemasterNew.BussinesLogic;

namespace quezemasterNew.Controllers
{
    public class Class11Controller : Controller
    {

        Class11Helper _Class11Helper = new Class11Helper();
        public async Task<IActionResult> Index(string Subject)
        {

            List<Class9ViewModel> LsClass11QuezDetsils = new List<Class9ViewModel>();

            LsClass11QuezDetsils = await _Class11Helper.FillClass11QuizDetaisBySubject(LsClass11QuezDetsils: LsClass11QuezDetsils,SubjectName: Subject);
        

            return View(LsClass11QuezDetsils);
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClass11(Class9ViewModel data)
        {

            try
            {
                if(data!=null)
                {
                    await _Class11Helper.SaveClass11QuizDetails(QuizDetais:data);
                }
              
            }
            catch (Exception ex)
            {


            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddQuestion(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel Class11PaperDetails = new QuestionPepar10ViewModel();

            try
            {
                Class11PaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {
                    
                    await _Class11Helper.FillQuestionPaperClaass11Details(Class11PaperDetails: Class11PaperDetails, PrimaryId: PrimaryId);
                   
                }
                Class11PaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();



                Class11PaperDetails.lsListQuestion = await _Class11Helper.FillQuestionpaperClass11DetailsById(LsQuestionDetais: Class11PaperDetails.lsListQuestion, Id: id);



            }
            catch (Exception ex)
            {

            }

            return View(Class11PaperDetails);

        }

        public async Task<IActionResult> QuestionAddForm20Details(QuestionPepar10ViewModel data)
        {
            try
            {

                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _Class11Helper.SavetblQuestionPeparEnglishClass11Details(QuestionDetails: data);

                    }
                }
                else
                {

                    await _Class11Helper.UpdatetblQuestionPeparEnglishClass11Details(PrimaryId: data.PrimaryId, QuestionDetails: data);



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
                if(id>0)
                {
                    await _Class11Helper.DeletetblQuestionPeparEnglishClass11Details(PrimaryId: id);
                }

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }

        public async Task<IActionResult> TestOnline(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsClass11Details = new List<Class9QuestionSetViewModel>();

            try
            {

                LsClass11Details = await _Class11Helper.GetClass11QuestionSetDetailsBySubjectName(LsClass11Details, SubjectName);
            }
            catch (Exception ex)
            {


            }


            return View(LsClass11Details);
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


                    TblClass11EnglisgTestFinalDetail finalResute = new TblClass11EnglisgTestFinalDetail();


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


                    await _Class11Helper.SavetblClass11EnglisgTestFinalDetails(finalResute: finalResute);

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }


                if (String.IsNullOrEmpty(test11.FinalTest) == false)
                {
                    List<TblClass11EnglisgTestFinalDetail> LsClass11EnglisgTestFinalDetails = new List<TblClass11EnglisgTestFinalDetail>();

                    LsClass11EnglisgTestFinalDetails = await _Class11Helper.GetClass11EnglishTest20Details(LsClass11EnglisgTestFinalDetails: LsClass11EnglisgTestFinalDetails);




                    string TestIndexId = await _Class11Helper.SaveTestSeriesClass11Details(Class11TestSeriesDetails: test11);

                    await _Class11Helper.UpdateClass11EnlishFinalTestDetails(TestIndexId: TestIndexId, LsClass11EnglisgTestFinalDetails: LsClass11EnglisgTestFinalDetails);

                    return RedirectToAction("ResultDetails", "Class11", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
                    List<TblQuestionPeparEnglishClass11Detail> Class11QuestionDetails = new List<TblQuestionPeparEnglishClass11Detail>();

                    Class11QuestionDetails = await _Class11Helper.GetClass11QuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                    lsdata.QuizName = Class11QuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";


                    if (testa == 0)
                    {

                        if (Class11QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class11QuestionDetails)
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
                        var questionList1 = Class11QuestionDetails.Where(x => x.Id == testa ).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (Class11QuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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

            List<ResultDetailsViewModel> LsClass11EnglishTestResult = new List<ResultDetailsViewModel>();
            try
            {


                LsClass11EnglishTestResult = await _Class11Helper.GetClass11EnglishTestFinalResultDetails(LsClass11EnglishTestResult: LsClass11EnglishTestResult, id);

            }
            catch (Exception ex)
            {

            }

            return View("ResultDetails", LsClass11EnglishTestResult);
        }
    }
}
