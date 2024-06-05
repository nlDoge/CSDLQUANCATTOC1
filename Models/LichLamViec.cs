using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Lich_lam_viec")]
public partial class LichLamViec
{
    [Key]
    [Column("Ma_ca_lam")]
    [StringLength(20)]
    public string MaCaLam { get; set; } = null!;

    [Column("Ngay_lam_viec")]
    public DateOnly? NgayLamViec { get; set; }

    public int? Ca { get; set; }

    [InverseProperty("MaCaLamNavigation")]
    public virtual ICollection<NhanVienLichLamViec> NhanVienLichLamViecs { get; set; } = new List<NhanVienLichLamViec>();
}
