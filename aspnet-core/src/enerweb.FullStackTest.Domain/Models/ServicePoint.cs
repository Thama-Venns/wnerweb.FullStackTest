using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace enerweb.FullStackTest.Models
{
    public class ServicePoint: AuditedAggregateRoot<int>
    {
        [MaxLength(3)]
        public string RecordType { get; set; }
        [MaxLength(14)]
        public string MeterID { get; set; }
        [MaxLength(20)]
        public string MeterSerialNumber { get; set; }
        public Header Header { get; set; }
        public int HeaderId { get; set; }
    }
}
