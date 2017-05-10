using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class VehicleParkingDTO
    {
        public int Id { get; set; }
        public string VehicleId { get; set; }
        public DateTime ParkingStartDate { get; set; }
        public int EntryTimeHr { get; set; }
        public int EntryTimeMn { get; set; }
        public DateTime ParkingEndDate { get; set; }
        public int ExitTimeHr { get; set; }
        public int ExitTimeMn { get; set; }
        public decimal Price { get; set; }
    }
}
