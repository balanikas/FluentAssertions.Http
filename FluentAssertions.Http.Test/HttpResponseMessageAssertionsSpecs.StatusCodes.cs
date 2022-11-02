using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Http.Test;

public partial class HttpResponseMessageAssertionsSpecs
{
    public class StatusCodes
    {
        private readonly HttpResponseMessage _subject;

        public StatusCodes()
        {
            _subject = new HttpResponseMessage();
        }

        [Fact]
        public void HaveStatusCode_WhenExpectedToFail_ShouldFail()
        {
            _subject.StatusCode = HttpStatusCode.Accepted;

            Action act = () => _subject.Should().HaveStatusCode(HttpStatusCode.BadGateway);

            act.Should().Throw<XunitException>().WithMessage("Expected HttpStatusCode to be HttpStatusCode.BadGateway {value: 502}, but found HttpStatusCode.Accepted {value: 202}.");
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

            act.Should().Throw<XunitException>().WithMessage("Expected HttpStatusCode to be between 100 and 199, but found HttpStatusCode.Accepted {value: 202}.");;
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

            act.Should().Throw<XunitException>().WithMessage("Expected HttpStatusCode to be between 200 and 299, but found HttpStatusCode.NotFound {value: 404}.");;
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

            act.Should().Throw<XunitException>().WithMessage("Expected HttpStatusCode to be between 300 and 399, but found HttpStatusCode.Created {value: 201}.");;
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

            act.Should().Throw<XunitException>().WithMessage("Expected HttpStatusCode to be between 400 and 499, but found HttpStatusCode.ServiceUnavailable {value: 503}.");;
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

            act.Should().Throw<XunitException>().WithMessage("Expected HttpStatusCode to be between 500 and 599, but found HttpStatusCode.Forbidden {value: 403}.");;
        }

        [Fact]
        public void HaveServerErrorStatusCode_WhenExpectedToNotFail_ShouldNotFail()
        {
            _subject.StatusCode = HttpStatusCode.InternalServerError;

            _subject.Should().HaveServerErrorStatusCode();
        }
    }
}