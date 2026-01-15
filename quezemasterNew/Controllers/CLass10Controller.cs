using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using quezemasterNew.BussinesLogic;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace quezemasterNew.Controllers
{
    public class CLass10Controller : Controller
    {
    
        Class10Helper _Class10Helper = new Class10Helper();
        public async Task<IActionResult> Index(string Subject)
        {

            List<Class9ViewModel> LsClass10QuiezDetails = new List<Class9ViewModel>();

            LsClass10QuiezDetails =  await _Class10Helper.GetClass10QuiezDetailsBySubjectId(LsClass10QuiezDetails ,Subject);


            return View(LsClass10QuiezDetails);
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClass10(Class9ViewModel data)
        {

            try
            {
                if (data != null)
                {
                   await _Class10Helper.InsertClass10QuiezDetails(Clas10QuizDetails:data);
                }

            }
            catch (Exception ex)
            {


            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddQuestion(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel Class10PaperDetails = new QuestionPepar10ViewModel();

            try
            {
                Class10PaperDetails.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {
                   
                    await _Class10Helper.FillQuestionPaperClaass10Details(Class10PaperDetails: Class10PaperDetails,PrimaryId:PrimaryId);
                }

                Class10PaperDetails.lsListQuestion = new List<QuestionPepar10ViewModel>();
                Class10PaperDetails.lsListQuestion = await _Class10Helper.FillQuestionpaperClass10DetailsById(LsQuestionDetais: Class10PaperDetails.lsListQuestion, Id: id);


            }
            catch (Exception ex)
            {

            }

            return View(Class10PaperDetails);

        }

     

        public async Task<IActionResult> QuestionAddForm20Details(QuestionPepar10ViewModel data)
        {
            try
            {


                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _Class10Helper.SavetblQuestionPeparEnglishClass10Details(QuestionDetails: data);    

                    }
                }
                else
                {

                    await _Class10Helper.UpdatetblQuestionPeparEnglishClass10Details(PrimaryId:data.PrimaryId, QuestionDetails: data);



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

                await _Class10Helper.DeletetblQuestionPeparEnglishClass10Details(PrimaryId: id);

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }

        public IActionResult TestOnline(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsClass10Details = new List<Class9QuestionSetViewModel>();

            LsClass10Details = _Class10Helper.GetClass10QuestionSetDetailsBySubjectName(LsClass10Details, SubjectName);
         


            return View(LsClass10Details);
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


                    TblClass10EnglisgTestFinalDetail finalResute = new TblClass10EnglisgTestFinalDetail();


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




                    await _Class10Helper.SavetblClass10EnglisgTestFinalDetails(finalResute: finalResute);




                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }

         

                if (String.IsNullOrEmpty(test11.FinalTest) == false)
                {
                 
                    List<TblClass10EnglisgTestFinalDetail> LsClass10EnglisgTestFinalDetails = new List<TblClass10EnglisgTestFinalDetail>();

                    LsClass10EnglisgTestFinalDetails= await _Class10Helper.GetClass10EnglishTest20Details(LsClass10EnglisgTestFinalDetails: LsClass10EnglisgTestFinalDetails);




                    string TestIndexId = await _Class10Helper.SaveTestSeriesClass10Details(Class10TestSeriesDetails: test11);

                    await _Class10Helper.UpdateBPSCClassEnlishFinalTestDetails(TestIndexId: TestIndexId, LsClass10EnglisgTestFinalDetails: LsClass10EnglisgTestFinalDetails);
               

                    return RedirectToAction("ResultDetails", "CLass10", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
                List<TblQuestionPeparEnglishClass10Detail> Class10QuestionDetails = new List<TblQuestionPeparEnglishClass10Detail>();

                Class10QuestionDetails = await _Class10Helper.GetClass10QuestionDetailsByConnectedQuestion(ConnectedQuestion: id);
              
                    lsdata.QuizName = Class10QuestionDetails.Where(x => x.QuezIndexId == id).Select(x => x.QuezName).FirstOrDefault() ?? "";
                  
                if (testa == 0)
                    {

                        if (Class10QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class10QuestionDetails)
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
                    Class10QuestionDetails = Class10QuestionDetails.Where(x => x.Id == testa).ToList();
                    if (Class10QuestionDetails.Count() > 0)
                        {
                            foreach (var item in Class10QuestionDetails)
                            {
                                if (Class10QuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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

            List<ResultDetailsViewModel> LsClass10EnglishTestResult = new List<ResultDetailsViewModel>();

            LsClass10EnglishTestResult = await _Class10Helper.GetClass10EnglishTestFinalResultDetails(LsClass10EnglishTestResult, id);

         

            return View("ResultDetails", LsClass10EnglishTestResult);
        }






    }
}
