using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Personel")]
public partial class Personel
{
    [Key]
    [Column("personel_id")]
    public int PersonelId { get; set; }

    [Column("ad")]
    [StringLength(50)]
    public string Ad { get; set; } = null!;

    [Column("soyad")]
    [StringLength(50)]
    public string Soyad { get; set; } = null!;

    [Column("gorev")]
    [StringLength(50)]
    public string? Gorev { get; set; }

    [Column("telefon")]
    [StringLength(15)]
    public string? Telefon { get; set; }

    [InverseProperty("Personel")]
    public virtual ICollection<Bakim> Bakims { get; set; } = new List<Bakim>();

    [InverseProperty("Personel")]
    public virtual ICollection<Sefer> Sefers { get; set; } = new List<Sefer>();
}
