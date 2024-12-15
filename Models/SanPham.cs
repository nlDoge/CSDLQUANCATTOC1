using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("San_pham")]
public partial class SanPham
{
    [Key]
    [Column("Ma_san_pham")]
    [StringLength(20)]
    public string MaSanPham { get; set; } = null!;

    [Column("Ten_san_pham")]
    [StringLength(30)]
    public string? TenSanPham { get; set; }

    [Column("Gia_san_pham")]
    public int? GiaSanPham { get; set; }

    [Column("So_luong")]
    public int? SoLuong { get; set; }

    [Column("Mo_ta")]
    [StringLength(100)]
    public string? MoTa { get; set; }

    [InverseProperty("MaSanPhamNavigation")]
    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
