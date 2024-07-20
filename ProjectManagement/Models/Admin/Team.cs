using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Admin
{
    public class Team
    {
        [Key]
        public int intTeamID { get; set; }
        public string strTeamName { get; set; }
    }
}
