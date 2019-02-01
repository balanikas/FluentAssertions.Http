using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Http.Test
{
    public class HttpResponseMessageAssertionsTest_Headers
    {
        [Fact]
        public void HaveHeader_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.AcceptRanges.Add("range1");

            _subject.Should().HaveHeader("accept-ranges", "range1");
        }

        [Fact]
        public void HaveHeader_WhenExpectedToFail_ShouldFail()
        {
            _subject.Headers.AcceptRanges.Add("range1");

            Action act = () => _subject.Should().HaveHeader("accept-ranges", "range2");

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveHeader_WhenHeaderDoesNotExist_ShouldFail()
        {
            Action act = () => _subject.Should().HaveHeader("nvalid-header-name", "range");
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveHeaderForLocation_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.Location = new Uri("http://address.com");

            _subject.Should().HaveHeaderForLocation(new Uri("http://address.com"));
        }

        [Fact]
        public void HaveHeaderForLocation_WhenExpectedToFail_ShouldFail()
        {
            _subject.Headers.Location = new Uri("http://address.com");

            Action act = () => _subject.Should().HaveHeaderForLocation(new Uri("http://other.com"));

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveHeaderForETag_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.ETag = new EntityTagHeaderValue("\"tag\"");

            _subject.Should().HaveHeaderForETag(new EntityTagHeaderValue("\"tag\""));
        }

        [Fact]
        public void HaveHeaderForETag_WhenExpectedToFail_ShouldFail()
        {
            _subject.Headers.ETag = new EntityTagHeaderValue("\"tag\"");

            Action act = () => _subject.Should().HaveHeaderForETag(new EntityTagHeaderValue("\"othertag\""));

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveHeaderForCacheControl_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.CacheControl = new CacheControlHeaderValue {MaxAge = TimeSpan.FromSeconds(1)};

            _subject.Should().HaveHeaderForCacheControl(new CacheControlHeaderValue { MaxAge = TimeSpan.FromSeconds(1)});
        }

        [Fact]
        public void HaveHeaderForCacheControl_WhenExpectedToFail_ShouldFail()
        {
            _subject.Headers.CacheControl = new CacheControlHeaderValue { MaxAge = TimeSpan.FromSeconds(1)};

            Action act = () => _subject.Should().HaveHeaderForCacheControl(new CacheControlHeaderValue { MaxAge = TimeSpan.FromSeconds(2) });

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveHeaderForPragma_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.Pragma.Add(new NameValueHeaderValue("name1"));

            _subject.Should().HaveHeaderForPragma(new NameValueHeaderValue("name1"));
        }

        [Fact]
        public void HaveHeaderForPragma_WhenExpectedToFail_ShouldFail()
        {
            _subject.Headers.Pragma.Add(new NameValueHeaderValue("name1"));

            Action act = () => _subject.Should().HaveHeaderForPragma(new NameValueHeaderValue("name2"));

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveHeaderForTransferEncoding_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.Headers.TransferEncoding.Add(new TransferCodingHeaderValue("value1"));

            _subject.Should().HaveHeaderForTransferEncoding(new TransferCodingHeaderValue("value1"));
        }

        [Fact]
        public void HaveHeaderForTransferEncoding_WhenExpectedToFail_ShouldFail()
        {
            _subject.Headers.TransferEncoding.Add(new TransferCodingHeaderValue("value1"));

            Action act = () => _subject.Should().HaveHeaderForTransferEncoding(new TransferCodingHeaderValue("value2"));

            act.Should().Throw<XunitException>();
        }

        readonly HttpResponseMessage _subject;

        public HttpResponseMessageAssertionsTest_Headers()
        {
            _subject = new HttpResponseMessage();
        }
    }
}
