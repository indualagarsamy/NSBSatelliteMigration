using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace NsbSatellite
{
    class Program
    {
        static void Main(string[] args)
        {
            BusConfiguration busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("NsbSatellite-v5");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<InMemoryPersistence>();

            using (IBus bus = Bus.Create(busConfiguration).Start())
            {
                Console.WriteLine("\r\nBus created and configured; press any key to stop program\r\n");
                bus.Send("targetqueue", new DoSomething());
                bus.Send("targetqueue-adv", new DoSomething());
                Console.ReadKey();
            }
        }
    }

    public class DoSomething : ICommand
    {
    }
}
