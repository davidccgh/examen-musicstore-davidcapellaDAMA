using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        


        static void Main(string[] args)
        {













        }
    }
}
