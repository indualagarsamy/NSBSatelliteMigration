using System;
using NServiceBus;
using NServiceBus.Satellites;

namespace NsbSatellite
{
    public class MySatellite : ISatellite
    {
        public bool Handle(TransportMessage message)
        {
            Console.WriteLine("Received message");
            return true;
        }

        public void Start()
        {
            Console.WriteLine("Satellite Started");
        }

        public void Stop()
        {
            Console.WriteLine("Satellite Stopped");
        }

        public Address InputAddress => Address.Parse("targetqueue");
        public bool Disabled => false;
    }
}
