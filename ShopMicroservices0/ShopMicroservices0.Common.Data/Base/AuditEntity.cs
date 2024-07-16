namespace ShopMicroservices0.Common.Data.Base
{
    public abstract class AuditEntity<TType> : BaseEntity<TType>
    {

        public DateTime? modify_date { set; get; }
        public int? modify_user { set; get; }
        public int creation_user { set; get; }
        public DateTime creation_date { set; get; }
        public int? delete_user { set; get; }
        public DateTime? delete_date { set; get; }
        public bool deleted { set; get; }

    }
}
