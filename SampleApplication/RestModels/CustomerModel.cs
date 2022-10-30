using System.Collections.Generic;

namespace SampleApplication.RestModels;

public class CustomerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<string> Addresses { get; set; }
}