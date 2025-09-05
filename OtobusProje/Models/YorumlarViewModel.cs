using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace OtobusProje.Models
{
    public class YorumlarViewModel
    {
        public List<FirmaYorum> FirmaYorumlari { get; set; }
        public List<OtobusYorum> OtobusYorumlari { get; set; }
        public List<SeferYorum> SeferYorumlari { get; set; }
        public List<SoforYorum> SoforYorumlari { get; set; }
    }
}

