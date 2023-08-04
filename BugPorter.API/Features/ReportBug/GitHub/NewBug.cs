using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugPorter.API.Features.ReportBug.GitHub
{
    public class NewBug
    {
        public string Summary { get;  }
        public string Description { get; }

        public NewBug(string summary,string description )
        {
            Summary = summary;
            Description = description;
        }
    }
    public class ReportedBug
    {
        public string Id { get; }
        public string Summary { get; }
        public string Description { get; }
        public ReportedBug(string id, string summary, string description)
        {
            Id = id;
            Summary = summary;
            Description = description;
        }
    }
}
