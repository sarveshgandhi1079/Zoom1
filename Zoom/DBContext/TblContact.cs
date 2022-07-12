using System;
using System.Collections.Generic;

#nullable disable

namespace Zoom.DBContext
{
    public partial class TblContact
    {
        public decimal ActId { get; set; }
        public int? IntEmpId { get; set; }
        public short? IntEmpDep { get; set; }
        public short? ServiceLine { get; set; }
        public string Ts2form { get; set; }
        public string ActCode { get; set; }
        public string ActionType { get; set; }
        public string ActionType1 { get; set; }
        public string ActionTypeDescr { get; set; }
        public int? ActionNo { get; set; }
        public string ResultTypeDescr { get; set; }
        public int? ResultNo { get; set; }
        public string FollowUpTypeDescr { get; set; }
        public int? FollowUpNo { get; set; }
        public int? PrevActId { get; set; }
        public int? FollowUpActId { get; set; }
        public int? EmpId { get; set; }
        public int? CompId { get; set; }
        public int? CompDepId { get; set; }
        public int? CompContId { get; set; }
        public int? OrderId { get; set; }
        public int? GwpId { get; set; }
        public int? FillId { get; set; }
        public int? TcId { get; set; }
        public int? MainTcId { get; set; }
        public int? InvoiceId { get; set; }
        public int? InvoiceNo { get; set; }
        public int? RcId { get; set; }
        public int? AdjRcId { get; set; }
        public int? AppId { get; set; }
        public int? WlId { get; set; }
        public int? IntEmpId1 { get; set; }
        public double? PcrCompanyId { get; set; }
        public double? PcrCandidateId { get; set; }
        public double? PcrPositionId { get; set; }
        public string Memo { get; set; }
        public string FollowUpMemo { get; set; }
        public short? VisibilityCode { get; set; }
        public DateTime? ActDate { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ActionTime { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpTime { get; set; }
        public short? UrgentFlag { get; set; }
        public short ToDoFlag { get; set; }
        public DateTime? ClearedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public short AlarmFlag { get; set; }
        public string AlarmTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public short DeleteFlag { get; set; }
        public string CompName { get; set; }
        public string CompDepName { get; set; }
        public string CompContName { get; set; }
        public string EmpName { get; set; }
        public string CompContPhone { get; set; }
        public string ActName { get; set; }
        public short? EditFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? SavedDate { get; set; }
        public DateTime? ActionTime1 { get; set; }
        public short? Fuflag { get; set; }
        public DateTime? PlannerDate { get; set; }
        public short? PlannerType { get; set; }
        public short? FualarmFlag { get; set; }
        public string IntEmpName { get; set; }
        public DateTime? AlarmDate { get; set; }
        public DateTime? AlarmDateTime { get; set; }
        public int? TrackActId { get; set; }
        public short? ActionStepNo { get; set; }
        public short? ResultStepNo { get; set; }
        public short? FollowUpStepNo { get; set; }
        public int? TrackId { get; set; }
        public int? FuintEmpId { get; set; }
        public int? DoneBy { get; set; }
        public int? EnteredBy { get; set; }
        public byte IsConnected { get; set; }
        public DateTime? EnteredDate { get; set; }
        public int? SsoId { get; set; }
        public short IsPsgnewPerm { get; set; }
        public int? CallId { get; set; }
        public int? CBvId { get; set; }
        public string TimeZone { get; set; }
        public short? IsHotLead { get; set; }
        public int? HotLeadId { get; set; }
        public short? IsSch { get; set; }
        public int? SrvQId { get; set; }
        public int? ComptId { get; set; }
        public string ComptName { get; set; }
        public int? DoneByCompContId { get; set; }
        public string FuactionType1 { get; set; }
        public int EBlastId { get; set; }
        public string ActionDescr { get; set; }
        public string ResultDescr { get; set; }
        public string ActionColor { get; set; }
        public int? ActionBold { get; set; }
        public string ForeColor { get; set; }
        public int IsCandSide { get; set; }
        public int IsClientSide { get; set; }
        public int BmgroupNo { get; set; }
        public int IsPostedToTb { get; set; }
        public DateTime? PostedToTbdate { get; set; }
    }
}
