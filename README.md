# FluentAssertions.Http
Http extensions for FluentAssertions

[![CI](https://github.com/balanikas/FluentAssertions.Http/actions/workflows/dotnet.yml/badge.svg)](https://github.com/balanikas/FluentAssertions.Http/actions/workflows/dotnet.yml)

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
    //assert header exists
    response.Should().HaveHeader("headername", "expectedheadervalue");
    response.Should().HaveHeaderForTransferEncoding(new TransferCodingHeaderValue("value"));
```    
#### Content
```csharp
    //assert content by string
    response.Should().HaveContent("expectedjsonstring");
    
    //assert content by expected instance
    response.Should().HaveContent<CustomerModel>(expected);
    
    //assert content by expected instance, with additional equivalency options.
    response.Should().HaveContent<CustomerModel>(expected, options => options.Excluding(x => x.Id));
    
    //assert content by single property
    response.Should().HaveContentWithProperty<CustomerModel>(x => x.Name, "expectedname");
```
#### Combine
```csharp
    response.Should()
        .HaveStatusCode(HttpStatusCode.OK)
        .And
        .HaveHeaderForTransferEncoding(new TransferCodingHeaderValue("value"))
        .And
        .HaveHeader("customerHeader", "headerValue")
        .And
        .HaveContent<CustomerModel>(expected, options => options.Excluding(x => x.Id));
```
