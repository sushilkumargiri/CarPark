using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Business
{
    public abstract class BaseCarParkType
    {
        
        public abstract bool IsMatched(VehicleParkingDTO dto);

        public abstract decimal CalculateRate();

    }
}
