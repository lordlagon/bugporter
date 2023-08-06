using Refit;

namespace BugPorter.Client.Features
{
    public interface IReportBugApiCommand
    {
        [Post("/bugs")]
        Task<ReportedBugResponse> Execute([Body(buffered: true)] ReportedBugRequest bug);
    }
}
