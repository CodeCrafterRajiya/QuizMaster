using Microsoft.AspNetCore.Mvc;
using quezemasterNew.BussinesLogic;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel;
using System.Threading.Tasks;


namespace quezemasterNew.Controllers
{
    public class QuestionPeparController : Controller
    {
   

        QuestionPeparHelper _QustPaperHelper = new QuestionPeparHelper();
        public async Task<IActionResult> Index(int id, int PrimaryId)
        {
            QuestionPepar10ViewModel isdata = new QuestionPepar10ViewModel();

            try
            {

                isdata.ConnectedQuestion = id;
                if (PrimaryId > 0)
                {
                    TblQuestionPeparEnglish20Detail QuestionPaperDetails = new TblQuestionPeparEnglish20Detail();
                    await _QustPaperHelper.FillQuestionPaperDetailsById(PrimaryId, QuestionPaperDetails: QuestionPaperDetails);
                    if(QuestionPaperDetails != null)
                    {
                        isdata.PrimaryId = QuestionPaperDetails.Id;
                        isdata.QuestionNo = QuestionPaperDetails.QuestionNo;
                        isdata.AnswerA = QuestionPaperDetails.AnswerA;
                        isdata.AnswerB = QuestionPaperDetails.AnswerB;
                        isdata.CurrectAnswer = QuestionPaperDetails.CurrectAnswer;
                        isdata.AnswerD = QuestionPaperDetails.AnswerD;
                        isdata.AnswerC = QuestionPaperDetails.AnswerC;
                        isdata.ConnectedQuestion = QuestionPaperDetails.ConnectedQuestion;
                    }

                }


                List<TblQuestionPeparEnglish20Detail> LsQuestionPaperDetails = new List<TblQuestionPeparEnglish20Detail>();

                LsQuestionPaperDetails = await _QustPaperHelper.FillQuestionPaperDetilsByConnectedQuestionId(PrimaryId: id);

                isdata.lsListQuestion = new List<QuestionPepar10ViewModel>();

                foreach (var item in LsQuestionPaperDetails)
                {
                    QuestionPepar10ViewModel lsdata = new QuestionPepar10ViewModel();
                    lsdata.Id = item.Id;
                    lsdata.AnswerC = item.AnswerC;
                    lsdata.AnswerD = item.AnswerD;
                    lsdata.AnswerA = item.AnswerA;
                    lsdata.AnswerB = item.AnswerB;
                    lsdata.CurrectAnswer = item.CurrectAnswer;
                    lsdata.QuestionNo = item.QuestionNo;
                    lsdata.ConnectedQuestion = item.ConnectedQuestion;

                    isdata.lsListQuestion.Add(lsdata);

                }
            }
            catch (Exception ex)
            {


            }


            return View(isdata);
        }


        public async Task<IActionResult> QuestionAddForm10DetailsAsync(QuestionPepar10ViewModel data)
        {
            try
            {

                if (data.PrimaryId == 0)
                {
                    if (data.QuestionNo != null)
                    {

                        await _QustPaperHelper.SaveTblQuestionPeparEnglish20Detail(QuestionDetails: data);

                    }
                }
                else
                {


                    await _QustPaperHelper.UpdateTblQuestionPeparEnglish20Detail(QuestionDetails: data);

                }

                
            }
            catch (Exception ex)
            {


            }

            return RedirectToAction("Index", new { id = data.ConnectedQuestion });
        }


        public async Task<IActionResult> DeleteQuestion10Async(int id, int ConnectionId)
        {
            try
            {

                if (id > 0)
                {
                    await _QustPaperHelper.DeletetblQuestionPeparEnglish20Details(PrimaryId: id);
                }
            }
            catch (Exception EX)
            {
            }
            return RedirectToAction("Index", new { id = ConnectionId });
        }



    }
}
