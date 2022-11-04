using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SampleApplication;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        return WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}


/* work


- see how multi targeting libs are setup
- nullable feature in lib
- versioning: bump to 6.x.x or stay at 1.0.0?
- add contributing.md, pullrequerst template.md, etc
- reorganize into folders /src and /test
- add release notes for every release
 -https://github.com/fluentassertions/fluentassertions/pull/1737#discussion_r747684369
 - https://github.com/fluentassertions/fluentassertions/pull/1737#discussion_r746812193
*/