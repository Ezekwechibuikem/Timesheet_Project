using System;
using System.Collections.Generic;

namespace Timesheet_Project.Models
{
    public partial class Timesheet
    {
        public Timesheet()
        {
            TimesheetActionLogs = new HashSet<TimesheetActionLog>();
            TimesheetItems = new HashSet<TimesheetItem>();
        }

        public int TimesheetId { get; set; }
        public int EmpId { get; set; }
        public string State { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Employee Emp { get; set; } = null!;
        public virtual ICollection<TimesheetActionLog> TimesheetActionLogs { get; set; }
        public virtual ICollection<TimesheetItem> TimesheetItems { get; set; }
    }
}
