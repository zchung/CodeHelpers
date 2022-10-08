using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Models.Constants
{
    public class ErrorConstants
    {
        public static string Error = $"Error:{Constants.Prefix}_";

        public static EventId ErrorExample = new EventId(1, $"{Error}1");
    }
}