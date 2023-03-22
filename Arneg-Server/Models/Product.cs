namespace Arneg_Server.Models 
{ 
    public class Product
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public byte[] PhotoData { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Volume { get; set; }
        public int ColdStoreVolume { get; set; }
        public int RefrigeratoryVolume { get; set; }
        public string EnergyClass { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
