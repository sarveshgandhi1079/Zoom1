using System;
using System.Collections.Generic;

#nullable disable

namespace Zoom.DBContext
{
    public partial class TblInternalEmployee
    {
        public int IntEmpId { get; set; }
        public string SocialSecurityNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string MiddleInital { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int? Branch { get; set; }
        public short? Department { get; set; }
        public short? ServiceLine { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? SecurityLevel { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TermDate { get; set; }
        public int? ActionType { get; set; }
        public int? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? InactivatedBy { get; set; }
        public DateTime? InactivatedDate { get; set; }
        public short ActiveFlag { get; set; }
        public short DeleteFlag { get; set; }
        public string UserType { get; set; }
        public short? GroupManager { get; set; }
        public short? DrugTest { get; set; }
        public byte? Gwppayroll { get; set; }
        public byte? TempPayroll { get; set; }
        public byte? TestFlag { get; set; }
        public byte? ProfileNo { get; set; }
        public byte? PayrollTask { get; set; }
        public byte? InTs2 { get; set; }
        public byte? FillwNoBg { get; set; }
        public byte? IsLocal { get; set; }
        public byte? IsRookie { get; set; }
        public byte? IsTs3 { get; set; }
        public byte? IsOs { get; set; }
        public byte? OnlyMySl { get; set; }
        public string TimeZone { get; set; }
        public byte? CanViewI9 { get; set; }
        public byte? CanViewBg { get; set; }
        public byte? CanApproveCori { get; set; }
        public byte? CanApproveBg { get; set; }
        public byte? HasGuarantee { get; set; }
        public int? BonusPlan { get; set; }
        public string MarketingEmail { get; set; }
        public int XenquContactId { get; set; }
    }
}
