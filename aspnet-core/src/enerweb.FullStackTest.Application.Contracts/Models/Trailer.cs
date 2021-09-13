using Volo.Abp.Application.Dtos;

namespace enerweb.FullStackTest.Dto.Models
{
    public class Trailer: AuditedEntityDto<int>
    {
        public string RecordType { get; set; }
        public long RecordCount { get; set; }
    }
}
