using Volo.Abp.Application.Dtos;

namespace enerweb.FullStackTest.Dto.Models
{
    public class ProfileMeteringPeriod: AuditedEntityDto<int>
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
    }
}
