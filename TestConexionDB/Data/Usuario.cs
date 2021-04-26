using System;
using System.Collections.Generic;

#nullable disable

namespace TestConexionDB.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ordenes = new HashSet<Orden>();
            UserLogins = new HashSet<UserLogin>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public int TipoUsuario { get; set; }
        public bool Suscrito { get; set; }

        public virtual ICollection<Orden> Ordenes { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
