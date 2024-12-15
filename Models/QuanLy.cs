using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Quan_ly")]
public partial class QuanLy
{
    [Key]
    [Column("Ma_nguoi_quan_ly")]
    [StringLength(20)]
    public string MaNguoiQuanLy { get; set; } = null!;

    [Column("Ten_nguoi_quan_ly")]
    [StringLength(30)]
    public string? TenNguoiQuanLy { get; set; }

    [Column("SDT")]
    [StringLength(12)]
    public string? Sdt { get; set; }

    [StringLength(30)]
    public string? Email { get; set; }

    [Column("Dia_chi")]
    [StringLength(100)]
    public string? DiaChi { get; set; }

    [InverseProperty("MaNguoiQuanLyNavigation")]
    public virtual ICollection<CuaHang> CuaHangs { get; set; } = new List<CuaHang>();
}
