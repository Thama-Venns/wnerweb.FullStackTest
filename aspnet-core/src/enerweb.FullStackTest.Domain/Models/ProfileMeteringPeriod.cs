using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace enerweb.FullStackTest.Models
{
    public class ProfileMeteringPeriod: AuditedAggregateRoot<int>
    {
        public string RecordType { get; set; }
        public int Period { get; set; }
        public float ImportEnergy { get; set; }
        public float ExportEnergy { get; set; }
        public float? ReactiveEnergyLeadingQ2 { get; set; }
        public float? ReactiveEnergyLeadingQ4 { get; set; }
        public float? ReactiveEnergyLaggingQ3 { get; set; }
        public float? ReactiveEnergyLaggingQ1 { get; set; }
        public float? ReadingFlag { get; set; }
        public Header Header { get; set; }
        public int HeaderId { get; set; }
    }
}
