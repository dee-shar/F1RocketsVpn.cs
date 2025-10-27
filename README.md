# F1RocketsVpn.cs
Mobile-API for [F1 Rockets VPN](https://play.google.com/store/apps/details?id=com.netspeedup.tom) an application that offers high-speed network connections all over the world, allowing you to connect to servers across the globe anonymously for free

## Example
```cs
using F1RocketsVpnApi;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new F1RocketsVpn();
            string servers = await api.GetServers();
            Console.WriteLine(servers);
        }
    }
}
```
