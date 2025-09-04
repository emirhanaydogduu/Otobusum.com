using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Bakim")]
public partial class Bakim
{
    [Key]
    [Column("bakim_id")]
    public int BakimId { get; set; }

    [Column("otobus_id")]
    public int OtobusId { get; set; }

    [Column("personel_id")]
    public int PersonelId { get; set; }

    [Column("tarih")]
    public DateOnly Tarih { get; set; }

    [Column("aciklama")]
    [StringLength(200)]
    public string? Aciklama { get; set; }

    [ForeignKey("OtobusId")]
    [InverseProperty("Bakims")]
    public virtual Otobu Otobus { get; set; } = null!;

    [ForeignKey("PersonelId")]
    [InverseProperty("Bakims")]
    public virtual Personel Personel { get; set; } = null!;
}
