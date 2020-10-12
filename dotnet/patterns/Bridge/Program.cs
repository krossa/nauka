using System;
using System.Text;
using Bridge.Pattern.BridgePatternApproach;
using Bridge.Pattern.NaiveApproach;
using TimeEntry = Bridge.Pattern.NaiveApproach.TimeEntry;
//https://medium.com/net-core/how-to-avoid-exponential-growth-of-classes-by-applying-bridge-pattern-in-c-2d437e203f82
namespace Bridge.Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            NaiveApproachRun();
            Console.WriteLine();
            BridgeApproach();
            Console.ReadKey();
        }

        private static void NaiveApproachRun()
        {
            var approvedDurationOnlyTimeEntry = new Bridge.Pattern.NaiveApproach.ApprovedDurationOnlyTimeEntry("bugfixing", TimeSpan.FromHours(2), "Roger", "Karen");
            var bannedDurationOnlyTimeEntry = new Bridge.Pattern.NaiveApproach.BannedDurationOnlyTimeEntry("smoke breaking", TimeSpan.FromHours(2), "Roger", "Karen");
            var approvedSpecificRangeTimeEntry = new Bridge.Pattern.NaiveApproach.ApprovedSpecificTimeRangeTimeEntry("creating new feature", "Levi", DateTime.Now.AddHours(-1), DateTime.Now, "Lucas");
            var bannedSpecificTimeRangeTimeEntry = new Bridge.Pattern.NaiveApproach.BannedSpecificTimeRangeTimeEntry("toilet breaking", "Levi", DateTime.Now.AddHours(-1), DateTime.Now, "Lucas");

            Console.Write(CreateBossReport(approvedDurationOnlyTimeEntry, bannedDurationOnlyTimeEntry, approvedSpecificRangeTimeEntry, bannedSpecificTimeRangeTimeEntry));
        }

        private static void BridgeApproach()
        {
            var approvedDurationOnlyTimeEntry = new Bridge.Pattern.BridgePatternApproach
                 .DurationOnlyTimeEntry("bugfixing", TimeSpan.FromHours(2), "Roger", new ApprovingAuthority("Karen"));

            var bannedDurationOnlyTimeEntry = new Bridge.Pattern.BridgePatternApproach
               .DurationOnlyTimeEntry("taking smoke break", TimeSpan.FromHours(2), "Roger", new BanningAuthority("Karen"));

            var approvedSpecificRangeTimeEntry = new Bridge.Pattern.BridgePatternApproach
               .SpecificRangeTimeEntry("creating new feature", "Levi", DateTime.Now.AddHours(-1), DateTime.Now, new ApprovingAuthority("Lucas"));

            var bannedSpecificTimeRangeTimeEntry = new Bridge.Pattern.BridgePatternApproach
               .SpecificRangeTimeEntry("taking toilet break", "Levi", DateTime.Now.AddHours(-1), DateTime.Now, new BanningAuthority("Lucas"));

            Console.Write(CreateBossReport(approvedDurationOnlyTimeEntry, bannedDurationOnlyTimeEntry, approvedSpecificRangeTimeEntry, bannedSpecificTimeRangeTimeEntry));
        }


        public static string CreateBossReport(params TimeEntry[] timeEntries)
        {
            var report = new StringBuilder();
            foreach (var timeEntry in timeEntries)
            {
                report.AppendLine(timeEntry.GetBossReportsRow());
            }

            return report.ToString();
        }
        public static string CreateBossReport(params Bridge.Pattern.BridgePatternApproach.TimeEntry[] timeEntries)
        {
            var report = new StringBuilder();
            foreach (var timeEntry in timeEntries)
            {
                report.AppendLine(timeEntry.GetBossReportRow());
            }

            return report.ToString();
        }
    }
}
