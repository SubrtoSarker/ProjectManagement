using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Task
{
    public class Notify
    {
        [Key]
        public int ID { get; set; }
        public string Msg { get; set; }
        public Boolean isNew { get; set; }
    }
}
