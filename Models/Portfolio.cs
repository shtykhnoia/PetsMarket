namespace api.Models;

public class Portfolio
{
    public string AppUserId { get; set; }

    public int PetId { get; set; }
    
    public AppUser AppUser { get; set; }
    
    public Pet Pet { get; set; }
}