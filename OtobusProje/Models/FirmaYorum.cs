using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("FirmaYorum")]
public partial class FirmaYorum
{
    [Key]
    [Column("yorum_id")]
    public int YorumId { get; set; }

    [Column("firma_id")]
    public int FirmaId { get; set; }

    [ForeignKey("FirmaId")]
    [InverseProperty("FirmaYorums")]
    public virtual Firma Firma { get; set; } = null!;

    [ForeignKey("YorumId")]
    [InverseProperty("FirmaYorum")]
    public virtual Yorum Yorum { get; set; } = null!;
}
