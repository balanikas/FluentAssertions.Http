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

- cleanup code
- add editor config
- publish to nuget with github actions
- add xmldoc to public api
- review assert extensions
- see how multi targeting libs are setup
- config repo with security/code analysis. i.e. dependabot and codeql
*/