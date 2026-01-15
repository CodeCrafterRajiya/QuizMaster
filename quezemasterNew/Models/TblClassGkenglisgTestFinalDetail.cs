using System;
using System.Collections.Generic;

namespace quezemasterNew.Models;

public partial class TblClassGkenglisgTestFinalDetail
{
    public int TestId { get; set; }

    public string? QuestionNo { get; set; }

    public string? AnswerA { get; set; }

    public string? AnswerB { get; set; }

    public string? AnswerC { get; set; }

    public string? AnswerD { get; set; }

    public string? AnswerE { get; set; }

    public string? CurrectAnswer { get; set; }

    public int? ConnectedQuestion { get; set; }

    public int? TestQuestionId { get; set; }

    public string? CurrentUser { get; set; }

    public string? Remark { get; set; }

    public string? Remark1 { get; set; }

    public string? Remark2 { get; set; }

    public string? Remark3 { get; set; }

    public string? Remark4 { get; set; }

    public DateTime? DatetimeStamp { get; set; }

    public string? TestSerise { get; set; }
}
