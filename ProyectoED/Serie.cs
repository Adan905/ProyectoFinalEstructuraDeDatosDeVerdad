﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoED
{
    class Serie : Conjunto
    {
        public Serie(string titulo, int año, string productor, string genero, int temporadas, string descripcion, int rating)
        {
            Titulo = titulo;
            Año = año;
            Productor = productor;
            Genero = genero;
            Temporadas = temporadas;
            Descripcion = descripcion;
            Rating = rating;
            Tipo = "Serie";
        }
    }
}
