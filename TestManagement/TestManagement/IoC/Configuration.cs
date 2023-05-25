using CQS.Command;
using CQS.Command.Question;
using CQS.Command.Student;
using CQS.Command.Test;
using CQS.Queries;
using CQS.Queries.McQuestion;
using CQS.Queries.OpenQuestion;
using CQS.Queries.Question;
using CQS.Queries.Student;
using CQS.Queries.Test;
using Infrastructure.CommandHandlers;
using Infrastructure.CommandHandlers.Question;
using Infrastructure.CommandHandlers.Student;
using Infrastructure.CommandHandlers.Test;
using Infrastructure.Context;
using Infrastructure.QueriesHandlers.McQuestion;
using Infrastructure.QueriesHandlers.OpenQuestion;
using Infrastructure.QueriesHandlers.Question;
using Infrastructure.QueriesHandlers.Student;
using Infrastructure.QueriesHandlers.Test;
using Ninject.Modules;

namespace TestManagement.IoC
{
    public class Configuration : NinjectModule
    {
        public override void Load()
        {
            // Infrastructure
            Bind<IQueryFactory>().ToMethod(t => new QueryFactory(x => Container.Current.Resolve(x))).InTransientScope();
            Bind<ICommandsFactory>()
                .ToMethod(t => new CommandFactory(x => (object[])Container.Current.ResolveAll(x)))
                .InTransientScope();

            // DbContext
            Bind<TestManagementDbContext>().ToSelf().WithConstructorArgument("connectionString", "MyContext");

            // Queries
            Bind<IGetMcQuestionById>().To<GetMcQuestionById>().InTransientScope();
            Bind<IGetMcQuestions>().To<GetMcQuestions>().InTransientScope();
            Bind<IGetOpenQuestionById>().To<GetOpenQuestionById>().InTransientScope();
            Bind<IGetOpenQuestions>().To<GetOpenQuestions>().InTransientScope();
            Bind<IGetAllQuestionsFromTest>().To<GetAllQuestionsFromTest>().InTransientScope();
            Bind<IGetQuestionById>().To<GetQuestionById>().InTransientScope();
            Bind<IGetQuestions>().To<GetQuestions>().InTransientScope();
            Bind<IGetStudentById>().To<GetStudentById>().InTransientScope();
            Bind<IGetStudents>().To<GetStudents>().InTransientScope();
            Bind<IGetAllGradedTests>().To<GetAllGradedTests>().InTransientScope();
            Bind<IGetAllTests>().To<GetAllTests>().InTransientScope();
            Bind<IGetTestById>().To<GetTestById>().InTransientScope();

            // Commands
            Bind<ICommandHandler<AddQuestionToTestCommand>>().To<AddQuestionToTestCommandHandler>().InTransientScope();
            Bind<ICommandHandler<CreateQuestionCommand>>().To<CreateQuestionCommandHandler>().InTransientScope();
            Bind<ICommandHandler<RemoveQuestionFromTestCommand>>().To<RemoveQuestionFromTestCommandHandler>()
                .InTransientScope();
            Bind<ICommandHandler<AddTestToStudentCommand>>().To<AddTestToStudentCommandHandler>().InTransientScope();
            Bind<ICommandHandler<CreateStudentCommand>>().To<CreateStudentCommandHandler>().InTransientScope();
            Bind<ICommandHandler<CreateTestCommand>>().To<CreateTestCommandHandler>().InTransientScope();
            Bind<ICommandHandler<DeleteTestCommand>>().To<DeleteTestCommandHandler>().InTransientScope();
            Bind<ICommandHandler<ReviewTestCommand>>().To<ReviewTestCommandHandler>().InTransientScope();
        }
    }
}