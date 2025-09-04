using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

[Table("Yolcu")]
[Index("TcNo", Name = "UQ__Yolcu__E61FE7CA6EF1521D", IsUnique = true)]
public partial class Yolcu
{
    [Key]
    [Column("yolcu_id")]
    public int YolcuId { get; set; }

    [Column("ad")]
    [StringLength(50)]
    public string Ad { get; set; } = null!;

    [Column("soyad")]
    [StringLength(50)]
    public string Soyad { get; set; } = null!;

    [Column("tc_no")]
    [StringLength(11)]
    [Unicode(false)]
    public string TcNo { get; set; } = null!;

    [Column("telefon")]
    [StringLength(15)]
    public string? Telefon { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [InverseProperty("Yolcu")]
    public virtual ICollection<Bilet> Bilets { get; set; } = new List<Bilet>();

    [InverseProperty("Yolcu")]
    public virtual ICollection<Rezervasyon> Rezervasyons { get; set; } = new List<Rezervasyon>();

    [InverseProperty("Yolcu")]
    public virtual ICollection<Yorum> Yorums { get; set; } = new List<Yorum>();
}
