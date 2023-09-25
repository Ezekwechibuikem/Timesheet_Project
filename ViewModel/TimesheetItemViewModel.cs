using Timesheet_Project.Models;
using System.Globalization;

namespace Timesheet_Project.ViewModel
{
    public class TimesheetItemViewModel
    {
        //internal int EmpId;

        public TimesheetItemViewModel(TimesheetItem item)
        {
            TimesheetId = item.TimesheetId;
            TimesheetItemId = item.TimesheetItemId;
            Date = item.Date;
            WkDuration = item.WkDuration;
            //Comment = item.Comment;
            ProjectId = item.ProjectId;
            //Color = item.Project.ColorCode;
            //EmpNumber = item.EmpNumber;
            //ActivityId = item.ActivityId;
            EmpId = item.EmpId;
            //Week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(item.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            //ItemTitle = string.IsNullOrEmpty(item.Project.Initial) ? item.Project.Name : item.Project.Initial + " " + item.Activity.Name;
        }

        public int TimesheetItemId { get; set; }
        public int TimesheetId { get; set; }
        public DateTime Date { get; set; }
        public int WkDuration { get; set; }
        public string Comment { get; set; }
        public int ProjectId { get; set; }
        public int EmpId { get; set; }
        //public int ActivityId { get; set; }
        //public int Week { get; set; }
        //public string ItemTitle { get; set; }
        //public string Color { get; set; }
    }
}

