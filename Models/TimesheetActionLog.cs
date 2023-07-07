using System;
using System.Collections.Generic;

namespace Timesheet_Project.Models
{
    public partial class TimesheetActionLog
    {
        public int TimesheetActionLogId { get; set; }
        public int TimesheetId { get; set; }
        public DateTime DateTime { get; set; }
        public int PerformedBy { get; set; }
        public string? Comment { get; set; }
        public string? Action { get; set; }

        public virtual Timesheet Timesheet { get; set; } = null!;
    }
}
