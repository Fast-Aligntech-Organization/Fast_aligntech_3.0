using LPH.Core.Enumerations;
using LPH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPH.Core.Entities
{
    [Table("usuarios")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Id))]
    public class Usuario : IEntity
    {
        public Usuario()
        {
            Ordenes = new HashSet<Orden>();

            Comments = new HashSet<OrdenComment>();


        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(64), Required]
        public string Nombre { get; set; }
        [StringLength(64), Required]
        public string Apellido { get; set; }
        [StringLength(10), Required]
        public string Telefono { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public bool EsVoluntario { get; set; }

        [Required, RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [Required]
        public UserKind TipoUsuario { get; set; }

        [Required]
        public RoleType Role { get; set; }

        [Required]
        public bool Suscrito { get; set; }

        [Required, StringLength(128)]
        public string Password { get; set; }


        public Guid? GoogleUUID { get; set; }

        [Required]
        public virtual ICollection<Orden> Ordenes { get; set; }
        [Required]
        public virtual ICollection<OrdenComment> Comments { get; set; }
    }
}
