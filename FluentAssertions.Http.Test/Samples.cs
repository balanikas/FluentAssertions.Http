using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FluentAssertions.Http.Test;

internal class Samples
{
    public void Sample1()
    {
        var expectedContent = new ModelA { StringProperty = "test", IntProperty = 1 };

        var response = new HttpResponseMessage();

        response.Should()
            .HaveStatusCode(HttpStatusCode.Created)
            .And
            .HaveHeaderForETag(new EntityTagHeaderValue("etag"))
            .And
            .HaveContent(expectedContent);
    }

    public void Sample2()
    {
        var expectedContent = new ModelA { StringProperty = "test", IntProperty = 2 };

        var response = new HttpResponseMessage();

        response.Should()
            .HaveContent(expectedContent, options => options.Excluding(x => x.IntProperty));
    }
}

internal class ModelA
{
    public string StringProperty { get; set; }
    public int IntProperty { get; set; }
}