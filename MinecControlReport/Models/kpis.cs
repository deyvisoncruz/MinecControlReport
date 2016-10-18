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
    public class kpis
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KpiId { get; set; }

        [Required]
        [Display(Name = "Kpis")]
        public String KpiName { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public String Descr;

        [Display(Name = "Unidade")]
        public String Unity;

        [Key]
        [Required]
        [Display(Name = "Chave")]
        public String Token;


        [Display(Name = "Status")]
        public int KpiStatus { get; set; }
    }
}