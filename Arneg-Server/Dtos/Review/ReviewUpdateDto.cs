namespace Arneg_Server.Dtos.Review
{
    public class ReviewUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public float Score { get; set; }
        public string Comment { get; set; }
    }
}

