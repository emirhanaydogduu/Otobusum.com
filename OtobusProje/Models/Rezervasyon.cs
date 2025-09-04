using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Rezervasyon")]
public partial class Rezervasyon
{
    [Key]
    [Column("rezervasyon_id")]
    public int RezervasyonId { get; set; }

    [Column("yolcu_id")]
    public int YolcuId { get; set; }

    [Column("sefer_id")]
    public int SeferId { get; set; }

    [Column("koltuk_no")]
    public int KoltukNo { get; set; }

    [Column("rezervasyon_tarihi", TypeName = "datetime")]
    public DateTime RezervasyonTarihi { get; set; }

    [Column("durum")]
    [StringLength(20)]
    public string? Durum { get; set; }

    [ForeignKey("SeferId")]
    [InverseProperty("Rezervasyons")]
    public virtual Sefer Sefer { get; set; } = null!;

    [ForeignKey("YolcuId")]
    [InverseProperty("Rezervasyons")]
    public virtual Yolcu Yolcu { get; set; } = null!;
}
