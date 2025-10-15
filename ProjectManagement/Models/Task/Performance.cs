﻿using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Task
{
    public class Performance
    {
        [Key]
        public int intTaskID { get; set; }
        public string strTaskName { get; set; }
        public string strDescription { get; set; }
        public string strRequestFrom { get; set; }
        public string strProjectName { get; set; }
        public TimeSpan tmWorking { get; set; }
        public Decimal WorkPercent { get; set; }
        public string AssignedTo { get; set; }
        public Decimal TeamWorkPercent { get; set; }

    }
}
