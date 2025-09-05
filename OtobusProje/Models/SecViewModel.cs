using Microsoft.AspNetCore.Mvc;
using OtobusProje.Models;
public class SecViewModel
{
    public Sefer Sefer { get; set; }
    public List<int> DoluKoltuklar { get; set; }
    public List<int> BosKoltuklar { get; set; }
    public Bilet Bilet { get; set; }
}

