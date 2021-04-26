using System;
using System.Data.SqlClient;
using LPH.Core.Entities;
using LPH.Infrastructure.Data;
using System.Linq;

namespace TestConexionDB
{
    class Program
    {

        static LPHDBContext context;
       
        const string stringconnection = "Data Source=SATELLITE-ALEXI\\SQLEXPRESS_1;Initial Catalog=lphdatabase;Integrated Security=True;";

        static void Main(string[] args)
        {



            context = new LPHDBContext();

            context.Database.EnsureCreated();


            Usuario usuario = new LPH.Core.Entities.Usuario();

            usuario.Nombre = "Alexis Daniel";
            usuario.Apellido = "Hernandez Gamez";
            usuario.Email = "Al180263@alumnos.uacj.mx";
            usuario.FechaNacimiento = new DateTime(1998, 07, 08);
            usuario.Telefono = "6564717813";
            usuario.Password = "hega230498";
            usuario.Suscrito = false;
            
         
            usuario.TipoUsuario = LPH.Core.Enumerations.UserKind.Estudiante;


          

            //context.Usuarios.Add(usuario);


            Console.WriteLine($"Usuarios creados{context.SaveChanges()}");

                Random r = new Random();
                for (int i = 0; i < 10; i++)
                {

                    context.Usuarios.Find(1).Ordenes.Add(new Orden
                    {
                        Alto = r.Next(20),
                        Ancho = r.Next(20),
                        FechaRealizacionDeseada = new DateTime(r.Next(10000)),
                        Tematica = (new[] { "Perreo", "Salvaje", "Amor" })[r.Next(3)],
                        Localizacion = (new[] { "Ciudad juarez", "chihuahua", "parral", "Monterrey" })[r.Next(4)],
                        MaterialBarda = (new[] { "Ormigon", "Madera", "Yeso", "Tabloides" })[r.Next(4)],
                        Organizacion = LPH.Core.Enumerations.Organization.Escuela
                            

                    }); 
                }
             Console.WriteLine($"{context.SaveChanges()} cambios realizados");
            
           
            foreach (var item in context.Usuarios)
            {
                Console.WriteLine(item.Id + " " + item.Nombre);
            }
           

            //    conn = new SqlConnection(stringconnection);

            //    SqlCommand sqlCommand = new SqlCommand("select *" ,conn);

            //    try
            //    {
            //        conn.Open();

            //        //var re = sqlCommand.ExecuteReader();
            //        Console.WriteLine("Conexion a la base de datos correcta");

            //        Console.WriteLine(conn.ToString());


            //    }
            //    catch (Exception er)
            //    {

            //        Console.WriteLine("Error: "+er.Message);
            //    }

            //    conn.Close();
            //}
        }
    }
}
