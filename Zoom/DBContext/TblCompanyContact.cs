using System;
using System.Collections.Generic;

#nullable disable

namespace Zoom.DBContext
{
    public partial class TblCompanyContact
    {
        public TblCompanyContact()
        {
            TblCompanyContactPhones = new HashSet<TblCompanyContactPhone>();
        }

        public int CompId { get; set; }
        public decimal? CompDepId { get; set; }
        public int CompContId { get; set; }
        public int CompLevel { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int? ServiceRepr { get; set; }
        public int? SalesRepr { get; set; }
        public short BillingFlag { get; set; }
        public short? SalesMethod { get; set; }
        public string SalesM1 { get; set; }
        public string SalesM2 { get; set; }
        public string SalesM3 { get; set; }
        public string Role { get; set; }
        public short? BillToFlag { get; set; }
        public short? ReportToFlag { get; set; }
        public short? Apflag { get; set; }
        public short? SupervisorFlag { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorEmail { get; set; }
        public string SupervisorPhone { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public int EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public byte ActiveFlag { get; set; }
        public byte DeleteFlag { get; set; }
        public double? PcrCandidateId { get; set; }
        public string Password { get; set; }
        public short? ETimeApproval { get; set; }
        public short? ETimeOn { get; set; }
        public byte? AcceptTerms { get; set; }
        public byte? EmailMsg { get; set; }
        public byte OptOutEmail { get; set; }
        public byte IsEz { get; set; }
        public int DefaultBillCompContId { get; set; }
        public byte BlockSurvey { get; set; }
        public byte EOrderOn { get; set; }
        public byte EReportOn { get; set; }
        public byte HasEmail { get; set; }
        public short DoNotCall { get; set; }
        public string Prefix { get; set; }
        public int? DoneByCompContId { get; set; }
        public DateTime? DoneDateCompContId { get; set; }
        public short? WebVisibility { get; set; }
        public short? OnWeb { get; set; }
        public int? ShowEmpTcsplit { get; set; }
        public int? ShowClientTcsplit { get; set; }
        public short? HasMobileApp { get; set; }
        public int? IsBusinessManager { get; set; }
        public int? ServiceLine { get; set; }
        public int? EFromId { get; set; }
        public short OnActivePrtrack { get; set; }
        public int IsCopyFromCompContId { get; set; }
        public int SetMyPsgtctoHold { get; set; }

        public virtual ICollection<TblCompanyContactPhone> TblCompanyContactPhones { get; set; }
    }
}
