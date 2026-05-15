using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace David_Capella_1.A_DAM_Examen_3EV_musicstore
{
    internal class Program
    {
        public class Album
        {
            private string titulo;
            private string artista;
            private int anyo;
            private bool disponible;
            public Album(string titulo, string artista, int anyo, bool disponible)
            {
                this.titulo = titulo;
                this.artista = artista;
                this.anyo = anyo;
                this.disponible = disponible;
            }
            public string GetTitulo() => titulo;
            public string GetArtista() => artista;
            public int GetAnyo() => anyo;
            public bool IsDisponible() => disponible;
            public override string ToString()
            {
                return $"{titulo} - {artista} ({anyo})";
            }
        }
        public class GestorBD
        {
            private MySqlConnection conexion;

            public GestorBD()
            {

                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "1234";
                builder.Database = "musicstore";

                conexion = new MySqlConnection(builder.ConnectionString);
            }

            public void InsertarAlbum(Album album)
            {
                string query = "INSERT INTO album (titulo, artista, anyo, disponible) VALUES (@t, @a, @y, @d)";
                MySqlCommand cmd = new MySqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@t", album.GetTitulo());
                cmd.Parameters.AddWithValue("@a", album.GetArtista());
                cmd.Parameters.AddWithValue("@y", album.GetAnyo());
                cmd.Parameters.AddWithValue("@d", album.IsDisponible());

                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            public void ObtenerTodosLosAlbumes()
            {
                string query = "SELECT * FROM album";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                conexion.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   List<Album> albums = new List<Album>();
                    string titulo = reader.GetString("titulo");
                    string artista = reader.GetString("artista");
                    int anyo = reader.GetInt32("anyo");
                    bool disponible = reader.GetBoolean("disponible");
                    Album album = new Album(titulo, artista, anyo, disponible);
                    albums.Add(album);
                }
            }


            static void Main(string[] args)
            {
                String ruta = "C:\\Users\\Alumno1\\albumes.txt";

                List<Album> albums = new List<Album>
            {
                new Album("Album1", "Metallica", 2000, true),
                new Album("Album2", "Paco", 2005, false),
                new Album("Album3", "Pedro", 2010, true)
            };
                foreach (var album in albums)
                {
                    Console.WriteLine(album.ToString());
                }
                foreach (var album in albums)
                {
                    if (album.GetArtista().Contains("Metallica"))
                    {
                        Console.WriteLine($"El album {album.GetTitulo()} de {album.GetArtista()}");
                    }
                }

                Console.WriteLine($"\nFecha de hoy: {DateTime.Now.ToShortDateString()}");
            }

            public static void GuardarAlbum(List<Album> lista, string ruta)
            {
                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    foreach (var album in lista)
                    {
                        writer.WriteLine($"{album.GetTitulo()};{album.GetArtista()};{album.GetAnyo()};{album.IsDisponible()}");
                    }
                }
            }




        }
    }
}
