using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Task
{
    public class TransferUser
    {
        [Key]
        public int intUserID { get; set; }
        public string strUserName { get; set; }
    }
}
