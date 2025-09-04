using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Durak")]
public partial class Durak
{
    [Key]
    [Column("durak_id")]
    public int DurakId { get; set; }

    [Column("ad")]
    [StringLength(50)]
    public string Ad { get; set; } = null!;

    [Column("sehir")]
    [StringLength(50)]
    public string? Sehir { get; set; }

    [InverseProperty("Durak")]
    public virtual ICollection<RotaDurak> RotaDuraks { get; set; } = new List<RotaDurak>();
}
