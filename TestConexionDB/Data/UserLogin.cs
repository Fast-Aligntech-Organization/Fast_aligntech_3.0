using System;
using System.Collections.Generic;

#nullable disable

namespace TestConexionDB.Data
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int Email { get; set; }
        public string Contraseña { get; set; }

        public virtual Usuario IdUserNavigation { get; set; }
    }
}
