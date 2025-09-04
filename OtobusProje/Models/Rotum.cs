using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

public partial class Rotum
{
    [Key]
    [Column("rota_id")]
    public int RotaId { get; set; }

    [Column("kalkis")]
    [StringLength(50)]
    public string Kalkis { get; set; } = null!;

    [Column("varis")]
    [StringLength(50)]
    public string Varis { get; set; } = null!;

    [Column("mesafe_km")]
    public int? MesafeKm { get; set; }

    [InverseProperty("Rota")]
    public virtual ICollection<RotaDurak> RotaDuraks { get; set; } = new List<RotaDurak>();

    [InverseProperty("Rota")]
    public virtual ICollection<Sefer> Sefers { get; set; } = new List<Sefer>();
}
