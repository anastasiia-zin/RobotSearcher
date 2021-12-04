namespace Models
{
    public class CategoryRobot : BaseEntity
    {
        public Robot Robot { get; set; }
        public string RobotId { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
    }
}