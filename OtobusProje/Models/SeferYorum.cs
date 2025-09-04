using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("SeferYorum")]
public partial class SeferYorum
{
    [Key]
    [Column("yorum_id")]
    public int YorumId { get; set; }

    [Column("sefer_id")]
    public int SeferId { get; set; }

    [ForeignKey("SeferId")]
    [InverseProperty("SeferYorums")]
    public virtual Sefer Sefer { get; set; } = null!;

    [ForeignKey("YorumId")]
    [InverseProperty("SeferYorum")]
    public virtual Yorum Yorum { get; set; } = null!;
}
