namespace Pgpg.Core.Domain.Users
{
    public class 安全距离设置 //: FullAuditedEntity<long>
    {
        public int 孩子ID { get; set; }

        public int 家长ID { get; set; }

        public int 警告距离 { get; set; }

        public int 危险距离 { get; set; }
    }

    public class 托管设置 //: FullAuditedEntity<long>, IPassivable
    {
        public int 孩子ID { get; set; }

        public int 机构ID { get; set; }

        public string 托管坐标 { get; set; }

        public bool IsActive { get; set; }
    }
}