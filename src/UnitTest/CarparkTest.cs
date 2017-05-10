using BL;
using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class CarparkTest
    {
        [Fact]
        public void Morning_Entry_Morning_Exit_Returns_EarlyBird_Rate()
        {
            var parkindData = new VehicleParkingDTO()
            {
                ParkingStartDate = new DateTime(2017,5,10),
                ParkingEndDate = new DateTime(2017, 5, 10),
                EntryTimeHr = 6,
                EntryTimeMn = 10,
                ExitTimeHr = 16,
                ExitTimeMn = 30,
            };
            var result = new CarPark().CalculateParkingFee(parkindData).Result;

            Assert.Equal(result, 13);
        }
        [Fact]
        public void Weekend_Entry_Weekend_Exit_Returns_Weekend_Rate()
        {
            var parkindData = new VehicleParkingDTO()
            {
                ParkingStartDate = new DateTime(2017, 5, 13),
                ParkingEndDate = new DateTime(2017, 5, 14),
                EntryTimeHr = 6,
                EntryTimeMn = 10,
                ExitTimeHr = 16,
                ExitTimeMn = 30,
            };
            var result = new CarPark().CalculateParkingFee(parkindData).Result;

            Assert.Equal(result, 10);
        }
        [Fact]
        public void Night_Entry_Morning_Exit_Returns_Night_Rate()
        {
            var parkindData = new VehicleParkingDTO()
            {
                ParkingStartDate = new DateTime(2017, 5, 10),
                ParkingEndDate = new DateTime(2017, 5, 11),
                EntryTimeHr = 19,
                EntryTimeMn = 10,
                ExitTimeHr = 5,
                ExitTimeMn = 30,
            };
            var result = new CarPark().CalculateParkingFee(parkindData).Result;

            Assert.Equal(result, 6.5m);
        }
        [Fact]
        public void Standard_Entry_1_2_Hours_Returns_10()
        {
            var parkindData = new VehicleParkingDTO()
            {
                ParkingStartDate = new DateTime(2017, 5, 10),
                ParkingEndDate = new DateTime(2017, 5, 10),
                EntryTimeHr = 10,
                EntryTimeMn = 10,
                ExitTimeHr = 11,
                ExitTimeMn = 30,
            };
            var result = new CarPark().CalculateParkingFee(parkindData).Result;

            Assert.Equal(result, 10);
        }
        [Fact]
        public void Standard_Entry_MoreThan_3_Hours_Returns_Fix_20()
        {
            var parkindData = new VehicleParkingDTO()
            {
                ParkingStartDate = new DateTime(2017, 5, 10),
                ParkingEndDate = new DateTime(2017, 5, 10),
                EntryTimeHr = 10,
                EntryTimeMn = 10,
                ExitTimeHr = 16,
                ExitTimeMn = 30,
            };
            var result = new CarPark().CalculateParkingFee(parkindData).Result;

            Assert.Equal(result, 20);
        }
    }
}
