using System;
using System.IO;
using NServiceBus;
using NServiceBus.Satellites;
using NServiceBus.Unicast.Transport;
public class MyAdvancedSatellite : IAdvancedSatellite
{
    public CriticalError CriticalError { get; set; }

    public bool Handle(TransportMessage message)
    {
        Console.WriteLine("AdvancedSatellite - Received message");
        throw new Exception("Something bad happened");
        //return true;
    }

    public void Start()
    {
        Console.WriteLine("Advanced Satellite Started");
    }

    public void Stop()
    {
        Console.WriteLine("Advanced Satellite Stopped");
    }


    public Address InputAddress => Address.Parse("targetqueue-adv");
    public bool Disabled => false;

    public Action<TransportReceiver> GetReceiverCustomization()
    {
        // Customize the Failure Manager. 
        satelliteImportFailuresHandler = new SatelliteImportFailuresHandler();
        return receiver => { receiver.FailureManager = satelliteImportFailuresHandler; };
    }

    SatelliteImportFailuresHandler satelliteImportFailuresHandler;
}
