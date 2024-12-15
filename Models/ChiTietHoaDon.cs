using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Chi_tiet_hoa_don")]
public partial class ChiTietHoaDon
{
    [Key]
    [Column("Ma_hoa_don")]
    [StringLength(20)]
    public string MaHoaDon { get; set; } = null!;

    [Column("Ma_thanh_toan")]
    [StringLength(20)]
    public string MaThanhToan { get; set; } = null!;

    [Column("Ma_san_pham")]
    [StringLength(20)]
    public string? MaSanPham { get; set; }

    [Column("Tien_san_pham")]
    public int? TienSanPham { get; set; }

    [Column("Ma_dich_vu")]
    [StringLength(20)]
    public string? MaDichVu { get; set; }

    [Column("Tien_dich_vu")]
    public int? TienDichVu { get; set; }

    [ForeignKey("MaDichVu")]
    [InverseProperty("ChiTietHoaDons")]
    public virtual DichVu? MaDichVuNavigation { get; set; }

    [ForeignKey("MaSanPham")]
    [InverseProperty("ChiTietHoaDons")]
    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
