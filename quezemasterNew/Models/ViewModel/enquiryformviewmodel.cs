using System.ComponentModel.DataAnnotations;

namespace quezemasterNew.Models.ViewModel
{
    public class enquiryformviewmodel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [MaxLength(12)]
        [MinLength(10)]
        public string? MobileNo { get; set; }

        public string? EmailId { get; set; }

        public string? Message { get; set; }

        public string? Remark { get; set; }

        public string? Remark1 { get; set; }

        public string? Remark2 { get; set; }

        public string? Remark3 { get; set; }

        public string? Remark4 { get; set; }

        public string? Remark5 { get; set; }

        public DateTime? DateTimeStamp { get; set; }
    }
}
