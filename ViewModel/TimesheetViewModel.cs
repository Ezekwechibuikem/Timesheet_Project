using Timesheet_Project.Models;

namespace Timesheet_Project.ViewModel
{

    public class TimesheetModel
    {
        public List<TimesheetItemViewModel> TimesheetItem { get; set; }
        public Timesheet Timesheet { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public List<TimesheetDays> TimesheetDays { get; set; }
        public int FirstWeek { get; set; }
        public int LastWeek { get; set; }
    }

   
    public class MonthItem
    {
        public string Name { set; get; }
        public string Value { set; get; }
    }

    public class TimeSheetO
    {
        public string EmployeeName { get; set; }
        public int EmpNumber { get; set; }
        public string Designation { get; set; }
        public List<TimesheetProjects> Projects { get; set; }
    }

    public class TimesheetProjects
    {
        public int ProjectId { get; set; }
        public int Duration { get; set; }
    }
    public class TimesheetProjectNames
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
