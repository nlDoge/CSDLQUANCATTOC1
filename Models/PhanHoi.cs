using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Phan_hoi")]
public partial class PhanHoi
{
    [Key]
    [Column("Ma_phan_hoi")]
    [StringLength(20)]
    public string MaPhanHoi { get; set; } = null!;

    [Column("Ma_khach_hang")]
    [StringLength(20)]
    public string? MaKhachHang { get; set; }

    [Column("Danh_gia")]
    [StringLength(50)]
    public string? DanhGia { get; set; }

    [Column("Binh_luan")]
    [StringLength(50)]
    public string? BinhLuan { get; set; }

    [ForeignKey("MaKhachHang")]
    [InverseProperty("PhanHois")]
    public virtual KhachHang? MaKhachHangNavigation { get; set; }
}
