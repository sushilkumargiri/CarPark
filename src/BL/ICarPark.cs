using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL
{
    public interface ICarPark
    {
        Task<decimal> CalculateParkingFee(VehicleParkingDTO vehicle);
    }
}
