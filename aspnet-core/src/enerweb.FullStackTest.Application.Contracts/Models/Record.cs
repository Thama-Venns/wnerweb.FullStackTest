using System.Collections.Generic;

namespace enerweb.FullStackTest.Dto.Models
{
    public class Record
    {
        public Header Header { get; set; }
        public OperatingDateRecord OperatingDateRecord { get; set; }
        public List<ServicePoint> ServicePoint { get; set; }
        public List<ProfileMeteringPeriod> ProfileMeteringPeriods { get; set; }
        public Trailer Trailer { get; set; }
    }
}
