using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Sofor")]
[Index("EhliyetNo", Name = "UQ__Sofor__CE5DBA39EBEABFF8", IsUnique = true)]
public partial class Sofor
{
    [Key]
    [Column("sofor_id")]
    public int SoforId { get; set; }

    [Column("ad")]
    [StringLength(50)]
    public string Ad { get; set; } = null!;

    [Column("soyad")]
    [StringLength(50)]
    public string Soyad { get; set; } = null!;

    [Column("ehliyet_no")]
    [StringLength(20)]
    public string EhliyetNo { get; set; } = null!;

    [Column("telefon")]
    [StringLength(15)]
    public string? Telefon { get; set; }

    [InverseProperty("Sofor")]
    public virtual ICollection<Sefer> Sefers { get; set; } = new List<Sefer>();

    [InverseProperty("Sofor")]
    public virtual ICollection<SoforYorum> SoforYorums { get; set; } = new List<SoforYorum>();
}
