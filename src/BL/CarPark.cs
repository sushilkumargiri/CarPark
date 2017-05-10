using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTO;
using BL.Business;

namespace BL
{
    public class CarPark : ICarPark
    {
        public Task<decimal> CalculateParkingFee(VehicleParkingDTO vehicle)
        {
            //Validate the input
            if (ValidateInput(vehicle))
            {
                UpdateDateInput(vehicle);

                ParkTypeFactory _factory = new ParkTypeFactory();

                BaseCarParkType type = _factory.IdentifyParkType(vehicle);

                return Task.FromResult(type.CalculateRate());
                
            }
            else
            {
                throw new ArgumentException("All input fields are mandatory!");
            }
        }

        private void UpdateDateInput(VehicleParkingDTO vehicle)
        {
            vehicle.ParkingStartDate = vehicle.ParkingStartDate.AddHours(vehicle.EntryTimeHr);
            vehicle.ParkingStartDate = vehicle.ParkingStartDate.AddMinutes(vehicle.EntryTimeMn);
            vehicle.ParkingEndDate = vehicle.ParkingEndDate.AddHours(vehicle.ExitTimeHr);
            vehicle.ParkingEndDate = vehicle.ParkingEndDate.AddMinutes(vehicle.ExitTimeMn);
        }
        
        private bool ValidateInput(VehicleParkingDTO vehicle)
        {
            if (vehicle.ParkingStartDate == DateTime.MinValue)
            {
                return false;
            }
            if (vehicle.ParkingEndDate == DateTime.MinValue)
            {
                return false;
            }
            return true;
        }
    }
   
}
