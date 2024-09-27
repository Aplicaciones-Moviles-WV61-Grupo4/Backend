namespace NestHubPlatform.Reviews.Domain.Model.Aggregates;

public class Review
{
    public int Id { get; }
    public int UserId { get; private set; }  
    public int LocalId { get; private set; }
    public int Rating { get; private set; }      
    public string Comment { get; private set; }  
    
    public Review(int userId, int localId, int rating, string comment)
    {
        UserId = userId;
        LocalId = localId;
        Rating = rating;
        Comment = comment;
    }
}