using BL.DTO;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Business
{
    [Export(typeof(BaseCarParkType))]
    public class NightRateType : BaseCarParkType
    {
        private VehicleParkingDTO _dto { get; set; }

        public NightRateType()
        {
          
        }

        public override bool IsMatched(VehicleParkingDTO dto)
        {
            _dto = dto;
            if (!((_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Sunday)
             && (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Sunday))
         )
            {
                if (_dto.ParkingStartDate.Hour >= 18 && _dto.ParkingStartDate.Hour <= 6 + 24
             && (_dto.ParkingEndDate - _dto.ParkingStartDate).TotalDays < 1)
                    return true;
                else
                    return
                        false;
            }
            return false;
        }

        public override decimal CalculateRate()
        {
            return 6.50m;
        }
    }
}
