﻿namespace TestManagement.CQS.Queries.McQuestion;

public interface IGetMcQuestions
{
    IEnumerable<Domain.Questions.McQuestion> Excecute();
}