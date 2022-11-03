using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Http
{
    public class HttpResponseMessageAssertions : ObjectAssertions<HttpResponseMessage, HttpResponseMessageAssertions>
    {
        public HttpResponseMessageAssertions(
            HttpResponseMessage instance) : base(instance)
        {
        }

        protected override string Identifier => "HttpResponseMessage";

        /// <summary>
        /// f="HttpStatusCode"/> is equal to the specified <paramref name="expected"/> value .
        /// </summary>
        /// <param name="expected">The expected status code <see cref="HttpStatusCode"/></param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveStatusCode(
            HttpStatusCode expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected HttpStatusCode to be {0}{reason}, but HttpResponseMessage was <null>.", expected);

            if (success)
                Execute.Assertion
                    .ForCondition(Subject.StatusCode == expected)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected HttpStatusCode to be {0}{reason}, but found {1}.",
                        expected, Subject.StatusCode);

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpStatusCode"/> is informational (1xx).
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveInformationalStatusCode(
            string because = "",
            params object[] becauseArgs)
        {
            return IsInRange(100, 199, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpStatusCode"/> is successful (2xx).
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveSuccessStatusCode(
            string because = "",
            params object[] becauseArgs)
        {
            return IsInRange(200, 299, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpStatusCode"/> is redirection (3xx).
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveRedirectionStatusCode(
            string because = "",
            params object[] becauseArgs)
        {
            return IsInRange(300, 399, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpStatusCode"/> is client (4xx).
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveClientErrorStatusCode(
            string because = "",
            params object[] becauseArgs)
        {
            return IsInRange(400, 499, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpStatusCode"/> is server error (5xx).
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveServerErrorStatusCode(
            string because = "",
            params object[] becauseArgs)
        {
            return IsInRange(500, 599, because, becauseArgs);
        }



        /// <summary>
        /// Asserts that the <see cref="HttpContent"/> is equal to the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The expected content</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContent(
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = Subject.GetContent();
                actual.Should().BeEquivalentTo(expected, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpContent"/> is equal to the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The expected content of type <paramref name="T"/></param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContent<T>(
            T expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = Subject.GetContentAs<T>();
                actual.Should().BeEquivalentTo(expected, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpContent"/> is equal to the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The expected content of type <sparamref name="T"/>.</param>
        /// <param name="options">The equivalency options.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContent<T>(
            T expected,
            Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> options,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = Subject.GetContentAs<T>();
                actual.Should().BeEquivalentTo(expected, options, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpContent"/> is equal to the specified <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">The expression.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContentMatching<T>(
            Expression<Func<T, bool>> predicate,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = Subject.GetContentAs<T>();
                actual.Should().Match(predicate, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpContent"/> is equal to the specified <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">The expression.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContentMatching(
            Expression<Func<string, bool>> predicate,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = Subject.GetContent();
                actual.Should().Match(predicate, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain a <paramref name="headerName"/> header.
        /// </summary>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveResponseHeader(
            string headerName,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected header {0} to exist{reason}, but HttpResponseMessage was <null>.", headerName);

            if (success)
                Execute.Assertion
                    .ForCondition(Subject.Headers.TryGetValues(headerName, out _))
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected header {0} to exist{reason}, but it does not exist.", headerName);

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="headerName"/> header.
        /// </summary>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The expected header value in <paramref name="headerName"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValue(
            string headerName,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return HaveResponseHeaderValues(headerName, new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="header"/> header.
        /// </summary>
        /// <param name="header">The header to find.</param>
        /// <param name="expected">The expected header value in the <paramref name="header"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValue(
            HttpResponseHeader header,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return HaveResponseHeaderValues(header.GetName(), new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="header"/> header.
        /// </summary>
        /// <param name="header">The header to find.</param>
        /// <param name="expected">The expected header values in the <paramref name="header"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValues(
            HttpResponseHeader header,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            return HaveResponseHeaderValues(header.GetName(), expected, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="headerName"/> header.
        /// </summary>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The expected header values to find in <paramref name="headerName"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValues(
            string headerName,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected value(s) {0} to exist in header {1}{reason}, but HttpResponseMessage was <null>.", expected, headerName);

            if (success)
                Execute.Assertion
                    .ForCondition(IsInResponseHeader(headerName, expected.ToArray()))
                    .BecauseOf(because, becauseArgs)
                    .FailWith(
                        "Expected value(s) {0} to exist in header {1}{reason}, but found {2}.",
                        expected, headerName, GetResponseHeaderValuesOrDefault(headerName));

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> content headers i contain a <paramref name="headerName"/> header.
        /// </summary>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContentHeader(
            string headerName,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected header {0} to exist{reason}, but HttpResponseMessage was <null>.", headerName);

            if (success)
                Execute.Assertion
                    .ForCondition(Subject.Content.Headers.TryGetValues(headerName, out _))
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected header {0} to exist{reason}, but it does not exist.", headerName);

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="headerName"/> header.
        /// </summary>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The header value to find in <paramref name="headerName"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValue(
            string headerName,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return HaveContentHeaderValues(headerName, new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="header"/> header.
        /// </summary>
        /// <param name="header">The name of the header to find.</param>
        /// <param name="expected">The header value to find in <paramref name="header"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValue(
            HttpResponseHeader header,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return HaveContentHeaderValues(header.GetName(), new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="header"/> header.
        /// </summary>
        /// <param name="header">The name of the header to find.</param>
        /// <param name="expected">The header values to find in <paramref name="header"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValues(
            HttpResponseHeader header,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            return HaveContentHeaderValues(header.GetName(), expected, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="HttpResponseMessage"/> response headers contain <paramref name="expected"/> in <paramref name="headerName"/> header.
        /// </summary>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The header values to find in <paramref name="headerName"/>.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValues(
            string headerName,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected value(s) {0} to exist in header {1}{reason}, but HttpResponseMessage was <null>.", expected, headerName);

            if (success)
            {
                var condition = IsInContentHeader(headerName, expected.ToArray());
                Execute.Assertion
                    .ForCondition(condition)
                    .BecauseOf(because, becauseArgs)
                    .FailWith(
                        "Expected value(s) {0} to exist in header {1}{reason}, but found {2}", expected, headerName,
                        GetContentHeaderValuesOrDefault(headerName));
            }

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }

        private bool IsInContentHeader(
            string headerName,
            params string[] headerValues)
        {
            return Subject.Content.Headers.TryGetValues(headerName, out var values) && headerValues.All(x => values.Contains(x));
        }

        private IEnumerable<string> GetResponseHeaderValuesOrDefault(
            string headerName)
        {
            return Subject.Headers.TryGetValues(headerName, out var values) ? values : Enumerable.Empty<string>();
        }

        private IEnumerable<string> GetContentHeaderValuesOrDefault(
            string headerName)
        {
            return Subject.Content.Headers.TryGetValues(headerName, out var values) ? values : Enumerable.Empty<string>();
        }

        private bool IsInResponseHeader(
            string headerName,
            params string[] headerValues)
        {
            return Subject.Headers.TryGetValues(headerName, out var values) && headerValues.All(x => values.Contains(x));
        }
        
        private AndConstraint<HttpResponseMessageAssertions> IsInRange(
            int statusCodeBegin,
            int statusCodeEnd,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected HttpStatusCode to be between {0} and {1}{reason}, but HttpResponseMessage was <null>.",
                    statusCodeBegin, statusCodeEnd);

            if (success)
            {
                var query = ((HttpStatusCode[])Enum.GetValues(typeof(HttpStatusCode))).Where(x => (int)x >= statusCodeBegin && (int)x <= statusCodeEnd);

                Execute.Assertion
                    .ForCondition(query.Contains(Subject.StatusCode))
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected HttpStatusCode to be between {0} and {1}{reason}, but found {2}.",
                        statusCodeBegin, statusCodeEnd, Subject.StatusCode);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(this);
        }
    }
}