using System.ComponentModel.DataAnnotations;

public class Article
{
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
        
}