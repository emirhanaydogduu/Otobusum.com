using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Bilet")]
public partial class Bilet
{
    [Key]
    [Column("bilet_id")]
    public int BiletId { get; set; }

    [Column("yolcu_id")]
    public int YolcuId { get; set; }

    [Column("sefer_id")]
    public int SeferId { get; set; }

    [Column("koltuk_no")]
    public int KoltukNo { get; set; }

    [Column("satis_tarihi", TypeName = "datetime")]
    public DateTime SatisTarihi { get; set; }

    [InverseProperty("Bilet")]
    public virtual ICollection<Odeme> Odemes { get; set; } = new List<Odeme>();

    [ForeignKey("SeferId")]
    [InverseProperty("Bilets")]
    public virtual Sefer Sefer { get; set; } = null!;

    [ForeignKey("YolcuId")]
    [InverseProperty("Bilets")]
    public virtual Yolcu Yolcu { get; set; } = null!;
}
