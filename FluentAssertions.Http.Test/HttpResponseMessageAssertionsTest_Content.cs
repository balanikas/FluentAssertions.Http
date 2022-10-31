using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Http.Test;

public class HttpResponseMessageAssertionsTest_Content
{
    private readonly HttpResponseMessage _subject;

    public HttpResponseMessageAssertionsTest_Content()
    {
        _subject = new HttpResponseMessage();
    }

    [Fact]
    public void HaveContent_WhenExpectedNotToFail_ShouldNotFail()
    {
        _subject.Content = new StringContent("content");

        _subject.Should().HaveContent("content");
    }

    [Fact]
    public void HaveContent_WhenExpectedToFail_ShouldFail()
    {
        _subject.Content = new StringContent("content");

        Action act = () => _subject.Should().HaveContent("ont");

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void HaveTypedContent_WhenExpectedNotToFail_ShouldNotFail()
    {
        ModelA expectedContent = new() { StringProperty = "string", IntProperty = 1 };
        _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

        _subject.Should().HaveContent(expectedContent);
    }

    [Fact]
    public void HaveTypedContent_WhenExpectedToFail_ShouldFail()
    {
        ModelA expectedContent = new() { StringProperty = "string", IntProperty = 1 };
        _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

        Action act = () => _subject.Should().HaveContent(new ModelA { StringProperty = "string", IntProperty = 2 });

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void HaveTypedContentWithEquivalencyOptions_WhenExpectedNotToFail_ShouldNotFail()
    {
        ModelA expectedContent = new() { StringProperty = "string", IntProperty = 1 };
        _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

        _subject.Should().HaveContent(new ModelA { StringProperty = "otherstring", IntProperty = 1 },
            options => options.Including(x => x.IntProperty));
        _subject.Should().HaveContent(new ModelA { StringProperty = "otherstring", IntProperty = 1 },
            options => options.Excluding(x => x.StringProperty));
    }

    [Fact]
    public void HaveTypedContentWithEquivalencyOptions_WhenExpectedToFail_ShouldFail()
    {
        ModelA expectedContent = new() { StringProperty = "string", IntProperty = 1 };
        _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

        Action act = () => _subject.Should().HaveContent(new ModelA { StringProperty = "otherstring", IntProperty = 1 },
            options => options.Including(x => x.StringProperty));

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void HaveContentWithProperty_WhenExpectedNotToFail_ShouldNotFail()
    {
        ModelA expectedContent = new() { StringProperty = "string", IntProperty = 1 };
        _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

        _subject.Should().HaveContentWithProperty<ModelA>(x => x.IntProperty, 1);
    }

    [Fact]
    public void HaveContentWithProperty_WhenExpectedToFail_ShouldFail()
    {
        ModelA expectedContent = new() { StringProperty = "string", IntProperty = 1 };
        _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

        Action act = () => _subject.Should().HaveContentWithProperty<ModelA>(x => x.IntProperty, 2);

        act.Should().Throw<XunitException>();
    }

    private class ModelA
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
    }
}