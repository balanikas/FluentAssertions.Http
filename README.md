# FluentAssertions.Http
Http extensions for FluentAssertions

[![build and test](https://github.com/balanikas/FluentAssertions.Http/actions/workflows/dotnet.yml/badge.svg)](https://github.com/balanikas/FluentAssertions.Http/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/balanikas/FluentAssertions.Http/actions/workflows/codeql.yml/badge.svg)](https://github.com/balanikas/FluentAssertions.Http/actions/workflows/codeql.yml)

![Nuget](https://img.shields.io/nuget/v/FluentAssertions.Http)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/FluentAssertions.Http)
![Nuget](https://img.shields.io/nuget/dt/FluentAssertions.Http)
[![GitHub stars](https://img.shields.io/github/stars/balanikas/FluentAssertions.Http)](https://github.com/balanikas/FluentAssertions.Http/stargazers)

## API Docs
https://balanikas.github.io/FluentAssertions.Http/api/index.html

## Usage

##### Given a response from an http request
```csharp    
    var response = await _factory.CreateClient().GetAsync("/api/customers");
```    
##### and an expectation
```csharp
    var expected = new CustomerModel();
```
#### Status codes 
```csharp
    //assert http status code
    response.Should().HaveStatusCode(HttpStatusCode.Created);
    
    //assert http status code range
    response.Should().HaveServerErrorStatusCode();
    response.Should().HaveRedirectionStatusCode();
    response.Should().HaveClientErrorStatusCode();
    response.Should().HaveSuccessStatusCode();
```
#### Headers
```csharp
    //assert content headers
    response.Should().HaveContentHeader("X-Custom-Header");
    response.Should().HaveContentHeaderValue(HttpResponseHeader.ContentType, "application/json; charset=utf-8");
    response.Should().HaveContentHeaderValues(HttpResponseHeader.Allow, new[] { "GET", "PUT" });
    
    //assert response headers
    response.Should().HaveResponseHeader("X-Custom-Header");
    response.Should().HaveResponseHeaderValue(HttpResponseHeader.AcceptRanges, "range1");
    response.Should().HaveResponseHeaderValues(HttpResponseHeader.AcceptRanges, new []{"range1","range2"});
```    
#### Content
```csharp
    //assert string content
    response.Should().HaveContentMatching(x => x.StartsWith("hello"));
    response.Should().HaveContent("hello world");
    
    //assert typed content
    response.Should().HaveContentMatching<CustomerModel>(x => x.Name == "Alex" && x.Addresses.Count == 2);
    response.Should().HaveContent<CustomerModel>(expected);
    response.Should().HaveContent<CustomerModel>(expected, o => o.Excluding(x => x.Id)); 
```
#### Combine
```csharp
    response.Should()
        .HaveStatusCode(HttpStatusCode.OK)
        .And
        .HaveContent(expected, options => options.Excluding(x => x.Id));
```
