using Timesheet_Project.Models;
using System.Globalization;

namespace Timesheet_Project.ViewModel
{
    public class TimesheetItemViewModel
    {
        public TimesheetItemViewModel(TimesheetItem item)
        {
            TimesheetId = item.TimesheetId;
            TimesheetItemId = item.TimesheetItemId;
            Date = item.Date;
            //Duration = item.Duration.Value;
            //Comment = item.Comment;
            ProjectId = item.ProjectId;
            //Color = item.Project.ColorCode;
            //EmpNumber = item.EmpNumber;
            //ActivityId = item.ActivityId;
            Week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(item.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            //ItemTitle = string.IsNullOrEmpty(item.Project.Initial) ? item.Project.Name : item.Project.Initial + " " + item.Activity.Name;
        }

        public int TimesheetItemId { get; set; }
        public int TimesheetId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Comment { get; set; }
        public int ProjectId { get; set; }
        public int EmpNumber { get; set; }
        public int ActivityId { get; set; }
        public int Week { get; set; }
        public string ItemTitle { get; set; }
        public string Color { get; set; }
    }
}

