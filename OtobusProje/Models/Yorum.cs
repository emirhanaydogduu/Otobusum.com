using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Yorum")]
public partial class Yorum
{
    [Key]
    [Column("yorum_id")]
    public int YorumId { get; set; }

    [Column("yolcu_id")]
    public int YolcuId { get; set; }

    [Column("puan")]
    public int Puan { get; set; }

    [Column("yorum")]
    [Display(Name = "Yorum")]
    public string? Yorum1 { get; set; }

    [Column("tarih", TypeName = "datetime")]
    public DateTime? Tarih { get; set; }

    [InverseProperty("Yorum")]
    public virtual FirmaYorum? FirmaYorum { get; set; }

    [InverseProperty("Yorum")]
    public virtual OtobusYorum? OtobusYorum { get; set; }

    [InverseProperty("Yorum")]
    public virtual SeferYorum? SeferYorum { get; set; }

    [InverseProperty("Yorum")]
    public virtual SoforYorum? SoforYorum { get; set; }

    [ForeignKey("YolcuId")]
    [InverseProperty("Yorums")]
    public virtual Yolcu Yolcu { get; set; } = null!;
}
