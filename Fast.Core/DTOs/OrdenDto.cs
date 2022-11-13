﻿using Fast.Core.Interfaces;
using System;
namespace Fast.Core.DTOs
{
    public class OrdenDto : IEntity
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public double Ancho { get; set; }
        public double Alto { get; set; }
        public string MaterialBarda { get; set; }
        public string Localizacion { get; set; }
        public string Tematica { get; set; }
        public DateTime FechaRealizacionDeseada { get; set; }
        public string Archivo { get; set; }
        public int Organizacion { get; set; }


    }
}
