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


- add xmldoc to public api
- review assert extensions
- see how multi targeting libs are setup
- config repo with security/code analysis. i.e. dependabot and codeql
- nullable feature in lib
- use build in json srlz if possible
- versioning: bump to 6.x.x or stay at 1.0.0?
- add contributing.md, pullrequerst template.md, etc
- reorganize into folders /src and /test
- add release notes for every release
- add github badges
 -https://github.com/fluentassertions/fluentassertions/pull/1737#discussion_r747684369
 - https://github.com/fluentassertions/fluentassertions/pull/1737#discussion_r746812193
 - rename XUnitTests.Core proj
 - status codes and headers done, now fix content and import the github issue suggestion
*/