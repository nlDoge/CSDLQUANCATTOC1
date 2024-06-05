using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Nhan_vien")]
public partial class NhanVien
{
    [Key]
    [Column("Ma_nhan_vien")]
    [StringLength(20)]
    public string MaNhanVien { get; set; } = null!;

    [Column("Ten_nhan_vien")]
    [StringLength(30)]
    public string? TenNhanVien { get; set; }

    [Column("SDT")]
    public int? Sdt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("Chuc_vu")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ChucVu { get; set; }

    [Column("Ngay_tuyen_dung")]
    public DateOnly? NgayTuyenDung { get; set; }

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<NhanVienLichLamViec> NhanVienLichLamViecs { get; set; } = new List<NhanVienLichLamViec>();
}
