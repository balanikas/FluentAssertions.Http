using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using FluentAssertions.Http.Internal;
using FluentAssertions.Primitives;

namespace FluentAssertions.Http
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpResponseMessageAssertionsExtensions
    {
        /// <summary>
        ///     Asserts that the <see cref="HttpContent" /> is equal to the specified <paramref name="expected" /> value.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="expected">The expected content</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContent(
            this HttpResponseMessageAssertions assertions,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = assertions.Subject.GetContent();
                actual.Should().BeEquivalentTo(expected, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }


        /// <summary>
        ///     Asserts that the <see cref="HttpContent" /> is equal to the specified <paramref name="expected" /> value.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="expected">The expected content of type <typeparamref name="T" /></param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContent<T>(
            this HttpResponseMessageAssertions assertions,
            T expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = assertions.Subject.GetContentAs<T>();
                actual.Should().BeEquivalentTo(expected, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpContent" /> is equal to the specified <paramref name="expected" /> value.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="expected">The expected content of type <sparamref name="T" />.</param>
        /// <param name="options">The equivalency options.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContent<T>(
            this HttpResponseMessageAssertions assertions,
            T expected,
            Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> options,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = assertions.Subject.GetContentAs<T>();
                actual.Should().BeEquivalentTo(expected, options, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpContent" /> is equal to the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="predicate">The expression.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContentMatching<T>(
            this HttpResponseMessageAssertions assertions,
            Expression<Func<T, bool>> predicate,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = assertions.Subject.GetContentAs<T>();
                actual.Should().Match(predicate, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpContent" /> is equal to the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="predicate">The expression.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContentMatching(
            this HttpResponseMessageAssertions assertions,
            Expression<Func<string, bool>> predicate,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected response content {reason}, but HttpResponseMessage was <null>.");

            if (success)
            {
                var actual = assertions.Subject.GetContent();
                actual.Should().Match(predicate, because, becauseArgs);
            }

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain a <paramref name="headerName" />
        ///     header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveResponseHeader(
            this HttpResponseMessageAssertions assertions,
            string headerName,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected header {0} to exist{reason}, but HttpResponseMessage was <null>.", headerName);

            if (success)
                Execute.Assertion
                    .ForCondition(assertions.Subject.Headers.TryGetValues(headerName, out _))
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected header {0} to exist{reason}, but it does not exist.", headerName);

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="headerName" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The expected header value in <paramref name="headerName" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValue(
            this HttpResponseMessageAssertions assertions,
            string headerName,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return assertions.HaveResponseHeaderValues(headerName, new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="header" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="header">The header to find.</param>
        /// <param name="expected">The expected header value in the <paramref name="header" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValue(
            this HttpResponseMessageAssertions assertions,
            HttpResponseHeader header,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return assertions.HaveResponseHeaderValues(header.GetName(), new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="header" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="header">The header to find.</param>
        /// <param name="expected">The expected header values in the <paramref name="header" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValues(
            this HttpResponseMessageAssertions assertions,
            HttpResponseHeader header,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            return assertions.HaveResponseHeaderValues(header.GetName(), expected, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="headerName" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The expected header values to find in <paramref name="headerName" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveResponseHeaderValues(
            this HttpResponseMessageAssertions assertions,
            string headerName,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected value(s) {0} to exist in header {1}{reason}, but HttpResponseMessage was <null>.", expected, headerName);

            if (success)
                Execute.Assertion
                    .ForCondition(IsInResponseHeader(assertions.Subject, headerName, expected.ToArray()))
                    .BecauseOf(because, becauseArgs)
                    .FailWith(
                        "Expected value(s) {0} to exist in header {1}{reason}, but found {2}.",
                        expected, headerName, GetResponseHeaderValuesOrDefault(assertions.Subject, headerName));

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> content headers i contain a <paramref name="headerName" />
        ///     header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContentHeader(
            this HttpResponseMessageAssertions assertions,
            string headerName,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected header {0} to exist{reason}, but HttpResponseMessage was <null>.", headerName);

            if (success)
                Execute.Assertion
                    .ForCondition(assertions.Subject.Content.Headers.TryGetValues(headerName, out _))
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected header {0} to exist{reason}, but it does not exist.", headerName);

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="headerName" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The header value to find in <paramref name="headerName" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValue(
            this HttpResponseMessageAssertions assertions,
            string headerName,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return assertions.HaveContentHeaderValues(headerName, new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="header" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="header">The name of the header to find.</param>
        /// <param name="expected">The header value to find in <paramref name="header" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValue(
            this HttpResponseMessageAssertions assertions,
            HttpResponseHeader header,
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            return assertions.HaveContentHeaderValues(header.GetName(), new[] { expected }, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="header" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="header">The name of the header to find.</param>
        /// <param name="expected">The header values to find in <paramref name="header" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValues(
            this HttpResponseMessageAssertions assertions,
            HttpResponseHeader header,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            return assertions.HaveContentHeaderValues(header.GetName(), expected, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the <see cref="HttpResponseMessage" /> response headers contain <paramref name="expected" /> in
        ///     <paramref name="headerName" /> header.
        /// </summary>
        /// <param name="assertions"></param>
        /// <param name="headerName">The name of the header to find.</param>
        /// <param name="expected">The header values to find in <paramref name="headerName" />.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        public static AndConstraint<HttpResponseMessageAssertions> HaveContentHeaderValues(
            this HttpResponseMessageAssertions assertions,
            string headerName,
            IEnumerable<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            var success = Execute.Assertion
                .ForCondition(assertions.Subject != null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected value(s) {0} to exist in header {1}{reason}, but HttpResponseMessage was <null>.", expected, headerName);

            if (success)
            {
                var condition = IsInContentHeader(assertions.Subject, headerName, expected.ToArray());
                Execute.Assertion
                    .ForCondition(condition)
                    .BecauseOf(because, becauseArgs)
                    .FailWith(
                        "Expected value(s) {0} to exist in header {1}{reason}, but found {2}", expected, headerName,
                        GetContentHeaderValuesOrDefault(assertions.Subject, headerName));
            }

            return new AndConstraint<HttpResponseMessageAssertions>(assertions);
        }

        private static bool IsInContentHeader(
            HttpResponseMessage subject,
            string headerName,
            params string[] headerValues)
        {
            return subject.Content.Headers.TryGetValues(headerName, out var values) && headerValues.All(x => values.Contains(x));
        }

        private static IEnumerable<string> GetResponseHeaderValuesOrDefault(
            HttpResponseMessage subject,
            string headerName)
        {
            return subject.Headers.TryGetValues(headerName, out var values) ? values : Enumerable.Empty<string>();
        }

        private static IEnumerable<string> GetContentHeaderValuesOrDefault(
            HttpResponseMessage subject,
            string headerName)
        {
            return subject.Content.Headers.TryGetValues(headerName, out var values) ? values : Enumerable.Empty<string>();
        }

        private static bool IsInResponseHeader(
            HttpResponseMessage subject,
            string headerName,
            params string[] headerValues)
        {
            return subject.Headers.TryGetValues(headerName, out var values) && headerValues.All(x => values.Contains(x));
        }
    }
}