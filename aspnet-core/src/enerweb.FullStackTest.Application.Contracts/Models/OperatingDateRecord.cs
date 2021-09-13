using System;
using Volo.Abp.Application.Dtos;

namespace enerweb.FullStackTest.Dto.Models
{
    public class OperatingDateRecord: AuditedEntityDto<int>
    {
        public string RecordType{ get; set; }
        public DateTime OperatingDate { get; set; }
    }
}
