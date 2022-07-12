using System;
using System.Collections.Generic;

#nullable disable

namespace Zoom.DBContext
{
    public partial class TblEmployee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNo { get; set; }
        public string Ssn4 { get; set; }
        public string Title { get; set; }
        public int? CurrentStatus { get; set; }
        public int? Rating { get; set; }
        public int? Advertisment { get; set; }
        public DateTime? HireDate { get; set; }
        public string EmrgContName { get; set; }
        public string EmrgPhone { get; set; }
        public string EmrgRelationship { get; set; }
        public short? PayrollFlag { get; set; }
        public short Gpflag { get; set; }
        public int? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? IntegratedInGp { get; set; }
        public DateTime? ModifiedInGp { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public short ActiveFlag { get; set; }
        public short DeleteFlag { get; set; }
        public short? I9 { get; set; }
        public byte? Bgcheck { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TempPool { get; set; }
        public short? DdemailFlag { get; set; }
        public string AccountNo { get; set; }
        public string BankNo { get; set; }
        public short? DdactiveFlag { get; set; }
        public short? ETimeOn { get; set; }
        public short? DocPendingFlag { get; set; }
        public string AccountType { get; set; }
        public DateTime? HiredDate { get; set; }
        public decimal? FirstFillId { get; set; }
        public decimal? FirstGwpId { get; set; }
        public int? RefEmpId { get; set; }
        public double? TotalHours { get; set; }
        public DateTime? RefEmpSavedDate { get; set; }
        public short? RefEmpPaidFlag { get; set; }
        public string I9Doc { get; set; }
        public DateTime? I9SavedDate { get; set; }
        public string AppDoc { get; set; }
        public DateTime? AppDocSavedDate { get; set; }
        public DateTime? I9ExpDate { get; set; }
        public short? Transport { get; set; }
        public string TitleDescr { get; set; }
        public int? ServiceRepr { get; set; }
        public short? PositionType { get; set; }
        public short? SubVendor { get; set; }
        public string BankName { get; set; }
        public byte? ETimeLiteFlag { get; set; }
        public byte OptOutEmail { get; set; }
        public string Resume { get; set; }
        public int? EmailMsg { get; set; }
        public byte IsEz { get; set; }
        public byte MascoTest { get; set; }
        public byte HasEmail { get; set; }
        public int? ServiceLine { get; set; }
        public short? ProfileTemp { get; set; }
        public short? SuperProfile { get; set; }
        public short? IsUsctz { get; set; }
        public short? IsEa { get; set; }
        public short? IsPermRes { get; set; }
        public short? IsNonProfile { get; set; }
        public short? IsA3 { get; set; }
        public int? DoneByEmpId { get; set; }
        public short? OnWeb { get; set; }
        public int? DoneByCompContId { get; set; }
        public int? DoneDateCompContId { get; set; }
        public short? HasMobileApp { get; set; }
        public int HasPardot { get; set; }
        public long? AppCastId { get; set; }
        public int XenquContactId { get; set; }
        public int HasAa { get; set; }
        public string XenquTab { get; set; }
        public string XenquTabId { get; set; }
        public int XenquDownloadComplete { get; set; }
        public int IsPostedToTb { get; set; }
        public DateTime? PostedToTbdate { get; set; }
        public int SourceRep { get; set; }
    }
}
