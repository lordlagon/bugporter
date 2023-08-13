using Firebase.Auth;
using System.Net.Http.Headers;

namespace BugPorter.Client.Entities
{
    public class CurrentUserStore
    {
        public User CurrentUser { get; set; }
    }
}
