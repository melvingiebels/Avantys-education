﻿namespace CQS.Queries.OpenQuestion;

public interface IGetOpenQuestions
{
    IEnumerable<Domain.Questions.OpenQuestion> Excecute();
}