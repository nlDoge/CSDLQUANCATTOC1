using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QLQUANCATTOC.Models;

namespace QLQUANCATTOC.Data;

public partial class quancattocContext : DbContext
{
    public quancattocContext()
    {
    }

    public quancattocContext(DbContextOptions<quancattocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<CuaHang> CuaHangs { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LichHen> LichHens { get; set; }

    public virtual DbSet<LichLamViec> LichLamViecs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhanVienLichLamViec> NhanVienLichLamViecs { get; set; }

    public virtual DbSet<PhanHoi> PhanHois { get; set; }

    public virtual DbSet<QuanLy> QuanLies { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThanhToan1> ThanhToan1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-K559S3VB\\SQLEXPRESS;Database=quancattoc;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__Chi_tiet__527FA443D322DDE7");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietHoaDons).HasConstraintName("fk_dv1");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietHoaDons)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_sp");
        });

        modelBuilder.Entity<CuaHang>(entity =>
        {
            entity.HasKey(e => e.MaCuaHang).HasName("PK__Cua_hang__6C45CD1F18BFAE75");

            entity.HasOne(d => d.MaNguoiQuanLyNavigation).WithMany(p => p.CuaHangs).HasConstraintName("fk_ql");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("pk_dv");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("pk_kh");
        });

        modelBuilder.Entity<LichHen>(entity =>
        {
            entity.HasKey(e => e.MaLichHen).HasName("pk_lichhen");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.LichHens)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_dv");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.LichHens)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_kh2");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.LichHens)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_nv");
        });

        modelBuilder.Entity<LichLamViec>(entity =>
        {
            entity.HasKey(e => e.MaCaLam).HasName("pk_lich");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("pk_nv");
        });

        modelBuilder.Entity<NhanVienLichLamViec>(entity =>
        {
            entity.HasKey(e => new { e.MaNhanVien, e.MaCaLam }).HasName("pk_key");

            entity.HasOne(d => d.MaCaLamNavigation).WithMany(p => p.NhanVienLichLamViecs).HasConstraintName("fk_key");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.NhanVienLichLamViecs).HasConstraintName("fk_key1");
        });

        modelBuilder.Entity<PhanHoi>(entity =>
        {
            entity.HasKey(e => e.MaPhanHoi).HasName("pk_ph");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.PhanHois)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_kh");
        });

        modelBuilder.Entity<QuanLy>(entity =>
        {
            entity.HasKey(e => e.MaNguoiQuanLy).HasName("PK__Quan_ly__A4EEAA03B7480A96");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__San_pham__CAFDABB870A7D21D");
        });

        modelBuilder.Entity<ThanhToan1>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__Thanh_to__925E77ADE098A735");

            entity.HasOne(d => d.MaCuaHangNavigation).WithMany(p => p.ThanhToan1s)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_ch12");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.ThanhToan1s)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_kh12");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
