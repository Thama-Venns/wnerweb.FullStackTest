using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace enerweb.FullStackTest.Models
{
    public class OperatingDateRecord: AuditedAggregateRoot<int>
    {
        [MaxLength(3)]
        public string RecordType{ get; set; }
        public DateTime OperatingDate { get; set; }
        public Header Header { get; set; }
        public int HeaderId { get; set; }
    }
}
