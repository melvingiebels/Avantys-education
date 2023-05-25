using TestManagement.CQS.Command;
using TestManagement.CQS.Command.Question;
using TestManagement.CQS.Command.Student;
using TestManagement.CQS.Command.Test;
using TestManagement.CQS.Queries;
using TestManagement.CQS.Queries.McQuestion;
using TestManagement.CQS.Queries.OpenQuestion;
using TestManagement.CQS.Queries.Question;
using TestManagement.CQS.Queries.Student;
using TestManagement.CQS.Queries.Test;
using TestManagement.Infrastructure.CommandHandlers;
using TestManagement.Infrastructure.CommandHandlers.Question;
using TestManagement.Infrastructure.CommandHandlers.Student;
using TestManagement.Infrastructure.CommandHandlers.Test;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.QueriesHandlers.McQuestion;
using TestManagement.Infrastructure.QueriesHandlers.OpenQuestion;
using TestManagement.Infrastructure.QueriesHandlers.Question;
using TestManagement.Infrastructure.QueriesHandlers.Student;
using TestManagement.Infrastructure.QueriesHandlers.Test;
using Ninject.Modules;

namespace TestManagement.IoC
{
    public class Configuration : NinjectModule
    {
        public override void Load()
        {
            // TestManagement.Infrastructure
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