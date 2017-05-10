using BL.DTO;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BL.Business
{
    
    public class ParkTypeFactory
    {
        public BaseCarParkType IdentifyParkType(VehicleParkingDTO vehicle)
        {
            ParkTypeContainer container = new ParkTypeContainer();
            container.Compose();

            var matched = container.MessageSender.Where(x=>x.IsMatched(vehicle)).FirstOrDefault();

            return matched;
        }
        
    }


}
