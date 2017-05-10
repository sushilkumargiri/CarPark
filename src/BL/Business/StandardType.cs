using BL.DTO;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Business
{
    [Export(typeof(BaseCarParkType))]
    public class StandardType : BaseCarParkType
    {
        private VehicleParkingDTO _dto { get; set; }
        public StandardType()
        {
            
        }   

        public override bool IsMatched(VehicleParkingDTO dto)
        {
            _dto = dto;

            if (!((_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingStartDate.DayOfWeek == DayOfWeek.Sunday)
                && (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Saturday) || (_dto.ParkingEndDate.DayOfWeek == DayOfWeek.Sunday))
            )
            {
                _dto = dto;
                return true;
            }
            return false;
        }


        public override decimal CalculateRate()
        {
            var mins = (_dto.ParkingEndDate - _dto.ParkingStartDate).Hours * 60 + (_dto.ParkingEndDate - _dto.ParkingStartDate).Minutes;
            decimal price = (mins / 60) > 3 ? 20 : ((mins / 60) + 1) * 5;
            return price;

        }
    }
}
