using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssertions.Equivalency;
using FluentAssertions.Primitives;

namespace FluentAssertions.Http
{
    public class
        HttpResponseMessageAssertions : ReferenceTypeAssertions<HttpResponseMessage, HttpResponseMessageAssertions>
    {
        public HttpResponseMessageAssertions(HttpResponseMessage instance) : base(instance)
        {
        }

        protected override string Identifier => "HttpResponseMessage";

        public AndConstraint<HttpResponseMessageAssertions> HaveStatusCode(HttpStatusCode statusCode)
        {
            return HttpStatusAssertion(statusCode);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveInformationalStatusCode()
        {
            return IsInRange(HttpStatusCode.Continue, HttpStatusCode.SwitchingProtocols);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveSuccessStatusCode()
        {
            return IsInRange(HttpStatusCode.OK, HttpStatusCode.PartialContent);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveRedirectionStatusCode()
        {
            return IsInRange(HttpStatusCode.Ambiguous, HttpStatusCode.TemporaryRedirect);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveClientErrorStatusCode()
        {
            return IsInRange(HttpStatusCode.BadRequest, HttpStatusCode.UpgradeRequired);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveServerErrorStatusCode()
        {
            return IsInRange(HttpStatusCode.InternalServerError, HttpStatusCode.HttpVersionNotSupported);
        }

        private AndConstraint<HttpResponseMessageAssertions> IsInRange(HttpStatusCode statusCodeBegin,
            HttpStatusCode statusCodeEnd)
        {
            var query = ((HttpStatusCode[])Enum.GetValues(typeof(HttpStatusCode))).Where(x =>
                x >= statusCodeBegin && x <= statusCodeEnd);
            query.Should().Contain(Subject.StatusCode);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        private AndConstraint<HttpResponseMessageAssertions> HttpStatusAssertion(HttpStatusCode statusCode)
        {
            Subject.StatusCode.Should().Be(statusCode);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveContent(string expected)
        {
            Subject.GetContent().Should().BeEquivalentTo(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveContent<T>(T expected)
        {
            Subject.GetContentAs<T>().Should().BeEquivalentTo(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveContent<T>(T expected,
            Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> options)
        {
            Subject.GetContentAs<T>().Should().BeEquivalentTo(expected, options);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveContentWithProperty<T>(Func<T, object> subject,
            object expected)
        {
            subject.Invoke(Subject.GetContentAs<T>()).Should().BeEquivalentTo(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveHeader(string headerName, string expected)
        {
            if (Subject.Headers.TryGetValues(headerName, out var values))
                values.Should().Contain(expected);
            else
                Enumerable.Empty<string>().Should().Contain(expected);

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveHeaderForLocation(Uri expected)
        {
            Subject.Headers.Location.Should().Be(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveHeaderForServer(ProductInfoHeaderValue expected)
        {
            Subject.Headers.Server.Should().Contain(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveHeaderForETag(EntityTagHeaderValue expected)
        {
            Subject.Headers.ETag.Should().Be(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveHeaderForCacheControl(CacheControlHeaderValue expected)
        {
            Subject.Headers.CacheControl.Should().Be(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveHeaderForPragma(NameValueHeaderValue expected)
        {
            Subject.Headers.Pragma.Should().Contain(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        public AndConstraint<HttpResponseMessageAssertions> HaveHeaderForTransferEncoding(
            TransferCodingHeaderValue expected)
        {
            Subject.Headers.TransferEncoding.Should().Contain(expected);
            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }
    }
}