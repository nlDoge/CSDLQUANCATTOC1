using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Lich_hen")]
public partial class LichHen
{
    [Key]
    [Column("Ma_lich_hen")]
    [StringLength(20)]
    public string MaLichHen { get; set; } = null!;

    [Column("Ma_khach_hang")]
    [StringLength(20)]
    public string? MaKhachHang { get; set; }

    [Column("Ma_nhan_vien")]
    [StringLength(20)]
    public string? MaNhanVien { get; set; }

    [Column("Ma_dich_vu")]
    [StringLength(20)]
    public string? MaDichVu { get; set; }

    [Column("Lich_hen")]
    public DateOnly? LichHen1 { get; set; }

    [Column("Ghi_chu")]
    [StringLength(40)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaDichVu")]
    [InverseProperty("LichHens")]
    public virtual DichVu? MaDichVuNavigation { get; set; }

    [ForeignKey("MaKhachHang")]
    [InverseProperty("LichHens")]
    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("LichHens")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
