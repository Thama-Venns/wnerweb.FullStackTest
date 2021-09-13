using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace enerweb.FullStackTest.Models
{
    public class Trailer: AuditedAggregateRoot<int>
    {
        [MaxLength(3)]
        public string RecordType { get; set; }
        public long RecordCount { get; set; }
        public Header Header { get; set; }
        public int HeaderId { get; set; }
    }
}
