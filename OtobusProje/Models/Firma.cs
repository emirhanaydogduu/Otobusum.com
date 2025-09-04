using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Firma")]
public partial class Firma
{
    [Key]
    [Column("firma_id")]
    public int FirmaId { get; set; }

    [Column("ad")]
    [StringLength(100)]
    public string Ad { get; set; } = null!;

    [Column("telefon")]
    [StringLength(15)]
    public string? Telefon { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [InverseProperty("Firma")]
    public virtual ICollection<FirmaYorum> FirmaYorums { get; set; } = new List<FirmaYorum>();

    [InverseProperty("Firma")]
    public virtual ICollection<Otobu> Otobus { get; set; } = new List<Otobu>();
}
