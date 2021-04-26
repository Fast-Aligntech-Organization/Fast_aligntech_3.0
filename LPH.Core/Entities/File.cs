using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LPH.Core.Interfaces;
using LPH.Core.Entities;

namespace LPH.Core.Entities
{
    [Table("files")]
    public class File : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("IdOrdenNavigation")]
        public int IdOrden { get; set; }
        [Required,StringLength(128)]
        public string UriString { get; set; }

        public string Extencion { get; set; } 

        public int SizeFile { get; set; }

        public string FileName { get; set; }

        


        [NotMapped]
        public Uri UriFile { get { return new Uri(UriString); } set { UriString = value.AbsoluteUri; } }


        public virtual Orden IdOrdenNavigation { get; set; }

    }
}
