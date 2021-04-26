using System;
using System.Collections.Generic;
using System.Text;
using LPH.Core.Interfaces;
using LPH.Core.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LPH.Core.Entities
{
    [Table("ordenes")]
    [Index(nameof(Id),IsUnique = true)]
    public class Orden: IEntity
    {
        public Orden()
        {
            Comments = new HashSet<OrdenComment>();
            Files = new HashSet<File>();
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IdUserNavigation")]
        public int IdUser { get; set; }
        [Required]
        public double Ancho { get; set; }
        [Required]
        public double Alto { get; set; }
        [StringLength(64)]
        public string MaterialBarda { get; set; }
        [StringLength(128)]
        public string Localizacion { get; set; }
        [StringLength(516)]
        public string Tematica { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaRealizacionDeseada { get; set; }
        [Required]
        public Organization Organizacion { get; set; }



        public virtual Usuario IdUserNavigation { get; set; }

        public virtual ICollection<OrdenComment> Comments { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }
}
