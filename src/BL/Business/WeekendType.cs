using BL.DTO;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Business
{
    [Export(typeof(BaseCarParkType))]
    public class WeekendType : BaseCarParkType
    {
        private VehicleParkingDTO _dto { get; set; }
        public WeekendType()
        {
          
        }

        public override bool IsMatched(VehicleParkingDTO dto)
        {
            _dto = dto;

            if ((_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Sunday)
                && (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Sunday)
                )
                return true;
            else
                return
                    false;
        }

        public override decimal CalculateRate()
        {
            return 10.00m;
        }
    }
}
