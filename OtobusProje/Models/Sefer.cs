using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Sefer")]
public partial class Sefer
{
    [Key]
    [Column("sefer_id")]
    public int SeferId { get; set; }

    [Column("kalkis")]
    [StringLength(50)]
    public string Kalkis { get; set; } = null!;

    [Column("varis")]
    [StringLength(50)]
    public string Varis { get; set; } = null!;

    [Column("tarih")]
    public DateOnly Tarih { get; set; }

    [Column("saat")]
    public TimeOnly Saat { get; set; }

    [Column("fiyat", TypeName = "decimal(10, 2)")]
    public decimal Fiyat { get; set; }

    [Column("otobus_id")]
    public int OtobusId { get; set; }

    [Column("sofor_id")]
    public int SoforId { get; set; }

    [Column("personel_id")]
    public int PersonelId { get; set; }

    [Column("rota_id")]
    public int? RotaId { get; set; }

    [InverseProperty("Sefer")]
    public virtual ICollection<Bilet> Bilets { get; set; } = new List<Bilet>();

    [ForeignKey("OtobusId")]
    [InverseProperty("Sefers")]
    public virtual Otobu Otobus { get; set; } = null!;

    [ForeignKey("PersonelId")]
    [InverseProperty("Sefers")]
    public virtual Personel Personel { get; set; } = null!;

    [InverseProperty("Sefer")]
    public virtual ICollection<Rezervasyon> Rezervasyons { get; set; } = new List<Rezervasyon>();

    [ForeignKey("RotaId")]
    [InverseProperty("Sefers")]
    public virtual Rotum? Rota { get; set; }

    [InverseProperty("Sefer")]
    public virtual ICollection<SeferYorum> SeferYorums { get; set; } = new List<SeferYorum>();

    [ForeignKey("SoforId")]
    [InverseProperty("Sefers")]
    public virtual Sofor Sofor { get; set; } = null!;
}
