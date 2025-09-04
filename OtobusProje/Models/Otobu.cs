using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Index("Plaka", Name = "UQ__Otobus__0C052B2F76855E86", IsUnique = true)]
public partial class Otobu
{
    [Key]
    [Column("otobus_id")]
    public int OtobusId { get; set; }

    [Column("firma_id")]
    public int FirmaId { get; set; }

    [Column("plaka")]
    [StringLength(15)]
    public string Plaka { get; set; } = null!;

    [Column("marka")]
    [StringLength(50)]
    public string? Marka { get; set; }

    [Column("kapasite")]
    public int? Kapasite { get; set; }

    [InverseProperty("Otobus")]
    public virtual ICollection<Bakim> Bakims { get; set; } = new List<Bakim>();

    [ForeignKey("FirmaId")]
    [InverseProperty("Otobus")]
    public virtual Firma Firma { get; set; } = null!;

    [InverseProperty("Otobus")]
    public virtual ICollection<OtobusYorum> OtobusYorums { get; set; } = new List<OtobusYorum>();

    [InverseProperty("Otobus")]
    public virtual ICollection<Sefer> Sefers { get; set; } = new List<Sefer>();
}
