using System;
using System.Collections.Generic;

#nullable disable

namespace Zoom.DBContext
{
    public partial class TblCompanyContactPhone
    {
        public int? CompId { get; set; }
        public int CompContId { get; set; }
        public int CompContPhoneId { get; set; }
        public int PhoneType { get; set; }
        public string Phone { get; set; }
        public int? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public byte ActiveFlag { get; set; }
        public byte DeleteFlag { get; set; }
        public int? DoneByCompContId { get; set; }
        public DateTime? DoneDateCompContId { get; set; }
        public string NPhone { get; set; }
        public short CanText { get; set; }
        public string NPhonewTag { get; set; }
        public string PhonewTag { get; set; }

        public virtual TblCompanyContact CompCont { get; set; }
    }
}
