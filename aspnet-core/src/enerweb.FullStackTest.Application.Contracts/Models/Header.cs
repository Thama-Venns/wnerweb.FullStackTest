using System;
using Volo.Abp.Application.Dtos;

namespace enerweb.FullStackTest.Dto.Models
{
    public class Header : AuditedEntityDto<int>
    {
        public string RecordType { get; set; }
        public string UserID { get; set; }
        public string FileType { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Unkonwn { get; set; } = null;
        public string FileName { get; set; }
    }
}
