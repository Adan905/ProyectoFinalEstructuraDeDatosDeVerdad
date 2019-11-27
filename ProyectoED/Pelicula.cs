using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoED
{
    class Pelicula : Conjunto
    {
        public Pelicula(string titulo, int año, string productor, string genero, string descripcion, int rating)
        {
            Titulo = titulo;
            Año = año;
            Productor = productor;
            Genero = genero;
            Descripcion = descripcion;
            Rating = rating;
            Tipo = "Película";
        }
    }
}
