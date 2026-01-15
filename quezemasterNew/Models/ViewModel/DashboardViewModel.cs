namespace quezemasterNew.Models.ViewModel
{
    public class DashboardViewModel
    {
        public int QuizeNumber { get; set; }
        public string QuizeName { get; set; }

        public List<quizeDashboard> lsquize = new List<quizeDashboard>();
    }



    public class quizeDashboard
    {
        public int QuizeNumber { get; set; }
        public string QuizeName { get; set; } = "";
    }

}
