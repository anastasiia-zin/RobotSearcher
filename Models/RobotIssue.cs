namespace Models
{
    public class RobotIssue : BaseEntity
    {
        public Robot Robot { get; set; }
        public string RobotId { get; set; }
        public Issue Issue { get; set; }
        public string IssueId { get; set; }
    }
}