using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
    public class BPSCEnglishController : Controller
    {

        BPSCEnglishPageHelper BPSCHelper = new BPSCEnglishPageHelper();


        public async Task<IActionResult> Index(string Subject)
        {

            List<Class9ViewModel> LsCass9Records = new List<Class9ViewModel>();

            try
            {

                LsCass9Records = await BPSCHelper.GetBPSCSaveDetails(LsCass9Records, SubjectName: Subject);

            }
            catch (Exception ex)
            {

            }

            return View(LsCass9Records);
            //Class9ViewModel BPSCDetails = new Class9ViewModel();
            //BPSCDetails.SubjectName = Subject;
            //return View(BPSCDetails);
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> InsertClassBPSC(Class9ViewModel data)
        {

            try
            {
                if(data!=null)
                {
                    await BPSCHelper.SaveBPSCRecords(BPSCData:data);
                }
          
               
            }
            catch (Exception ex)
            {


            }

            return RedirectToAction("Index",new { Subject = data?.SubjectName});
        }

      

        public async Task<IActionResult> AddQuestion(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel isdata = new QuestionPepar10ViewModel();

            try
            {

                isdata.ConnectedQuestion = id;

                 await BPSCHelper.FillQuestionPaperEnglishClassBPSCDetails(BPSCDetails:isdata, PrimaryId:PrimaryId);


                isdata.lsListQuestion = new List<QuestionPepar10ViewModel>();

                isdata.lsListQuestion = await BPSCHelper.FillQnPaperEngClassBPSCDetailsByConnectedQuestion(ConnectedQuestion: id);
     
            }
            catch (Exception ex)
            {

            }

            return View(isdata);

        }

        public async Task<IActionResult> QuestionAddForm20Details(QuestionPepar10ViewModel data)
        {
            try
            {


                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await BPSCHelper.SaveBPSCClassEnglishQuestionPaper(QuestionPaperData:data);
                        

                    }
                }
                else
                {
           
                    await BPSCHelper.UpdateBPSCClassEnglishQuestionPaperDetails(data);

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
                if(id!=0)
                {
                    await BPSCHelper.DeleteTblQuestionPaperBPSCDetails(PrimaryId: id);
                }
        

            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("AddQuestion", new { id = ConnectionId });
        }

     
        public async Task<IActionResult> TestOnline(string SubjectName)
        {

            List<Class9QuestionSetViewModel> LsOnlineTestRecords = new List<Class9QuestionSetViewModel>();

            try
            {
                LsOnlineTestRecords = await BPSCHelper.GetOnlineTestDetails(LsOnlineTestRecords, SubjectName: SubjectName);
      
            }
            catch (Exception ex)
            {


            }


            return View(LsOnlineTestRecords);
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


                    TblClassGkenglisgTestFinalDetail finalResute = new TblClassGkenglisgTestFinalDetail();


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
                            if (Answer[0] == "E")
                            {
                                finalResute.AnswerE = Answer[1].ToString().Trim();
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
                    else if ((String.IsNullOrEmpty(finalResute.AnswerE) == false))
                    {
                        if (finalResute.AnswerE == test11.CurrectAnswer)
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
                    if (String.IsNullOrEmpty(finalResute.AnswerE) == true)
                    {
                        finalResute.AnswerE = "";
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


             

                    await BPSCHelper.SaveGKEnglishTestFinalDetails(GKTestDetails: finalResute);

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }

             

                if (String.IsNullOrEmpty(test11.FinalTest) == false)
                {
                    List<TblClassBpscenglisgTestFinalDetail> QuestionDetails = new List<TblClassBpscenglisgTestFinalDetail>();
                    QuestionDetails = await BPSCHelper.GetBPSCEnglishTestDetails(); 


                  string TestIndexId =  await BPSCHelper.SaveTestSeriesClassBPSCDetails(TestSeriesDetails:test11);

                    await BPSCHelper.UpdateBPSCClassEnlishFinalTestDetails(TestIndexId: TestIndexId, LsTestDetails: QuestionDetails);
               

                    return RedirectToAction("ResultDetails", "CLassBPSC", new { id = TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
          
                List<TblQuestionPeparEnglishClassBpscdetail> BPSCQuestionDetails = new List<TblQuestionPeparEnglishClassBpscdetail>();

                BPSCQuestionDetails = await BPSCHelper.GetBPSCQuestionDetailsByConnectedQuestion(ConnectedQuestion: id);

                lsdata.QuizName = BPSCQuestionDetails.Where(x => x.QuezIndexId == id).Select(x=>x.QuezName).FirstOrDefault() ?? "";
                if (testa == 0)
                    {
               
                        if (BPSCQuestionDetails.Count() > 0)
                        {
                            foreach (var item in BPSCQuestionDetails)
                            {
                                lsdata.TestId = item.Id;
                                lsdata.QuestionId = item.Id;
                                lsdata.QuestionNo = item.QuestionNo;
                                lsdata.AnswerA = item.AnswerA;
                                lsdata.AnswerB = item.AnswerB;
                                lsdata.AnswerC = item.AnswerC;
                                lsdata.AnswerE = item.AnswerE;
                                lsdata.CurrectAnswer = item.CurrectAnswer;
                                lsdata.AnswerD = item.AnswerD;
                                lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);
                                break;
                            }
                        }

                    }
                    else
                    {
                    BPSCQuestionDetails = BPSCQuestionDetails.Where(x => x.Id == testa).ToList();
                        if (BPSCQuestionDetails.Count() > 0)
                        {
                            foreach (var item in BPSCQuestionDetails)
                            {
                                if (BPSCQuestionDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo;
                                    lsdata.AnswerA = item.AnswerA;
                                    lsdata.CurrectAnswer = item.CurrectAnswer;
                                    lsdata.AnswerB = item.AnswerB;
                                    lsdata.AnswerC = item.AnswerC;
                                    lsdata.AnswerD = item.AnswerD;
                                    lsdata.AnswerE = item.AnswerE;
                                    lsdata.FinalTest = "Final Test";
                                    lsdata.ConnectionQuestion = Convert.ToInt32(item.ConnectedQuestion);

                                    break;

                                }
                                else
                                {
                                    lsdata.TestId = item.Id;
                                    lsdata.QuestionId = item.Id;
                                    lsdata.QuestionNo = item.QuestionNo ??"";
                                    lsdata.AnswerA = item.AnswerA ?? "";
                                    lsdata.AnswerB = item.AnswerB ?? "";
                                    lsdata.AnswerC = item.AnswerC ?? "";
                                    lsdata.AnswerE = item.AnswerE ?? "";
                                    lsdata.CurrectAnswer = item.CurrectAnswer ?? "";
                                    lsdata.AnswerD = item.AnswerD ?? "";
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

            List<ResultDetailsViewModel> LsBPSCTestSeriesResult = new List<ResultDetailsViewModel>();
            try
            {

                LsBPSCTestSeriesResult = await BPSCHelper.FillBPSCTestSeriesDetails(TestIndexId:id, LsBPSCTestSeriesResult: LsBPSCTestSeriesResult);
               
            }
            catch (Exception ex)
            {

            }

            return View("ResultDetails", LsBPSCTestSeriesResult);
        }
    }
}
