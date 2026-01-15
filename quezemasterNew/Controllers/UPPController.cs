using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using quezemasterNew.BussinesLogic;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.UPPViewModel;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Data;

namespace quezemasterNew.Controllers
{
    public class UPPController : Controller
    {
        QuizeMasterNewContext _context = new QuizeMasterNewContext();
        UPPHelper _UppHelper = new UPPHelper();
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Onlinetest()
        {

            List<UppQuestionSetViewModel> LsData = new List<UppQuestionSetViewModel>();

            LsData = await _UppHelper.GetUPPQuizRecords(LsQuizDetails:LsData);
          
            

            return View(LsData);
        }

        public IActionResult UppOnlineTest()
        {
            UppQuestionSetViewModel lsdata = new UppQuestionSetViewModel();




            return View(lsdata);
        }



        SqlConnection sqlCon = null;

        public IActionResult TestingData(int id, Test10DetailsViewModel test11)
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


                    Tbl20englisgTestFinalDetail finalResute = new Tbl20englisgTestFinalDetail();

                    
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
                    if(string.IsNullOrEmpty(currentuser) == false)
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

                    
                    using (sqlCon = new SqlConnection(ConnectionString.Connection))
                    {
                        var Tbl20Engilsh = $"Select * from Tbl_QuestionPeparEnglish20Details";

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("spTbl_20EnglishTestFinalDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuestionNo", finalResute.QuestionNo);
                        sql_cmnd.Parameters.AddWithValue("@AnswerA", finalResute.AnswerA);
                        sql_cmnd.Parameters.AddWithValue("@AnswerB", finalResute.AnswerB);
                        sql_cmnd.Parameters.AddWithValue("@AnswerC", finalResute.AnswerC);
                        sql_cmnd.Parameters.AddWithValue("@AnswerD", finalResute.AnswerD);
                        sql_cmnd.Parameters.AddWithValue("@CurrectAnswer", finalResute.CurrectAnswer);
                        sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", finalResute.ConnectedQuestion);
                        sql_cmnd.Parameters.AddWithValue("@TestQuestionId", finalResute.TestQuestionId);
                        sql_cmnd.Parameters.AddWithValue("@CurrentUser", finalResute.CurrentUser);
                        sql_cmnd.Parameters.AddWithValue("@Remark", finalResute.Remark);
                        sql_cmnd.Parameters.AddWithValue("@Remark1", finalResute.Remark1);
                        sql_cmnd.Parameters.AddWithValue("@Remark2", finalResute.Remark2);
                        sql_cmnd.Parameters.AddWithValue("@Remark3", finalResute.Remark3);
                        sql_cmnd.Parameters.AddWithValue("@Remark4", finalResute.Remark4);
                        sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", finalResute.DatetimeStamp);
                        sql_cmnd.Parameters.AddWithValue("@TestSerise", finalResute.TestSerise);
                        
                        sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();
                    }

                    id = test11.ConnectionQuestion;
                    testa = test11.TestId + 1;
                }

               // _context.Tbl20englisgTestFinalDetails.Add(finalResute);
                 //   _context.SaveChanges();


                if (String.IsNullOrEmpty(test11.FinalTest) == false)
                {

                    var QuestionDetails = _context.Tbl20englisgTestFinalDetails.OrderByDescending(x => x.DatetimeStamp)./*Where(x => x.TestQuestionId == test11.TestId)*/Take(20).ToList();

                    TblTestSiriseDetail tblTestSiriseDetail = new TblTestSiriseDetail();
                    tblTestSiriseDetail.TestIndexId = Guid.NewGuid().ToString();
                    tblTestSiriseDetail.TestName = test11.QuizName;
                    tblTestSiriseDetail.QuestionConnectionId = test11.ConnectionQuestion;
                    tblTestSiriseDetail.TestName = test11.QuizName;
                    tblTestSiriseDetail.TestSerisId = test11.TestId;
                    tblTestSiriseDetail.DateTimeStamp = DateTime.Now;

                    _context.TblTestSiriseDetails.Add(tblTestSiriseDetail);
                    _context.SaveChanges();

                    foreach (var item in QuestionDetails)
                    {
                        item.TestSerise = tblTestSiriseDetail.TestIndexId;
                        _context.SaveChanges();
                    }

                    return RedirectToAction("ResultDetails", "UPP", new { id = tblTestSiriseDetail.TestIndexId });
                }

            }
            catch (Exception ex)
            {


            }
            ModelState.Clear();
            Test10DetailsViewModel lsdata = new Test10DetailsViewModel();

            try
            {
                var test1 = _context.TblQuezIndex20Details.Where(x => x.Id == id).FirstOrDefault();
                if (test1 != null)
                {
                    lsdata.QuizName = test1.QuezName;
                    var questionList = _context.TblQuestionPeparEnglish20Details.OrderBy(x => x.Id).Where(x => x.ConnectedQuestion == test1.Id).ToList();
                    if (testa == 0)
                    {

                        if (questionList.Count() > 0)
                        {
                            foreach (var item in questionList)
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
                        var questionList1 = questionList.Where(x => x.Id == testa && x.ConnectedQuestion == test1.Id).ToList();
                        if (questionList1.Count() > 0)
                        {
                            foreach (var item in questionList1)
                            {
                                if (questionList.OrderByDescending(x => x.Id).FirstOrDefault().Id == item.Id)
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
            }
            catch (Exception ex)
            {


            }


            return View("TestingData", lsdata);
        }


        public async Task<IActionResult> ResultDetails(string id)
        {

            List<ResultDetailsViewModel> LsResult = new List<ResultDetailsViewModel>();

            LsResult = await _UppHelper.ResultDetailsByTestIndexId(LsResult: LsResult, TestSeriseId:id);
            return View("ResultDetails", LsResult);
        }

    }

    

}
