namespace quezemasterNew.Models.ViewModel
{
    public class ResultDetailsViewModel
    {
        public int SRNumber { get; set; } = 0;
        public string Name { get; set; } = "";
            public string Data { get; set; } = "";
        public string Question { get; set; } = "";
            public string AnsswerA { get; set; } = "";
        public string AnsswerB { get; set; } = "";
            public string AnsswerC { get; set; } = "";
        public string AnsswerD { get; set; } = "";
        public string AnsswerE { get; set; } = "";
            public string CurrectAnsawer { get; set; } = "";
        public int TotalCurrectAnswer { get; set; } = 0;
        
    }
}
