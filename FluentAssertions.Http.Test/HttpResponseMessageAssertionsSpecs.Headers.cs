using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Http.Test;

public partial class HttpResponseMessageAssertionsSpecs
{
    public class Headers
    {
        private readonly HttpResponseMessage _subject;

        public Headers()
        {
            _subject = new HttpResponseMessage();
        }

        [Fact]
        public void HaveResponseHeader_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.Add("my-header", new[] { "value1" });
            _subject.Should().HaveResponseHeader("my-header");
        }

        [Fact]
        public void HaveResponseHeader_WhenExpectedToFail_ShouldFail()
        {
            Action act;
            
            act = () => _subject.Should().HaveResponseHeader("invalid-header-name");
            act.Should().Throw<XunitException>().WithMessage("Expected header \"invalid-header-name\" to exist, but it does not exist.");
            
            act = () => ((HttpResponseMessage)null).Should().HaveResponseHeader("invalid-header-name");
            act.Should().Throw<XunitException>().WithMessage("Expected header \"invalid-header-name\" to exist, but HttpResponseMessage was <null>.");
        }

        [Fact]
        public void HaveResponseHeaderValue_WhenExpectedToFail_ShouldFail()
        {
            _subject.Headers.AcceptRanges.Add("range1");
            _subject.Headers.AcceptRanges.Add("range2");

            Action act;
            
            act = () => _subject.Should().HaveResponseHeaderValue("accept-ranges", "range3");
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"range3\"} to exist in header \"accept-ranges\", but found {\"range1\", \"range2\"}.");
            
            act = () => _subject.Should().HaveResponseHeaderValues("accept-ranges", new[] { "range1", "range3" });
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"range1\", \"range3\"} to exist in header \"accept-ranges\", but found {\"range1\", \"range2\"}.");
            
            act = () => _subject.Should().HaveResponseHeaderValue(HttpResponseHeader.AcceptRanges, "range3");
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"range3\"} to exist in header \"accept-ranges\", but found {\"range1\", \"range2\"}.");
            
            act = () => _subject.Should()
                .HaveResponseHeaderValues(HttpResponseHeader.AcceptRanges, new[] { "range1", "range3" });
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"range1\", \"range3\"} to exist in header \"accept-ranges\", but found {\"range1\", \"range2\"}.");
            
            act = () => ((HttpResponseMessage)null).Should().HaveResponseHeaderValue("accept-ranges", "range3");
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"range3\"} to exist in header \"accept-ranges\", but HttpResponseMessage was <null>.");
            
            act = () => _subject.Should().HaveResponseHeaderValue("unknown", "range1");
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"range1\"} to exist in header \"unknown\", but found {empty}.");
            
            act = () => _subject.Should().HaveResponseHeaderValues("unknown", new[] { "range1" });
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"range1\"} to exist in header \"unknown\", but found {empty}.");
        }

        [Fact]
        public void HaveResponseHeaderValue_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.AcceptRanges.Add("range1");
            _subject.Headers.AcceptRanges.Add("range2");
            _subject.Headers.AcceptRanges.Add("range3");

            _subject.Should().HaveResponseHeaderValue("accept-ranges", "range2");
            _subject.Should().HaveResponseHeaderValues("accept-ranges", new[] { "range2", "range1" });

            _subject.Should().HaveResponseHeaderValue(HttpResponseHeader.AcceptRanges, "range2");
            _subject.Should().HaveResponseHeaderValues(HttpResponseHeader.AcceptRanges, new[] { "range2", "range1" });
        }

        [Fact]
        public void HaveContentHeader_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Content.Headers.Add("my-header", new[] { "value1" });
            _subject.Should().HaveContentHeader("my-header");
        }

        [Fact]
        public void HaveContentHeader_WhenExpectedToFail_ShouldFail()
        {
            Action act;
            act = () => _subject.Should().HaveContentHeader("invalid-header-name");
            act.Should().Throw<XunitException>().WithMessage("Expected header \"invalid-header-name\" to exist, but it does not exist.");
            act = () => ((HttpResponseMessage)null).Should().HaveContentHeader("invalid-header-name");
            act.Should().Throw<XunitException>().WithMessage("Expected header \"invalid-header-name\" to exist, but HttpResponseMessage was <null>.");
        }

        [Fact]
        public void HaveContentHeaderValue_WhenExpectedToFail_ShouldFail()
        {
            _subject.Content.Headers.ContentLanguage.Add("lang1");
            _subject.Content.Headers.ContentLanguage.Add("lang2");

            Action act;
            
            act = () => _subject.Should().HaveContentHeaderValue("content-language", "lang3");
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"lang3\"} to exist in header \"content-language\", but found {\"lang1\", \"lang2\"}");
            
            act = () => _subject.Should().HaveContentHeaderValues("content-language", new[] { "lang1", "lang3" });
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"lang1\", \"lang3\"} to exist in header \"content-language\", but found {\"lang1\", \"lang2\"}");
            
            act = () => _subject.Should().HaveContentHeaderValue(HttpResponseHeader.ContentLanguage, "lang3");
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"lang3\"} to exist in header \"Content-Language\", but found {\"lang1\", \"lang2\"}");
            
            act = () => _subject.Should()
                .HaveContentHeaderValues(HttpResponseHeader.ContentLanguage, new[] { "lang1", "lang3" });
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"lang1\", \"lang3\"} to exist in header \"Content-Language\", but found {\"lang1\", \"lang2\"}");
            
            act = () => _subject.Should().HaveContentHeaderValue("unknown", "lang1");
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"lang1\"} to exist in header \"unknown\", but found {empty}");
            
            act = () => _subject.Should().HaveContentHeaderValues("unknown", new[] { "lang1" });
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"lang1\"} to exist in header \"unknown\", but found {empty}");
            
            act = () => ((HttpResponseMessage)null).Should().HaveContentHeaderValues("unknown", new[] { "lang1" });
            act.Should().Throw<XunitException>().WithMessage("Expected value(s) {\"lang1\"} to exist in header \"unknown\", but HttpResponseMessage was <null>.");
        }
        

        [Fact]
        public void HaveContentHeaderValue_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Content.Headers.ContentLanguage.Add("lang1");
            _subject.Content.Headers.ContentLanguage.Add("lang2");
            _subject.Content.Headers.ContentLanguage.Add("lang3");

            _subject.Should().HaveContentHeaderValue("content-language", "lang2");
            _subject.Should().HaveContentHeaderValues("content-language", new[] { "lang2", "lang1" });

            _subject.Should().HaveContentHeaderValue(HttpResponseHeader.ContentLanguage, "lang2");
            _subject.Should().HaveContentHeaderValues(HttpResponseHeader.ContentLanguage, new[] { "lang2", "lang1" });
        }
    }
}