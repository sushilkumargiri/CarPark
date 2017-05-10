using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BL.Business
{
    public class ParkTypeContainer
    {
        [ImportMany]
        public IEnumerable<BaseCarParkType> MessageSender { get; set; }

        public void Compose()
        {
            var assemblies = new[] { typeof(ParkTypeContainer).GetTypeInfo().Assembly };
            var configuration = new ContainerConfiguration()
                .WithAssembly(typeof(ParkTypeContainer).GetTypeInfo().Assembly);
            using (var container = configuration.CreateContainer())
            {
                MessageSender = container.GetExports<BaseCarParkType>();
            }
        }
    }

}
