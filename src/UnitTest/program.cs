using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var test = new CarparkTest();

            test.Morning_Entry_Morning_Exit_Returns_EarlyBird_Rate();
            test.Night_Entry_Morning_Exit_Returns_Night_Rate();
            test.Weekend_Entry_Weekend_Exit_Returns_Weekend_Rate();
            test.Standard_Entry_1_2_Hours_Returns_10();
            test.Standard_Entry_MoreThan_3_Hours_Returns_Fix_20();
        }
    }
}
