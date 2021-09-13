using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace enerweb.FullStackTest.Models
{
    public class Header : AuditedAggregateRoot<int>
    {
        [MaxLength(3)]
        public string RecordType { get; set; }
        [MaxLength(10)]
        public string UserID { get; set; }
        [MaxLength(3)]
        public string FileType { get; set; }
        public DateTime CreationDateTime { get; set; }
        [MaxLength(1)]
        public string Unkonwn { get; set; } = null;
        [MaxLength(20)]
        public string FileName { get; set; }
    }
}
