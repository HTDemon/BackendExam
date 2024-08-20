using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BackendExam
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Myoffice_ACPD> Myoffice_ACPD { get; init; }
        public DbSet<Myoffice_ExcuteionLog> Myoffice_ExcuteionLog { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("BackendExamHub");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

        //    modelBuilder.Entity<Myoffice_ACPD>(entity =>
        //    {
        //        entity.ToTable("Myoffice_ACPD");
        //        entity.HasKey(e => e.acpd_sid).HasName("PK_acpd_sid");
        //        entity.Property(e => e.acpd_sid).HasColumnName("").ha;
        //        entity.Property(e => e.acpd_ename);
        //        entity.Property(e => e.acpd_sname);
        //        entity.Property(e => e.acpd_email);
        //        entity.Property(e => e.acpd_status);
        //        entity.Property(e => e.acpd_stop);
        //        entity.Property(e => e.acpd_stopMemo);
        //        entity.Property(e => e.acpd_LoginID);
        //        entity.Property(e => e.acpd_LoginPW);
        //        entity.Property(e => e.acpd_memo);
        //        entity.Property(e => e.acpd_nowdatetime);
        //        entity.Property(e => e.appd_nowid);
        //        entity.Property(e => e.acpd_upddatetitme);
        //        entity.Property(e => e.acpd_updid);
        //    });

        //    modelBuilder.Entity<Myoffice_ExcuteionLog>(entity =>
        //    {
        //        entity.ToTable("Myoffice_ExcuteionLog");
        //        entity.Property(e => e.DeLog_AuthID);
        //        entity.Property(e => e.DeLog_StoredPrograms);
        //        entity.Property(e => e.DeLog_GroupID);
        //        entity.Property(e => e.DeLog_isCustomDebug);
        //        entity.Property(e => e.DeLog_ExecutionProgram);
        //        entity.Property(e => e.DeLog_ExecuteionInfo);
        //        entity.Property(e => e.DeLog_VerifyNeeded);
        //        entity.Property(e => e.exeLog_nowdatetime);
        //    });
        //}
    }


    internal class Myoffice_ACPD
    {
        [Key]
        [Column(TypeName = "char(20)")]
        public string acpd_sid { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string acpd_cname { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string acpd_ename { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string acpd_sname { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string acpd_email { get; set; }
        [Column(TypeName = "tinyint")]
        public byte acpd_status { get; set; }
        [Column(TypeName = "bit")]
        public bool acpd_stop { get; set; }
        [Column(TypeName = "nvarchar(600)")]
        public string acpd_stopMemo { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string acpd_LoginID { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string acpd_LoginPW { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        public string acpd_memo { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime acpd_nowdatetime { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string appd_nowid { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime acpd_upddatetitme { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string acpd_updid { get; set; }
    }

    internal class Myoffice_ExcuteionLog
    {
        [Column(TypeName = "int")]
        public int DeLog_AuthID { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        public string DeLog_StoredPrograms { get; set; }
        [Column(TypeName = "uniqueidentifier")]
        public string DeLog_GroupID { get; set; }
        [Column(TypeName = "bit")]
        public string DeLog_isCustomDebug { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        public string DeLog_ExecutionProgram { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string DeLog_ExecuteionInfo { get; set; }
        [Column(TypeName = "bit")]
        public bool DeLog_VerifyNeeded { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime exeLog_nowdatetime { get; set; }

    }
}
