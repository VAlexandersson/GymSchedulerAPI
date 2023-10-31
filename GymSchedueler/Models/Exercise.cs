namespace GymSchedueler.Models;

public class Exercise {
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string TargetArea { get; }
    public string Equipment { get; }
    public string Difficulty { get; }
    public string ImageUrl { get; }
    public DateTime LastModified { get; }

    public Exercise(Guid id, string name, string description, string targetArea, string equipment, string difficulty, string imageUrl, DateTime lastModified) {
        Id = id;
        Name = name;
        Description = description;
        TargetArea = targetArea;
        Equipment = equipment;
        Difficulty = difficulty;
        ImageUrl = imageUrl;
        LastModified = lastModified;
    }
    
    
}

