
using ShopMicroservices0.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMicroservices0.Suppliers.Domain.Entities
{
    [Table("Suppliers",Schema = "Production")]
    public class Suppliers : AuditEntity<int>
    {
        [Column("supplierid")]
        public override int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }

    }
}
