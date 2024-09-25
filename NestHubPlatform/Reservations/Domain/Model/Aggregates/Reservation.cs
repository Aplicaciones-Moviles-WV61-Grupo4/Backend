namespace NestHubPlatform.Reservations.Domain.Model.Aggregates;

public partial class Reservation
{
    public int Id { get; }
    public int TotalAmount { get; private set; }
    public int NumberPerson { get; private set; }
    
    public Reservation(int totalAmount, int numberPerson)
    {
        TotalAmount = totalAmount;
        NumberPerson = numberPerson;
    }
}