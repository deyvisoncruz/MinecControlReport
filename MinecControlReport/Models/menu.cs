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
    public class menu
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Link { get; set; }

        [Required]
        public String Order { get; set; }

        public ICollection<menuReport> menuReportCollection { get; set; }
    }
}