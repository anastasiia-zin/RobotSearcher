using System.Collections.Generic;

namespace Models
{
    public class Issue : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RobotIssue> RobotIssues { get; set; }
    }
}