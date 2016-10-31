using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Linq;
using System.Web;
using Microsoft.Web.WebPages.OAuth;

namespace MinecControlReport.Models
{
 
    public class menuRole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MenuRefId { get; set; }

        [ForeignKey("MenuRefId")]
        public menu menu { get; set; }

        public string RolesRef { get; set; }

       
    }

    
}