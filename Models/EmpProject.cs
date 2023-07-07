using System;
using System.Collections.Generic;

namespace Timesheet_Project.Models
{
    public partial class EmpProject
    {
        public EmpProject()
        {
            TimesheetItems = new HashSet<TimesheetItem>();
        }

        public int ProjectId { get; set; }
        public int EmpId { get; set; }
        public string ProjectName { get; set; } = null!;

        public virtual Employee Emp { get; set; } = null!;
        public virtual ICollection<TimesheetItem> TimesheetItems { get; set; }
    }
}
