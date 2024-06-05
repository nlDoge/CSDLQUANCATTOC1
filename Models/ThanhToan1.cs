using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Thanh_toan1")]
public partial class ThanhToan1
{
    [Key]
    [Column("Ma_thanh_toan")]
    [StringLength(20)]
    public string MaThanhToan { get; set; } = null!;

    [Column("Ma_khach_hang")]
    [StringLength(20)]
    public string? MaKhachHang { get; set; }

    [Column("So_tien_thanh_toan")]
    public int? SoTienThanhToan { get; set; }

    [Column("Ngay_thanh_toan")]
    public DateOnly? NgayThanhToan { get; set; }

    [Column("Phuong_thuc_thanh_toan")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PhuongThucThanhToan { get; set; }

    [Column("Ma_cua_hang")]
    [StringLength(20)]
    public string? MaCuaHang { get; set; }

    [Column("Ten_cua_hang")]
    [StringLength(30)]
    public string? TenCuaHang { get; set; }

    [ForeignKey("MaCuaHang")]
    [InverseProperty("ThanhToan1s")]
    public virtual CuaHang? MaCuaHangNavigation { get; set; }

    [ForeignKey("MaKhachHang")]
    [InverseProperty("ThanhToan1s")]
    public virtual KhachHang? MaKhachHangNavigation { get; set; }
}
