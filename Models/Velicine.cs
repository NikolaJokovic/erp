namespace ERP.Models
{
    public class Velicine
    {
        public int id { get; set; }

        public int broj { get; set; }

        public ICollection<DostupnaVelicina> DostupnaVelicina { get; set; }
    }
}
