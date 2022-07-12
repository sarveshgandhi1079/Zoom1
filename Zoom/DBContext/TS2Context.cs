using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Zoom.DBContext
{
    public partial class TS2Context : DbContext
    {
        public TS2Context()
        {
        }

        public TS2Context(DbContextOptions<TS2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCompanyContact> TblCompanyContacts { get; set; }
        public virtual DbSet<TblCompanyContactPhone> TblCompanyContactPhones { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }
        public virtual DbSet<TblEmployeePhone> TblEmployeePhones { get; set; }
        public virtual DbSet<TblInternalEmployee> TblInternalEmployees { get; set; }
        public virtual DbSet<TblInternalEmployee1> TblInternalEmployees1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=azureqasql6.database.windows.net;Initial Catalog=TS2;Persist Security Info=True;User ID=thinkbr;Password=migration@123;Trusted_Connection=False;Encrypt=False;Connection Timeout=30;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCompanyContact>(entity =>
            {
                entity.HasKey(e => e.CompContId);

                entity.ToTable("tblCOMPANY_CONTACT");

                entity.HasIndex(e => e.ActiveFlag, "IX_tblCOMPANY_CONTACT_ActiveFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CompId, "IX_tblCOMPANY_CONTACT_Comp_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DeleteFlag, "IX_tblCOMPANY_CONTACT_DeleteFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Email, "IX_tblCOMPANY_CONTACT_Email")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FirstName, "IX_tblCOMPANY_CONTACT_FirstName")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.LastName, "IX_tblCOMPANY_CONTACT_LastName")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Password, "IX_tblCOMPANY_CONTACT_Psw")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Title, "IX_tblCOMPANY_CONTACT_Title")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.WebVisibility, "IX_tblCOMPANY_CONTACT_WebVisibility")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.HasEmail, "IX_tblCOMPANY_CONTACT_hasEmail")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.HasMobileApp, "IX_tblCOMPANY_CONTACT_hasMobileApp")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.OnWeb, "IX_tblCOMPANY_CONTACT_onWeb")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DoneByCompContId, "IX_tblCompany_Contact_DoneBy_CompCont_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DoneDateCompContId, "IX_tblCompany_Contact_DoneDate_CompCont_Id")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.CompContId).HasColumnName("CompCont_Id");

                entity.Property(e => e.Apflag).HasColumnName("APFlag");

                entity.Property(e => e.CompDepId)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("CompDep_Id");

                entity.Property(e => e.CompId).HasColumnName("Comp_Id");

                entity.Property(e => e.DefaultBillCompContId).HasColumnName("DefaultBill_CompCont_Id");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DoneByCompContId)
                    .HasColumnName("DoneBy_CompCont_Id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DoneDateCompContId)
                    .HasColumnType("datetime")
                    .HasColumnName("DoneDate_CompCont_Id");

                entity.Property(e => e.EFromId).HasColumnName("eFrom_Id");

                entity.Property(e => e.EOrderOn).HasColumnName("eOrderOn");

                entity.Property(e => e.EReportOn).HasColumnName("eReportOn");

                entity.Property(e => e.ETimeApproval).HasColumnName("eTimeApproval");

                entity.Property(e => e.ETimeOn).HasColumnName("eTimeOn");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnteredBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HasEmail).HasColumnName("hasEmail");

                entity.Property(e => e.HasMobileApp)
                    .HasColumnName("hasMobileApp")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsBusinessManager)
                    .HasColumnName("isBusinessManager")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsCopyFromCompContId).HasColumnName("isCopyFromCompCont_Id");

                entity.Property(e => e.IsEz).HasColumnName("isEZ");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MiddleInitial)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OnActivePrtrack).HasColumnName("OnActivePRTrack");

                entity.Property(e => e.OnWeb)
                    .HasColumnName("onWeb")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("SQL_Latin1_General_CP1_CS_AS");

                entity.Property(e => e.PcrCandidateId).HasColumnName("PCR_Candidate_Id");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesM1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SalesM2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SalesM3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SetMyPsgtctoHold).HasColumnName("SetMyPSGTCToHold");

                entity.Property(e => e.ShowClientTcsplit)
                    .HasColumnName("ShowClientTCSplit")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShowEmpTcsplit)
                    .HasColumnName("ShowEmpTCSplit")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SupervisorEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WebVisibility).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblCompanyContactPhone>(entity =>
            {
                entity.HasKey(e => e.CompContPhoneId)
                    .HasName("PK_tblCOMPANY_PHONE");

                entity.ToTable("tblCOMPANY_CONTACT_PHONE");

                entity.HasIndex(e => e.ActiveFlag, "IX_tblCOMPANY_CONTACT_PHONE_ActiveFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CompContId, "IX_tblCOMPANY_CONTACT_PHONE_CompCont_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CompId, "IX_tblCOMPANY_CONTACT_PHONE_Comp_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DeleteFlag, "IX_tblCOMPANY_CONTACT_PHONE_DeleteFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DoneByCompContId, "IX_tblCOMPANY_CONTACT_PHONE_DoneBy_CompCont_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DoneDateCompContId, "IX_tblCOMPANY_CONTACT_PHONE_DoneDate_CompCont_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Phone, "IX_tblCOMPANY_CONTACT_PHONE_Phone")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.PhoneType, "IX_tblCOMPANY_CONTACT_PHONE_PhoneType")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.NPhone, "IX_tblCOMPANY_CONTACT_PHONE_nPhone")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.CompContPhoneId).HasColumnName("CompContPhone_Id");

                entity.Property(e => e.CanText).HasColumnName("canText");

                entity.Property(e => e.CompContId).HasColumnName("CompCont_Id");

                entity.Property(e => e.CompId).HasColumnName("Comp_Id");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DoneByCompContId)
                    .HasColumnName("DoneBy_CompCont_Id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DoneDateCompContId)
                    .HasColumnType("datetime")
                    .HasColumnName("DoneDate_CompCont_Id")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nPhone")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NPhonewTag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nPhonewTag")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhonewTag)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CompCont)
                    .WithMany(p => p.TblCompanyContactPhones)
                    .HasForeignKey(d => d.CompContId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCOMPANY_CONTACT_PHONE_tblCOMPANY_CONTACT");
            });

            modelBuilder.Entity<TblContact>(entity =>
            {
                entity.HasKey(e => e.ActId)
                    .HasName("PK_tblCONTACT_1");

                entity.ToTable("tblCONTACT");

                entity.HasIndex(e => e.ActCode, "IX_tblCONTACT_ActCode")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActDate, "IX_tblCONTACT_ActDate")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActionDate, "IX_tblCONTACT_ActionDate")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActionNo, "IX_tblCONTACT_ActionNo")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActionTime, "IX_tblCONTACT_ActionTime")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActionType, "IX_tblCONTACT_ActionType")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActionType1, "IX_tblCONTACT_ActionType1")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActionTypeDescr, "IX_tblCONTACT_ActionTypeDescr")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.AppId, "IX_tblCONTACT_App_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CompContId, "IX_tblCONTACT_CompCont_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CompDepId, "IX_tblCONTACT_CompDep_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CompId, "IX_tblCONTACT_Comp_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ComptId, "IX_tblCONTACT_Compt_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DeleteFlag, "IX_tblCONTACT_DeleteFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DoneBy, "IX_tblCONTACT_DoneBy")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DoneByCompContId, "IX_tblCONTACT_DoneBy_CompCont_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.EmpName, "IX_tblCONTACT_EmpName")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.EmpId, "IX_tblCONTACT_Emp_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.EnteredDate, "IX_tblCONTACT_EnteredDate")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Fuflag, "IX_tblCONTACT_FUFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FillId, "IX_tblCONTACT_Fill_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FollowUpActId, "IX_tblCONTACT_FollowUpAct_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FollowUpDate, "IX_tblCONTACT_FollowUpDate")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FollowUpNo, "IX_tblCONTACT_FollowUpNo")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FollowUpTime, "IX_tblCONTACT_FollowUpTime")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FollowUpTypeDescr, "IX_tblCONTACT_FollowUpTypeDescr")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.GwpId, "IX_tblCONTACT_GWP_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.HotLeadId, "IX_tblCONTACT_HotLead_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IntEmpDep, "IX_tblCONTACT_IntEmpDep")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IntEmpId, "IX_tblCONTACT_IntEmp_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IntEmpId1, "IX_tblCONTACT_IntEmp_Id1")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsCandSide, "IX_tblCONTACT_IsCandSide")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsClientSide, "IX_tblCONTACT_IsClientSide")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.OrderId, "IX_tblCONTACT_Order_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.PrevActId, "IX_tblCONTACT_PrevAct_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ResultNo, "IX_tblCONTACT_ResultNo")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ResultTypeDescr, "IX_tblCONTACT_ResultTypeDescr")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.SsoId, "IX_tblCONTACT_SSO_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ServiceLine, "IX_tblCONTACT_ServiceLine")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.SrvQId, "IX_tblCONTACT_SrvQ_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Ts2form, "IX_tblCONTACT_TS2form")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.TimeZone, "IX_tblCONTACT_TimeZone")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.VisibilityCode, "IX_tblCONTACT_VisibilityCode")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.WlId, "IX_tblCONTACT_WL_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.EBlastId, "IX_tblCONTACT_eBlast_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsConnected, "IX_tblCONTACT_isConnected")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsHotLead, "IX_tblCONTACT_isHotLead")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsSch, "IX_tblCONTACT_isSch")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.BmgroupNo, "IX_tblContact_BMGroupNo")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.ActId)
                    .HasColumnType("decimal(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Act_Id");

                entity.Property(e => e.ActCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActDate).HasColumnType("datetime");

                entity.Property(e => e.ActName).IsUnicode(false);

                entity.Property(e => e.ActionColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.ActionDescr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionTime1).HasColumnType("datetime");

                entity.Property(e => e.ActionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionType1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionTypeDescr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdjRcId).HasColumnName("adjRC_Id");

                entity.Property(e => e.AlarmDate).HasColumnType("datetime");

                entity.Property(e => e.AlarmDateTime).HasColumnType("datetime");

                entity.Property(e => e.AlarmTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppId).HasColumnName("App_Id");

                entity.Property(e => e.BmgroupNo).HasColumnName("BMGroupNo");

                entity.Property(e => e.CBvId).HasColumnName("cBV_Id");

                entity.Property(e => e.CallId)
                    .HasColumnName("Call_Id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClearedDate).HasColumnType("datetime");

                entity.Property(e => e.CompContId).HasColumnName("CompCont_Id");

                entity.Property(e => e.CompContName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompContPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompDepId).HasColumnName("CompDep_Id");

                entity.Property(e => e.CompDepName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompId).HasColumnName("Comp_Id");

                entity.Property(e => e.CompName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComptId).HasColumnName("Compt_Id");

                entity.Property(e => e.ComptName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DoneBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.DoneByCompContId)
                    .HasColumnName("DoneBy_CompCont_Id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EBlastId).HasColumnName("eBlast_Id");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnteredBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FillId).HasColumnName("Fill_Id");

                entity.Property(e => e.FollowUpActId).HasColumnName("FollowUpAct_Id");

                entity.Property(e => e.FollowUpDate).HasColumnType("datetime");

                entity.Property(e => e.FollowUpMemo).IsUnicode(false);

                entity.Property(e => e.FollowUpTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FollowUpTypeDescr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ForeColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FuactionType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FUActionType1")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FualarmFlag).HasColumnName("FUAlarmFlag");

                entity.Property(e => e.Fuflag).HasColumnName("FUflag");

                entity.Property(e => e.FuintEmpId).HasColumnName("FUIntEmp_Id");

                entity.Property(e => e.GwpId).HasColumnName("GWP_Id");

                entity.Property(e => e.HotLeadId).HasColumnName("HotLead_Id");

                entity.Property(e => e.IntEmpId).HasColumnName("IntEmp_Id");

                entity.Property(e => e.IntEmpId1).HasColumnName("IntEmp_Id1");

                entity.Property(e => e.IntEmpName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceId).HasColumnName("Invoice_Id");

                entity.Property(e => e.IsCandSide).HasColumnName("isCandSide");

                entity.Property(e => e.IsClientSide).HasColumnName("isClientSide");

                entity.Property(e => e.IsConnected).HasColumnName("isConnected");

                entity.Property(e => e.IsHotLead).HasColumnName("isHotLead");

                entity.Property(e => e.IsPostedToTb).HasColumnName("isPostedToTB");

                entity.Property(e => e.IsPsgnewPerm).HasColumnName("isPSGNewPerm");

                entity.Property(e => e.IsSch).HasColumnName("isSch");

                entity.Property(e => e.MainTcId).HasColumnName("mainTC_Id");

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.PcrCandidateId).HasColumnName("PCR_Candidate_Id");

                entity.Property(e => e.PcrCompanyId).HasColumnName("PCR_Company_Id");

                entity.Property(e => e.PcrPositionId).HasColumnName("PCR_Position_Id");

                entity.Property(e => e.PlannerDate).HasColumnType("datetime");

                entity.Property(e => e.PostedToTbdate)
                    .HasColumnType("datetime")
                    .HasColumnName("PostedToTBDate");

                entity.Property(e => e.PrevActId).HasColumnName("PrevAct_Id");

                entity.Property(e => e.RcId).HasColumnName("RC_Id");

                entity.Property(e => e.ResultDescr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResultTypeDescr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SavedDate).HasColumnType("datetime");

                entity.Property(e => e.SrvQId).HasColumnName("SrvQ_Id");

                entity.Property(e => e.SsoId).HasColumnName("SSO_Id");

                entity.Property(e => e.TcId).HasColumnName("TC_Id");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('ET')")
                    .IsFixedLength(true);

                entity.Property(e => e.TrackActId).HasColumnName("TrackAct_Id");

                entity.Property(e => e.TrackId).HasColumnName("Track_Id");

                entity.Property(e => e.Ts2form)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TS2form");

                entity.Property(e => e.WlId).HasColumnName("WL_Id");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblEMPLOYEE");

                entity.HasIndex(e => e.AccountNo, "IX_tblEMPLOYEE_AccountNo")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.AccountType, "IX_tblEMPLOYEE_AccountType")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActiveFlag, "IX_tblEMPLOYEE_ActiveFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Advertisment, "IX_tblEMPLOYEE_Adv")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.BankNo, "IX_tblEMPLOYEE_BankNo")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CurrentStatus, "IX_tblEMPLOYEE_CurrentStatus")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DdactiveFlag, "IX_tblEMPLOYEE_DDActiveFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DeleteFlag, "IX_tblEMPLOYEE_DeleteFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DocPendingFlag, "IX_tblEMPLOYEE_DocPendingFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Email, "IX_tblEMPLOYEE_Email")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FirstName, "IX_tblEMPLOYEE_FirstName")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.EnteredBy, "IX_tblEMPLOYEE_First_EnteredBy")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FirstFillId, "IX_tblEMPLOYEE_First_Fill_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.FirstGwpId, "IX_tblEMPLOYEE_First_GWP_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.HiredDate, "IX_tblEMPLOYEE_HiredDate")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.I9, "IX_tblEMPLOYEE_I9")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.LastName, "IX_tblEMPLOYEE_LastName")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Password, "IX_tblEMPLOYEE_Psw")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Ssn4, "IX_tblEMPLOYEE_SSN4")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ServiceLine, "IX_tblEMPLOYEE_ServiceLine")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ServiceRepr, "IX_tblEMPLOYEE_ServiceRepr")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.TempPool, "IX_tblEMPLOYEE_TempPool")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Transport, "IX_tblEMPLOYEE_Transport")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ETimeOn, "IX_tblEMPLOYEE_eTimeOn")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.SocialSecurityNo, "IX_tblEmployee_SSNo")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Title, "IX_tblEmployee_Title")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.OnWeb, "IX_tblEmployee_onWeb")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.EmpId, "Pk_tblEmployee")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AppCastId)
                    .HasColumnName("AppCast_Id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AppDoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("App_Doc");

                entity.Property(e => e.AppDocSavedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("App_Doc_SavedDate");

                entity.Property(e => e.BankName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BankNo)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Bgcheck).HasColumnName("BGCheck");

                entity.Property(e => e.DdactiveFlag).HasColumnName("DDActiveFlag");

                entity.Property(e => e.DdemailFlag).HasColumnName("DDEmailFlag");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DoneByCompContId).HasColumnName("DoneBy_CompCont_Id");

                entity.Property(e => e.DoneByEmpId).HasColumnName("DoneByEmp_Id");

                entity.Property(e => e.DoneDateCompContId).HasColumnName("DoneDate_CompCont_Id");

                entity.Property(e => e.ETimeLiteFlag).HasColumnName("eTimeLiteFlag");

                entity.Property(e => e.ETimeOn).HasColumnName("eTimeOn");

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Emp_Id");

                entity.Property(e => e.EmrgContName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmrgPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmrgRelationship)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.FirstFillId)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("First_Fill_Id");

                entity.Property(e => e.FirstGwpId)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("First_GWP_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gpflag).HasColumnName("GPflag");

                entity.Property(e => e.HasAa).HasColumnName("hasAA");

                entity.Property(e => e.HasEmail)
                    .HasColumnName("hasEmail")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HasMobileApp).HasColumnName("hasMobileApp");

                entity.Property(e => e.HasPardot).HasColumnName("hasPardot");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HiredDate).HasColumnType("datetime");

                entity.Property(e => e.I9Doc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("I9_Doc");

                entity.Property(e => e.I9ExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("I9_ExpDate");

                entity.Property(e => e.I9SavedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("I9_SavedDate");

                entity.Property(e => e.IntegratedInGp)
                    .HasColumnType("datetime")
                    .HasColumnName("IntegratedInGP");

                entity.Property(e => e.IsA3).HasColumnName("isA3");

                entity.Property(e => e.IsEa).HasColumnName("isEA");

                entity.Property(e => e.IsEz).HasColumnName("isEZ");

                entity.Property(e => e.IsNonProfile).HasColumnName("isNonProfile");

                entity.Property(e => e.IsPermRes).HasColumnName("isPermRes");

                entity.Property(e => e.IsPostedToTb).HasColumnName("isPostedToTB");

                entity.Property(e => e.IsUsctz).HasColumnName("isUSCtz");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedInGp)
                    .HasColumnType("datetime")
                    .HasColumnName("ModifiedInGP");

                entity.Property(e => e.OnWeb)
                    .HasColumnName("onWeb")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("SQL_Latin1_General_CP1_CS_AS");

                entity.Property(e => e.PostedToTbdate)
                    .HasColumnType("datetime")
                    .HasColumnName("PostedToTBDate");

                entity.Property(e => e.ProfileTemp).HasDefaultValueSql("((0))");

                entity.Property(e => e.RefEmpId).HasColumnName("Ref_Emp_Id");

                entity.Property(e => e.RefEmpPaidFlag).HasColumnName("Ref_Emp_PaidFlag");

                entity.Property(e => e.RefEmpSavedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ref_Emp_SavedDate");

                entity.Property(e => e.Resume)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SocialSecurityNo)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Ssn4)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SSN4");

                entity.Property(e => e.SuperProfile).HasDefaultValueSql("((0))");

                entity.Property(e => e.TempPool)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TitleDescr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Transport).HasDefaultValueSql("((0))");

                entity.Property(e => e.XenquContactId).HasColumnName("XenquContact_Id");

                entity.Property(e => e.XenquTab)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XenquTabId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblEmployeePhone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblEMPLOYEE_PHONE");

                entity.HasIndex(e => e.ActiveFlag, "IX_tblEMPLOYEE_PHONE_ActiveFlag");

                entity.HasIndex(e => e.DeleteFlag, "IX_tblEMPLOYEE_PHONE_DeleteFlag");

                entity.HasIndex(e => e.EmpId, "IX_tblEMPLOYEE_PHONE_Emp_Id")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Phone, "IX_tblEMPLOYEE_PHONE_Phone")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.PhoneType, "IX_tblEMPLOYEE_PHONE_PhoneType")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.NPhone, "IX_tblEMPLOYEE_PHONE_nPhone")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.PhoneId, "PK_tblEmployee_Phone")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.CanText).HasColumnName("canText");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DoneByEmpId).HasColumnName("DoneByEmp_Id");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.EnteredBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsReplied).HasColumnName("isReplied");

                entity.Property(e => e.IsTexted).HasColumnName("isTexted");

                entity.Property(e => e.IsVerified).HasColumnName("isVerified");

                entity.Property(e => e.ModifiedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nPhone")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NPhonewTag)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nPhonewTag")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Phone_Id");

                entity.Property(e => e.PhonewTag)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VerificationNotes).IsUnicode(false);
            });

            modelBuilder.Entity<TblInternalEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblINTERNAL_EMPLOYEE", "Control");

                entity.Property(e => e.CanApproveBg).HasColumnName("canApproveBG");

                entity.Property(e => e.CanApproveCori).HasColumnName("canApproveCORI");

                entity.Property(e => e.CanViewBg).HasColumnName("canViewBG");

                entity.Property(e => e.CanViewI9).HasColumnName("canViewI9");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gwppayroll).HasColumnName("GWPPayroll");

                entity.Property(e => e.HasGuarantee).HasColumnName("hasGuarantee");

                entity.Property(e => e.InTs2).HasColumnName("inTs2");

                entity.Property(e => e.InactivatedDate).HasColumnType("datetime");

                entity.Property(e => e.IntEmpId).HasColumnName("IntEmp_Id");

                entity.Property(e => e.IsLocal).HasColumnName("isLocal");

                entity.Property(e => e.IsOs).HasColumnName("isOS");

                entity.Property(e => e.IsRookie).HasColumnName("isRookie");

                entity.Property(e => e.IsTs3).HasColumnName("isTS3");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarketingEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleInital)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OnlyMySl).HasColumnName("OnlyMySL");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SocialSecurityNo)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TermDate).HasColumnType("datetime");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XenquContactId).HasColumnName("XenquContact_Id");
            });

            modelBuilder.Entity<TblInternalEmployee1>(entity =>
            {
                entity.HasKey(e => e.IntEmpId);

                entity.ToTable("tblINTERNAL_EMPLOYEE");

                entity.HasIndex(e => e.ActionType, "IX_tblINTERNAL_EMPLOYEE_ActionType")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ActiveFlag, "IX_tblINTERNAL_EMPLOYEE_ActiveFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DeleteFlag, "IX_tblINTERNAL_EMPLOYEE_DeleteFlag")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Department, "IX_tblINTERNAL_EMPLOYEE_Department")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DrugTest, "IX_tblINTERNAL_EMPLOYEE_DrugTest")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Email, "IX_tblINTERNAL_EMPLOYEE_Email")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Gwppayroll, "IX_tblINTERNAL_EMPLOYEE_GWPPayroll")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.GroupManager, "IX_tblINTERNAL_EMPLOYEE_GroupManager")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.MinStType, "IX_tblINTERNAL_EMPLOYEE_MinStType")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.OnlyMySl, "IX_tblINTERNAL_EMPLOYEE_OnlyMySL")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.PayrollTask, "IX_tblINTERNAL_EMPLOYEE_PayrollTask")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Phone, "IX_tblINTERNAL_EMPLOYEE_Phone")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.SecurityLevel, "IX_tblINTERNAL_EMPLOYEE_SecurityLevel")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.SendSurveyTask, "IX_tblINTERNAL_EMPLOYEE_SendSurveyTask")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ServiceLine, "IX_tblINTERNAL_EMPLOYEE_ServiceLine")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.StartDate, "IX_tblINTERNAL_EMPLOYEE_StartDate")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.TempPayroll, "IX_tblINTERNAL_EMPLOYEE_TempPayroll")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.TermDate, "IX_tblINTERNAL_EMPLOYEE_TermDate")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.TimeZone, "IX_tblINTERNAL_EMPLOYEE_TimeZone")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.UserType, "IX_tblINTERNAL_EMPLOYEE_UserType")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CanApproveBg, "IX_tblINTERNAL_EMPLOYEE_canApproveBG")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CanApproveCori, "IX_tblINTERNAL_EMPLOYEE_canApproveCORI")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CanViewBg, "IX_tblINTERNAL_EMPLOYEE_canViewBG")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CanViewI9, "IX_tblINTERNAL_EMPLOYEE_canViewI9")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.HasAutomPifu, "IX_tblINTERNAL_EMPLOYEE_hasAutomPIFU")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.HasGuarantee, "IX_tblINTERNAL_EMPLOYEE_hasGuarantee")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsLocal, "IX_tblINTERNAL_EMPLOYEE_isLocal")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsOs, "IX_tblINTERNAL_EMPLOYEE_isOS")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsTs3, "IX_tblINTERNAL_EMPLOYEE_isTS3")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.TempEmpId, "IX_tblInternal_Employee_TempEmp_Id");

                entity.Property(e => e.IntEmpId).HasColumnName("IntEmp_Id");

                entity.Property(e => e.Ademail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ademail")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Branch).HasDefaultValueSql("((0))");

                entity.Property(e => e.CanApproveBg)
                    .HasColumnName("canApproveBG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CanApproveCori)
                    .HasColumnName("canApproveCORI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CanViewBg)
                    .HasColumnName("canViewBG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CanViewI9)
                    .HasColumnName("canViewI9")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrossSellServiceLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.Department).HasDefaultValueSql("((0))");

                entity.Property(e => e.DirectedPtodays).HasColumnName("DirectedPTODays");

                entity.Property(e => e.DrugTest).HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnteredBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FillwNoBg).HasColumnName("FillwNoBG");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupManager).HasDefaultValueSql("((0))");

                entity.Property(e => e.Gwppayroll)
                    .HasColumnName("GWPPayroll")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasAutomPifu).HasColumnName("hasAutomPIFU");

                entity.Property(e => e.HasGuarantee)
                    .HasColumnName("hasGuarantee")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HomeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Home_Email")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InactivatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsEligibleFor401k).HasColumnName("isEligibleFor401k");

                entity.Property(e => e.IsLocal)
                    .HasColumnName("isLocal")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsOs).HasColumnName("isOS");

                entity.Property(e => e.IsRookie).HasColumnName("isRookie");

                entity.Property(e => e.IsStandardPtosetup).HasColumnName("isStandardPTOSetup");

                entity.Property(e => e.IsTs3).HasColumnName("isTS3");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LinkedInAddr)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MarketingEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinStType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NonDirectedPtodays).HasColumnName("NonDirectedPTODays");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OnlyMySl).HasColumnName("OnlyMySL");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayrollTask).HasDefaultValueSql("((0))");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProfileNo).HasDefaultValueSql("((1))");

                entity.Property(e => e.PsgCompContId)
                    .HasColumnName("psgCompCont_Id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SecurityLevel).HasDefaultValueSql("((4))");

                entity.Property(e => e.SendSurveyTask).HasDefaultValueSql("((0))");

                entity.Property(e => e.ServiceLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.SocialSecurityNo)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SurveyTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TempEmpId)
                    .HasColumnName("TempEmp_Id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TempPayroll).HasDefaultValueSql("((0))");

                entity.Property(e => e.TermDate).HasColumnType("datetime");

                entity.Property(e => e.TestFlag).HasDefaultValueSql("((0))");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ET')");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TwitterAddr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Temp')");

                entity.Property(e => e.XenquContactId).HasColumnName("XenquContact_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
