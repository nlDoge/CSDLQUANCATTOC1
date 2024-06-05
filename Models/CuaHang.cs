using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Cua_hang")]
public partial class CuaHang
{
    [Key]
    [Column("Ma_cua_hang")]
    [StringLength(20)]
    public string MaCuaHang { get; set; } = null!;

    [Column("Ten_cua_hang")]
    [StringLength(40)]
    public string? TenCuaHang { get; set; }

    [Column("Dia_chi")]
    [StringLength(30)]
    public string? DiaChi { get; set; }

    [Column("SDT")]
    public int? Sdt { get; set; }

    [StringLength(30)]
    public string? Email { get; set; }

    [Column("Ma_nguoi_quan_ly")]
    [StringLength(20)]
    public string? MaNguoiQuanLy { get; set; }

    [Column("Ghi_chu")]
    [StringLength(50)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaNguoiQuanLy")]
    [InverseProperty("CuaHangs")]
    public virtual QuanLy? MaNguoiQuanLyNavigation { get; set; }

    [InverseProperty("MaCuaHangNavigation")]
    public virtual ICollection<ThanhToan1> ThanhToan1s { get; set; } = new List<ThanhToan1>();
}
