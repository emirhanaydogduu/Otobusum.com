using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("OtobusYorum")]
public partial class OtobusYorum
{
    [Key]
    [Column("yorum_id")]
    public int YorumId { get; set; }

    [Column("otobus_id")]
    public int OtobusId { get; set; }

    [ForeignKey("OtobusId")]
    [InverseProperty("OtobusYorums")]
    public virtual Otobu Otobus { get; set; } = null!;

    [ForeignKey("YorumId")]
    [InverseProperty("OtobusYorum")]
    public virtual Yorum Yorum { get; set; } = null!;
}
