using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class AuditLog
    {
        public long Id { get; set; }
        public DateTime AuditDate { get; set; }
        public string AuditUserName { get; set; }
        public string AuditUserCpf { get; set; }
        public string Origin { get; set; }
        public string EntityType { get; set; }
        public string Action { get; set; }
        public string TablePk { get; set; }
        public string AuditData { get; set; }
    }
}