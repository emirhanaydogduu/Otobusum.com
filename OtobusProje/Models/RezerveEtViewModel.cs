using System.Collections.Generic;

namespace OtobusProje.Models
{
    public class RezerveEtViewModel
    {
        public Rezervasyon Rezervasyon { get; set; }
        public List<int> BosKoltuklar { get; set; }
        public List<int> DoluKoltuklar { get; set; }
        public List<Yolcu> Yolcular { get; set; }
        public Sefer Sefer { get; set; }
    }
}
