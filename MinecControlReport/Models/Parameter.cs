using System;
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
    public class Parameter
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]

        [Display(Name = "Parametro")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public String Descr { get; set; }

        [Display(Name = "Valor")]
        public String Value { get; set; }


        [Required]
        [Display(Name = "Token")]
        public String Token { get; set; }
    }
}