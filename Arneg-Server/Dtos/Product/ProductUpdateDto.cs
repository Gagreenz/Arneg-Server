namespace Arneg_Server.Dtos.Product
{
    public class ProductUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public int? Volume { get; set; }
        public int? ColdStoreVolume { get; set; }
        public int? RefrigeratoryVolume { get; set; }
        public string EnergyClass { get; set; }
    }
}
