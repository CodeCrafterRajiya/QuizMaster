namespace quezemasterNew.Models.ViewModel
{
    public class QuestionPepar10ViewModel
    {
        public int Id { get; set; }
        public int PrimaryId { get; set; }
        public string? QuestionNo { get; set; } = "";
        public string? AnswerA { get; set; } = "";
        public string? AnswerB { get; set; } = "";
        public string? AnswerC { get; set; } = "";
        public string? AnswerE { get; set; } = "";
        public string? AnswerD { get; set; } = "";
        public string? CurrectAnswer { get; set; }
        public string? Remark { get; set; } = "";
        public string? Remark1 { get; set; } = "";
        public string? Remark2 { get; set; } = "";
        public string? Remark3 { get; set; } = "";
        public string? Remark4 { get; set; } = "";
        public string? Remark5 { get; set; } = "";
        public int? ConnectedQuestion { get; set; }




       public List<QuestionPepar10ViewModel> lsListQuestion = new List<QuestionPepar10ViewModel>();
    }
}
