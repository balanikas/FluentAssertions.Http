using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Http.Test;

public partial class HttpResponseMessageAssertionsSpecs
{
    public class Content
    {
        private readonly HttpResponseMessage _subject;

        public Content()
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

            Action act;
            
            act = () => _subject.Should().HaveContent("ont");
            act.Should().Throw<XunitException>();
            
            act = () => _subject.Should().HaveContent("");
            act.Should().Throw<XunitException>();
            
            act = () => _subject.Should().HaveContent(null);
            act.Should().Throw<XunitException>();
            
            act = () => ((HttpResponseMessage)null).Should().HaveContent("ont");
            act.Should().Throw<XunitException>().WithMessage("Expected response content , but HttpResponseMessage was <null>.");
        }

        [Fact]
        public void HaveTypedContent_WhenExpectedNotToFail_ShouldNotFail()
        {
            _subject.Content = new StringContent(JsonConvert.SerializeObject(new ModelA() { StringProperty = "string", IntProperty = 1 }));

            _subject.Should().HaveContent(new ModelA() { StringProperty = "string", IntProperty = 1 });
        }

        [Fact]
        public void HaveTypedContent_WhenExpectedToFail_ShouldFail()
        {
            ModelA expectedContent = new() { StringProperty = "string", IntProperty = 1 };
            _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

            Action act;
            
            act = () => _subject.Should().HaveContent(new ModelA { StringProperty = "string", IntProperty = 2 });
            act.Should().Throw<XunitException>();
            
            act = () => ((HttpResponseMessage)null).Should().HaveContent(new ModelA { StringProperty = "string", IntProperty = 1 });
            act.Should().Throw<XunitException>().WithMessage("Expected response content , but HttpResponseMessage was <null>.");
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

            Action act;
            act = () => _subject.Should().HaveContent(new ModelA { StringProperty = "otherstring", IntProperty = 1 },
                options => options.Including(x => x.StringProperty));
            act.Should().Throw<XunitException>();
            act = () => ((HttpResponseMessage)null).Should().HaveContent(new ModelA { StringProperty = "otherstring", IntProperty = 1 },
                options => options.Including(x => x.StringProperty));
            act.Should().Throw<XunitException>().WithMessage("Expected response content , but HttpResponseMessage was <null>.");
        }

        [Fact]
        public void HaveTypedContentMatching_WhenExpectedNotToFail_ShouldNotFail()
        {
            var expectedContent = new ModelA { StringProperty = "string", IntProperty = 1 };
            _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

            _subject.Should().HaveContentMatching<ModelA>(m => m.IntProperty == 1 && m.StringProperty == "string");
            _subject.Should().HaveContentMatching<ModelA>(m => m.IntProperty == 1);
        }

        [Fact]
        public void HaveTypedContentMatching_WhenExpectedToFail_ShouldFail()
        {
            var expectedContent = new ModelA { StringProperty = "string", IntProperty = 1 };
            _subject.Content = new StringContent(JsonConvert.SerializeObject(expectedContent));

            Action act;
            
            act = () => _subject.Should().HaveContentMatching<ModelA>(m => m.IntProperty == 2);
            act.Should().Throw<XunitException>();
            
            act = () => ((HttpResponseMessage)null).Should().HaveContentMatching<ModelA>(m => m.IntProperty == 2);
            act.Should().Throw<XunitException>().WithMessage("Expected response content , but HttpResponseMessage was <null>.");
        }

        [Fact]
        public void HaveContentMatching_WhenExpectedNotToFail_ShouldNotFail()
        {
            _subject.Content = new StringContent("hello world");

            _subject.Should().HaveContentMatching(m => m.Length > 7 && m.StartsWith("hello"));
        }

        [Fact]
        public void HaveContentMatching_WhenExpectedToFail_ShouldFail()
        {
            _subject.Content = new StringContent("hello world");

            Action act;
            
            act = () => _subject.Should().HaveContentMatching(m => m.Length > 20 && m.StartsWith("hello"));
            act.Should().Throw<XunitException>();
            
            act = () => ((HttpResponseMessage)null).Should().HaveContentMatching(m => m.Length > 20 && m.StartsWith("hello"));
            act.Should().Throw<XunitException>().WithMessage("Expected response content , but HttpResponseMessage was <null>.");
        }

        private class ModelA
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
        }
    }
}