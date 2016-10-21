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
    public class menuReport
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public String Name { get; set; }



        public int MenuRefId { get; set; }

        [ForeignKey("MenuRefId")]    
        public menu menu { get; set; }

        [Required]
        public String Link { get; set; }

        [Required]
        public int type { get; set; }

        [Required]
        public String Order { get; set; }
    }
}