﻿using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class UfModel
    {
        public string SigUf { get; set; }
        public string DescUf { get; set; }
        public int IdPais { get; set; }

        public virtual PaisModel Pais { get; set; }
    }
}