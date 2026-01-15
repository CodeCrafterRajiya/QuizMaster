using System;
using System.Collections.Generic;

namespace quezemasterNew.Models;

public partial class TblTestSiriseClass12Detail
{
    public string TestIndexId { get; set; } = null!;

    public int? TestSerisId { get; set; }

    public string? TestName { get; set; }

    public int? QuestionConnectionId { get; set; }

    public DateTime? DateTimeStamp { get; set; }

    public string? Remark { get; set; }

    public string? Remark1 { get; set; }

    public string? Remark2 { get; set; }

    public string? Remark3 { get; set; }
}
