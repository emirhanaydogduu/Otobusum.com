using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Odeme")]
public partial class Odeme
{
    [Key]
    [Column("odeme_id")]
    public int OdemeId { get; set; }

    [Column("bilet_id")]
    public int BiletId { get; set; }

    [Column("odeme_tutari", TypeName = "decimal(10, 2)")]
    public decimal OdemeTutari { get; set; }

    [Column("odeme_tarihi", TypeName = "datetime")]
    public DateTime OdemeTarihi { get; set; }

    [Column("odeme_tipi")]
    [StringLength(20)]
    public string? OdemeTipi { get; set; }

    [ForeignKey("BiletId")]
    [InverseProperty("Odemes")]
    public virtual Bilet Bilet { get; set; } = null!;
}
