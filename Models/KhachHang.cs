using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Khach_hang")]
public partial class KhachHang
{
    [Key]
    [Column("Ma_khach_hang")]
    [StringLength(20)]
    public string MaKhachHang { get; set; } = null!;

    [Column("Ten_khach_hang")]
    [StringLength(50)]
    public string? TenKhachHang { get; set; }

    [Column("SDT")]
    public int? Sdt { get; set; }

    [StringLength(40)]
    public string? Email { get; set; }

    [Column("Dia_chi")]
    [StringLength(40)]
    public string? DiaChi { get; set; }

    [InverseProperty("MaKhachHangNavigation")]
    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();

    [InverseProperty("MaKhachHangNavigation")]
    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();

    [InverseProperty("MaKhachHangNavigation")]
    public virtual ICollection<ThanhToan1> ThanhToan1s { get; set; } = new List<ThanhToan1>();
}
