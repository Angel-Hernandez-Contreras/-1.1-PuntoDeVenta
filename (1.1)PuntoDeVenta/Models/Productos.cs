﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_PuntoDeVenta.Models
{
    class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; } 
    }
}
