using System;
using System.Threading.Tasks;
using NServiceBus;

class Program
{
    private static void Main(string[] args)
    {

        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        EndpointConfiguration endpointConfiguration = new EndpointConfiguration();
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.EndpointName("MySatellite");
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.UsePersistence<InMemoryPersistence>();

        IEndpointInstance endpoint = await Endpoint.Start(endpointConfiguration);
        try
        {
            Start(endpoint);
        }
        finally
        {
            await endpoint.Stop();
        }
    }


    static void Start(IEndpointInstance busSession)
    {
        Console.WriteLine("Press Enter to send the DoSomething command to trigger the satellite behavior");
        Console.WriteLine("Press any key to exit");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key != ConsoleKey.Enter)
            {
                return;
            }
            busSession.Send("MySatellite.targetQueue", new DoSomething());
        }
    }
}

public class DoSomething : ICommand
{
}

