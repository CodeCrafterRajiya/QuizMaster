using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace quezemasterNew.Models;

public partial class QuizeMasterNewContext : DbContext
{
    public QuizeMasterNewContext()
    {
    }

    public QuizeMasterNewContext(DbContextOptions<QuizeMasterNewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Tbl20englisgTestFinalDetail> Tbl20englisgTestFinalDetails { get; set; }

    public virtual DbSet<Tbl20testFinalDetail> Tbl20testFinalDetails { get; set; }

    public virtual DbSet<TblClass10EnglisgTestFinalDetail> TblClass10EnglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClass11EnglisgTestFinalDetail> TblClass11EnglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClass12EnglisgTestFinalDetail> TblClass12EnglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClass6EnglisgTestFinalDetail> TblClass6EnglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClass7EnglisgTestFinalDetail> TblClass7EnglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClass8EnglisgTestFinalDetail> TblClass8EnglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClass9EnglisgTestFinalDetail> TblClass9EnglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClassBpscenglisgTestFinalDetail> TblClassBpscenglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblClassGkenglisgTestFinalDetail> TblClassGkenglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblEnquiryFormDetail> TblEnquiryFormDetails { get; set; }

    public virtual DbSet<TblLtenglisgTestFinalDetail> TblLtenglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblPgtenglisgTestFinalDetail> TblPgtenglisgTestFinalDetails { get; set; }

    public virtual DbSet<TblQuestionPeparEnglish20Detail> TblQuestionPeparEnglish20Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClass10Detail> TblQuestionPeparEnglishClass10Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClass11Detail> TblQuestionPeparEnglishClass11Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClass12Detail> TblQuestionPeparEnglishClass12Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClass6Detail> TblQuestionPeparEnglishClass6Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClass7Detail> TblQuestionPeparEnglishClass7Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClass8Detail> TblQuestionPeparEnglishClass8Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClass9Detail> TblQuestionPeparEnglishClass9Details { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClassBpscdetail> TblQuestionPeparEnglishClassBpscdetails { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishClassGkdetail> TblQuestionPeparEnglishClassGkdetails { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishLtdetail> TblQuestionPeparEnglishLtdetails { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishPgtdetail> TblQuestionPeparEnglishPgtdetails { get; set; }

    public virtual DbSet<TblQuestionPeparEnglishTgtdetail> TblQuestionPeparEnglishTgtdetails { get; set; }

    public virtual DbSet<TblQuezIndex20Detail> TblQuezIndex20Details { get; set; }

    public virtual DbSet<TblQuezIndexClass10Detail> TblQuezIndexClass10Details { get; set; }

    public virtual DbSet<TblQuezIndexClass11Detail> TblQuezIndexClass11Details { get; set; }

    public virtual DbSet<TblQuezIndexClass12Detail> TblQuezIndexClass12Details { get; set; }

    public virtual DbSet<TblQuezIndexClass6Detail> TblQuezIndexClass6Details { get; set; }

    public virtual DbSet<TblQuezIndexClass7Detail> TblQuezIndexClass7Details { get; set; }

    public virtual DbSet<TblQuezIndexClass8Detail> TblQuezIndexClass8Details { get; set; }

    public virtual DbSet<TblQuezIndexClass9Detail> TblQuezIndexClass9Details { get; set; }

    public virtual DbSet<TblQuezIndexClassBpscdetail> TblQuezIndexClassBpscdetails { get; set; }

    public virtual DbSet<TblQuezIndexClassGkdetail> TblQuezIndexClassGkdetails { get; set; }

    public virtual DbSet<TblQuezIndexLtdetail> TblQuezIndexLtdetails { get; set; }

    public virtual DbSet<TblQuezIndexPgtdetail> TblQuezIndexPgtdetails { get; set; }

    public virtual DbSet<TblQuezIndexTgtdetail> TblQuezIndexTgtdetails { get; set; }

    public virtual DbSet<TblTestSiriseClass10Detail> TblTestSiriseClass10Details { get; set; }

    public virtual DbSet<TblTestSiriseClass11Detail> TblTestSiriseClass11Details { get; set; }

    public virtual DbSet<TblTestSiriseClass12Detail> TblTestSiriseClass12Details { get; set; }

    public virtual DbSet<TblTestSiriseClass6Detail> TblTestSiriseClass6Details { get; set; }

    public virtual DbSet<TblTestSiriseClass7Detail> TblTestSiriseClass7Details { get; set; }

    public virtual DbSet<TblTestSiriseClass8Detail> TblTestSiriseClass8Details { get; set; }

    public virtual DbSet<TblTestSiriseClass9Detail> TblTestSiriseClass9Details { get; set; }

    public virtual DbSet<TblTestSiriseClassBpscdetail> TblTestSiriseClassBpscdetails { get; set; }

    public virtual DbSet<TblTestSiriseClassGkdetail> TblTestSiriseClassGkdetails { get; set; }

    public virtual DbSet<TblTestSiriseDetail> TblTestSiriseDetails { get; set; }

    public virtual DbSet<TblTgtenglisgTestFinalDetail> TblTgtenglisgTestFinalDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=MAURYA\\SQLEXPRESS;Database=QuizeMasterNew;User Id=Maurya;Password=Maurya;TrustServerCertificate=True;Trusted_Connection=True;");
        => optionsBuilder.UseSqlServer("Server=LAPTOP-P8ITR1TI;Database=QuizMaster;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FormalRoleName).HasMaxLength(250);
            entity.Property(e => e.Name1).HasMaxLength(250);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetUserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserRoles).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Tbl20englisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_20ENglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<Tbl20testFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_20TestFinalDetails");

            entity.Property(e => e.DatetimeStatmp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblClass10EnglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_Class10EnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClass11EnglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_Class11EnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClass12EnglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_Class12EnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClass6EnglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_Class6EnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClass7EnglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_Class7EnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClass8EnglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_Class8EnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClass9EnglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_Class9EnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClassBpscenglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_ClassBPSCEnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblClassGkenglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_ClassGKEnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblEnquiryFormDetail>(entity =>
        {
            entity.ToTable("tbl_EnquiryFormDetails");

            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.EmailId).HasMaxLength(255);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TblLtenglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_LTEnglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblPgtenglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_PGTENglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        modelBuilder.Entity<TblQuestionPeparEnglish20Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglish20Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClass10Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClass10Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClass11Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClass11Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClass12Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClass12Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClass6Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClass6Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClass7Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClass7Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClass8Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClass8Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClass9Detail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClass9Details");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClassBpscdetail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClassBPSCDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishClassGkdetail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishClassGKDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishLtdetail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishLTDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishPgtdetail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishPGTDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuestionPeparEnglishTgtdetail>(entity =>
        {
            entity.ToTable("Tbl_QuestionPeparEnglishTGTDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblQuezIndex20Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndex20Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClass10Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClass10Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClass11Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClass11Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClass12Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClass12Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClass6Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClass6Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClass7Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClass7Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClass8Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClass8Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClass9Detail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClass9Details");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClassBpscdetail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClassBPSCDetails");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexClassGkdetail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexClassGKDetails");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexLtdetail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexLTDetails");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexPgtdetail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexPGTDetails");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblQuezIndexTgtdetail>(entity =>
        {
            entity.ToTable("Tbl_QuezIndexTGTDetails");

            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.SubjectName).HasMaxLength(255);
        });

        modelBuilder.Entity<TblTestSiriseClass10Detail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClass10Details");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClass11Detail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClass11Details");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClass12Detail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClass12Details");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClass6Detail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClass6Details");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClass7Detail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClass7Details");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClass8Detail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClass8Details");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClass9Detail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClass9Details");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClassBpscdetail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClassBPSCDetails");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseClassGkdetail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseClassGKDetails");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTestSiriseDetail>(entity =>
        {
            entity.HasKey(e => e.TestIndexId);

            entity.ToTable("Tbl_TestSiriseDetails");

            entity.Property(e => e.TestIndexId).HasMaxLength(250);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestName).HasMaxLength(200);
        });

        modelBuilder.Entity<TblTgtenglisgTestFinalDetail>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("Tbl_TGTENglisgTestFinalDetails");

            entity.Property(e => e.DatetimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TestSerise).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
