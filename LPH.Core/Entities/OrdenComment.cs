using LPH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LPH.Core.Entities
{
    [Table("comentarios")]
    [Index(nameof(Id), IsUnique = true)]
    public class OrdenComment : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IdOrdenNavigation")]
        public int IdOrden { get; set; }
        [ForeignKey("IdUserNavigation")]
        public int IdUser { get; set; }
        [MaxLength(5)]
        public float Calificacion { get; set; }
        [StringLength(512)]
        public string Comentario { get; set; }

        public virtual Orden IdOrdenNavigation { get; set; }

        public virtual Usuario IdUserNavigation { get; set; }

    }
}
