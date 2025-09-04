using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[PrimaryKey("RotaId", "DurakId")]
[Table("Rota_Durak")]
public partial class RotaDurak
{
    [Key]
    [Column("rota_id")]
    public int RotaId { get; set; }

    [Key]
    [Column("durak_id")]
    public int DurakId { get; set; }

    [Column("durak_sirasi")]
    public int DurakSirasi { get; set; }

    [ForeignKey("DurakId")]
    [InverseProperty("RotaDuraks")]
    public virtual Durak Durak { get; set; } = null!;

    [ForeignKey("RotaId")]
    [InverseProperty("RotaDuraks")]
    public virtual Rotum Rota { get; set; } = null!;
}
