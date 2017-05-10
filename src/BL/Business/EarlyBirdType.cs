using BL.DTO;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Business
{
    [Export(typeof(BaseCarParkType))]
    public class EarlyBirdType : BaseCarParkType
    {
        private VehicleParkingDTO _dto { get; set; }

        public EarlyBirdType()
        {

        }
      
        public override bool IsMatched(VehicleParkingDTO dto)
        {
            _dto = dto;

            var entryTimeInMin = _dto.EntryTimeHr * 60 + _dto.EntryTimeMn;
            var exitTimeInMin = _dto.ExitTimeHr * 60 + _dto.ExitTimeMn;

            if (!((_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Sunday)
                && (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Sunday))
            )
                {
                if ((entryTimeInMin >= 6 * 60 && entryTimeInMin <= 9 * 60)
                   && (exitTimeInMin >= ((15 * 60) + 30) && exitTimeInMin <= ((23 * 60) + 30)))
                    return true;
                else
                    return
                        false;
            }
            return false;
        }

        public override decimal CalculateRate()
        {
            return 13.00m;
        }
    }
}
