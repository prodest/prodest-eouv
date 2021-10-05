using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public partial class DocumentoDesentranhadoModel
    {
        public int Id { get; set; }
        public int Sequencial { get; set; }
        public bool Controle { get; set; }
        public RegistrosCopiaDocumentoAtoModel[] RegistrosCopiaDocumentoAto { get; set; }
    }
}
