using System.ComponentModel.DataAnnotations;

namespace Arneg_Server.Dtos.Product
{
    public class ProductCreateDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public byte[] PhotoData { get; set; }
        [Required]
        public int Volume { get; set; }
        public int ColdStoreVolume { get; set; }
        public int RefrigeratoryVolume { get; set; }
        public string EnergyClass { get; set; }
    }
}

