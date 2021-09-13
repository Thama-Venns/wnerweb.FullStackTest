using Volo.Abp.Application.Dtos;

namespace enerweb.FullStackTest.Dto.Models
{
    public class ServicePoint: AuditedEntityDto<int>
    {
        public string RecordType { get; set; }
        public string MeterID { get; set; }
        public string MeterSerialNumber { get; set; }
    }
}
