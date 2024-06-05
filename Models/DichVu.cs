using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLQUANCATTOC.Models;

[Table("Dich_vu")]
public partial class DichVu
{
    [Key]
    [Column("Ma_dich_vu")]
    [StringLength(20)]
    public string MaDichVu { get; set; } = null!;

    [Column("Ten_dich_vu")]
    [StringLength(50)]
    public string? TenDichVu { get; set; }

    [Column("Gia_dich_vu")]
    public int? GiaDichVu { get; set; }

    [InverseProperty("MaDichVuNavigation")]
    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    [InverseProperty("MaDichVuNavigation")]
    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();
}
