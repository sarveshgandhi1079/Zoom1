using System;
using System.Collections.Generic;

#nullable disable

namespace Zoom.DBContext
{
    public partial class TblEmployeePhone
    {
        public int EmpId { get; set; }
        public int PhoneId { get; set; }
        public int PhoneType { get; set; }
        public string Phone { get; set; }
        public string NPhone { get; set; }
        public int EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public byte ActiveFlag { get; set; }
        public byte DeleteFlag { get; set; }
        public int? DoneByEmpId { get; set; }
        public short CanText { get; set; }
        public string NPhonewTag { get; set; }
        public bool? IsVerified { get; set; }
        public string VerificationNotes { get; set; }
        public bool? IsTexted { get; set; }
        public bool? IsReplied { get; set; }
        public string PhonewTag { get; set; }
    }
}
