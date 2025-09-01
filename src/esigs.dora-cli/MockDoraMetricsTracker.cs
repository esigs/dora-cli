using System;
using esigs.dora.iface;

namespace esigs.dora_cli
{
    public class MockDoraMetricsTracker : IDoraMetricsTracker
    {
        public Result RecordDeployment(DateTime timestamp, bool success, TimeSpan leadTime)
        {
            Console.WriteLine($"[Mock] Recording Deployment: Timestamp={timestamp}, Success={success}, LeadTime={leadTime}");
            return Result.Success();
        }

        public Result RecordIncident(DateTime startTime, DateTime endTime)
        {
            Console.WriteLine($"[Mock] Recording Incident: StartTime={startTime}, EndTime={endTime}");
            return Result.Success();
        }

        public Result<double> GetDeploymentFrequency(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine($"[Mock] Getting Deployment Frequency: StartDate={startDate}, EndDate={endDate}");
            return Result<double>.Success(1.5); // Mock value
        }

        public Result<TimeSpan> GetLeadTimeForChanges(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine($"[Mock] Getting Lead Time For Changes: StartDate={startDate}, EndDate={endDate}");
            return Result<TimeSpan>.Success(TimeSpan.FromHours(24)); // Mock value
        }

        public Result<double> GetChangeFailureRate(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine($"[Mock] Getting Change Failure Rate: StartDate={startDate}, EndDate={endDate}");
            return Result<double>.Success(0.1); // Mock value
        }

        public Result<TimeSpan> GetMeanTimeToRecovery(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine($"[Mock] Getting Mean Time To Recovery: StartDate={startDate}, EndDate={endDate}");
            return Result<TimeSpan>.Success(TimeSpan.FromHours(12)); // Mock value
        }
    }
}
