namespace ProjectManagement.Models.Admin
{
    public class DateWiseReport
    {
        public int ID { get; set; }
        public int intUserID { get; set; }
        public string strUserName { get; set; }
        public DateTime dteInsertDate { get; set; }
        public TimeSpan tmWorking { get; set; }
    }
}
