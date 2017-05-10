using BL.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Angular.Web.ViewModel
{
    public class Vehicle
    {
        public string ParkingStartDate { get; set; }
        public int EntryTimeHr { get; set; }
        public int EntryTimeMn { get; set; }
        public string ParkingEndDate { get; set; }
        public int ExitTimeHr { get; set; }
        public int ExitTimeMn { get; set; }
        public decimal Price { get; set; }

        public static VehicleParkingDTO Map(Vehicle vehicle)
        {
            DateTime startDate;
            DateTime.TryParseExact(vehicle.ParkingStartDate, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,DateTimeStyles.None,out startDate);
            DateTime endDate;
            DateTime.TryParseExact(vehicle.ParkingEndDate, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
            return new VehicleParkingDTO()
            {
                ParkingStartDate = startDate,
                EntryTimeHr = vehicle.EntryTimeHr,
                EntryTimeMn = vehicle.EntryTimeMn,
                ParkingEndDate = endDate,
                ExitTimeHr = vehicle.ExitTimeHr,
                ExitTimeMn = vehicle.ExitTimeMn,
            };
        }
    }
}
