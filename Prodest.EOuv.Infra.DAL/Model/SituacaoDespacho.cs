﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class SituacaoDespacho
    {
        public SituacaoDespacho()
        {
            DespachoManifestacao = new HashSet<DespachoManifestacao>();
        }

        public int IdSituacaoDespacho { get; set; }
        public string DescSituacaoDespacho { get; set; }

        public virtual ICollection<DespachoManifestacao> DespachoManifestacao { get; set; }
    }
}