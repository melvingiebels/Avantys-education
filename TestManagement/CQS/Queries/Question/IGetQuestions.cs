﻿namespace CQS.Queries.Question;

public interface IGetQuestions
{
    IEnumerable<Domain.Questions.Question> Excecute();
}