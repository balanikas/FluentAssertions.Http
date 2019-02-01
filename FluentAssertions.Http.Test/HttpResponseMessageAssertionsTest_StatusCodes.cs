using System;
using System.Net;
using System.Net.Http;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Http.Test
{
    public class HttpResponseMessageAssertionsTest_StatusCodes
    {
        [Fact]
        public void HaveStatusCode_WhenExpectedToFail_ShouldFail()
        {
            _subject.StatusCode = HttpStatusCode.Accepted;

            Action act = () => _subject.Should().HaveStatusCode(HttpStatusCode.BadGateway);

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveStatusCode_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.StatusCode = HttpStatusCode.Accepted;

            _subject.Should().HaveStatusCode(HttpStatusCode.Accepted);
        }

        [Fact]
        public void HaveInformationalStatusCode_WhenExpectedToFail_ShouldFail()
        {
            _subject.StatusCode = HttpStatusCode.Accepted;

            Action act = () => _subject.Should().HaveInformationalStatusCode();

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveInformationalStatusCode_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.StatusCode = HttpStatusCode.Continue;

            _subject.Should().HaveInformationalStatusCode();
        }

        [Fact]
        public void HaveSuccessStatusCode_WhenExpectedToFail_ShouldFail()
        {
            _subject.StatusCode = HttpStatusCode.NotFound;

            Action act = () => _subject.Should().HaveSuccessStatusCode();

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveSuccessStatusCode_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.StatusCode = HttpStatusCode.NoContent;

            _subject.Should().HaveSuccessStatusCode();
        }

        [Fact]
        public void HaveRedirectionStatusCode_WhenExpectedToFail_ShouldFail()
        {
            _subject.StatusCode = HttpStatusCode.Created;

            Action act = () => _subject.Should().HaveRedirectionStatusCode();

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveRedirectionStatusCode_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.StatusCode = HttpStatusCode.Redirect;

            _subject.Should().HaveRedirectionStatusCode();
        }

        [Fact]
        public void HaveClientErrorStatusCode_WhenExpectedToFail_ShouldFail()
        {
            _subject.StatusCode = HttpStatusCode.ServiceUnavailable;

            Action act = () => _subject.Should().HaveClientErrorStatusCode();

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveClientErrorStatusCode_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.StatusCode = HttpStatusCode.Conflict;

            _subject.Should().HaveClientErrorStatusCode();
        }

        [Fact]
        public void HaveServerErrorStatusCode_WhenExpectedToFail_ShouldFail()
        {
            _subject.StatusCode = HttpStatusCode.Forbidden;

            Action act = () => _subject.Should().HaveServerErrorStatusCode();

            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void HaveServerErrorStatusCode_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.StatusCode = HttpStatusCode.InternalServerError;

            _subject.Should().HaveServerErrorStatusCode();
        }

        readonly HttpResponseMessage _subject;

        public HttpResponseMessageAssertionsTest_StatusCodes()
        {
            _subject = new HttpResponseMessage();
        }
    }
}
