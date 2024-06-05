using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[PrimaryKey("MaNhanVien", "MaCaLam")]
[Table("Nhan_vien_Lich_lam_viec")]
public partial class NhanVienLichLamViec
{
    [Key]
    [Column("Ma_nhan_vien")]
    [StringLength(20)]
    public string MaNhanVien { get; set; } = null!;

    [Key]
    [Column("Ma_ca_lam")]
    [StringLength(20)]
    public string MaCaLam { get; set; } = null!;

    [Column("mota")]
    [StringLength(100)]
    public string? Mota { get; set; }

    [ForeignKey("MaCaLam")]
    [InverseProperty("NhanVienLichLamViecs")]
    public virtual LichLamViec MaCaLamNavigation { get; set; } = null!;

    [ForeignKey("MaNhanVien")]
    [InverseProperty("NhanVienLichLamViecs")]
    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
}
