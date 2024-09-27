namespace NestHubPlatform.Reservations.Domain.Model.Aggregates;

public partial class Reservation
{
    public int Id { get; }
    public int LocalId { get; private set; } 
    public int TotalAmount { get; private set; }
    public int NumberPerson { get; private set; }
    
    public Reservation(int localId, int totalAmount, int numberPerson)
    {
        LocalId = localId;
        TotalAmount = totalAmount;
        NumberPerson = numberPerson;
    }
}