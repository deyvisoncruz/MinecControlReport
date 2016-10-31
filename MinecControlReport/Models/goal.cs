using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Linq;
using System.Web;


namespace MinecControlReport.Models
{
    public class goal
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public String Name { get; set; }



        public int KpiId { get; set; }

        [ForeignKey("KpiId")]
        public kpis kpi { get; set; }

        public int PeriodTimeId { get; set; }

        [ForeignKey("PeriodTimeId")]
        public PeriodTime Pt { get; set; }


        public string Entity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}