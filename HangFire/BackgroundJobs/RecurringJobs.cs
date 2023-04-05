using Hangfire;
using System.ComponentModel;
using System.Diagnostics;

namespace HangFire.BackgroundJobs
{
    public class RecurringJobs
    {

        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(), "*/2 * * * * *");

        }

        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, email olarak gönderildi");
        }


    }
}
