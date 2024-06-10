namespace ERP.Models
{
    public class DostupnaVelicina
    {
        public  int artikal_id { get; set; }
        public int velicina_id { get; set; }

        public Artikal Artikal { get; set; }

        public Velicine Velicine { get; set; }
    }
}
