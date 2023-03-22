namespace Arneg_Server.Models
{
    public class Order
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        IEnumerable<Guid>? ProductIds { get; set; }
    }
}
