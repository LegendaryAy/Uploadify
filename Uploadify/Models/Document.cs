using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Uploadify.Models
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FileType { get; set; }
        public string Fullpath { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
