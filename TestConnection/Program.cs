using System;
using System.Threading.Tasks;
using LPH.Infrastructure.Data;
using Npgsql;
using LPH.Core.Entities;
using LPH.Core.Services;
using System.Security.Cryptography;

namespace TestConnection
{
    class Program
    {

        public static string Hash(string password)
        {
            //PBKDF2 implementation
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                16,
                10000
                ))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(32));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{10000}.{salt}.{key}";
            }
        }

            static void Main(string[] args)
        {

            
            NpgsqlConnectionStringBuilder connstring = new NpgsqlConnectionStringBuilder();

            //"Server:.;Port:5432;Database:lphdatabase;User Id:postgres;Password:Lph12345;"
            //Server=ec2-34-193-113-223.compute-1.amazonaws.com;Port=5432;Database=depsjd3oarplor;User Id=yhuwxgiqefjtkd;Password=ff0cc7ca638abcddb64a97750050e1ab910a97b6ac1ffca2a4155fceebb1cbcd;sslmode=Require;Trust Server Certificate=true;
            connstring.Database = "depsjd3oarplor";
            connstring.Password = "ff0cc7ca638abcddb64a97750050e1ab910a97b6ac1ffca2a4155fceebb1cbcd";
            connstring.Username = "yhuwxgiqefjtkd";
            connstring.Host = "ec2-34-193-113-223.compute-1.amazonaws.com";
        
            connstring.Port = 5432;



            LPHDBContext conn = new LPHDBContext();
           

            try
            {


                Usuario administer = new Usuario();

                administer.Email = @"lph_api@outlook.com";
                administer.Telefono = "6562538679";
                administer.Nombre = "lphadmin";
                administer.FechaNacimiento = DateTime.Now;
                administer.Apellido = "Principal";
                administer.Password = Hash("Lph12345");
                administer.Role = LPH.Core.Enumerations.RoleType.Administrator;
                administer.GoogleUUID = null;
                administer.Suscrito = false;
               


                if (conn.Database.CanConnect())
                {
                    conn.Usuarios.Add(administer);
                   Console.WriteLine("Se ha agredio {0} usuarios a la db", conn.SaveChanges());
                }
                else
                {
                    Console.WriteLine("No se pudo conectar a la base de datos");
                }


                //Console.WriteLine(connstring.ConnectionString);

                //NpgsqlConnection npgconn = new NpgsqlConnection(connstring.ConnectionString);

                //npgconn.Open();

                //npgconn.Close();
                //Console.WriteLine(conn.Database.ProviderName);
                //Console.WriteLine("EL contexto se pudo conectar: {0}", conn.Database.CanConnect());

                //var resultado = conn.Database.EnsureCreated();
                //Console.WriteLine(resultado);

            }
            catch (Exception err)
            {

                Console.WriteLine(err);
            }
 Console.WriteLine("Hello World!");
        }
    }
}
