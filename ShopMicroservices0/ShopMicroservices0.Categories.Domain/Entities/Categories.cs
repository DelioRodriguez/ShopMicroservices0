using System.ComponentModel.DataAnnotations.Schema;
using ShopMicroservices0.Categories.Domain.Interfaces;
using ShopMicroservices0.Common.Data.Base;


namespace ShopMicroservices0.Categories.Domain.Entities
{
    [Table("Categories", Schema = "Production")]
    public class Categories : AuditEntity<int>
    {
        [Column("categoryid")]
        public override int Id { get; set; }

        public string categoryName { get; set; }

        public string description { get; set; }
    }
}