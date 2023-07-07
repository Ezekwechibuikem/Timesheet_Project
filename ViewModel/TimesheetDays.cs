namespace Timesheet_Project.ViewModel
{
    public class TimesheetDays
    {
        public int DayOfMonth { get; set; }
        public string DayOfWeek { get; set; }
        public int WeekOfMonth { get; set; }
        public int dayOfWeekIndex { get; set; }
        public int Onleave { get; set; }
        public int IsWeeked { get; set; }
        public int IsDayOff { get; set; }
        public DateTime Date { get; set; }
    }
}
