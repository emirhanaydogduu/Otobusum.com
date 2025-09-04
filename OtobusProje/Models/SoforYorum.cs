using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("SoforYorum")]
public partial class SoforYorum
{
    [Key]
    [Column("yorum_id")]
    public int YorumId { get; set; }

    [Column("sofor_id")]
    public int SoforId { get; set; }

    [ForeignKey("SoforId")]
    [InverseProperty("SoforYorums")]
    public virtual Sofor Sofor { get; set; } = null!;

    [ForeignKey("YorumId")]
    [InverseProperty("SoforYorum")]
    public virtual Yorum Yorum { get; set; } = null!;
}
