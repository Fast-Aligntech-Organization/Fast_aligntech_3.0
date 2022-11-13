﻿using Fast.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fast.Core.Entities
{
    [Table("files")]
    public class File : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("IdOrdenNavigation")]
        public int IdOrden { get; set; }
        [Required, StringLength(128)]
        public string UriString { get; set; }

        public string Extencion { get; set; }

        public long SizeFile { get; set; }

        public string FileName { get; set; }




        [NotMapped]
        public Uri UriFile { get { return new Uri(UriString) {}; } set { UriString = value.AbsolutePath; } }


        public virtual Orden IdOrdenNavigation { get; set; }

    }
}
