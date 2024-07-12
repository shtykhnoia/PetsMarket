using System.Net;

namespace api.Models;

public class Pet
{
    public int Id { get; set; }

    public Category Category { get; set; } = new Category();
    
    public int CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Desc { set; get; } = string.Empty;

    public int Price { get; set; }
    
    public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    

}