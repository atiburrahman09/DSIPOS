namespace Lumex.Project.BLL
{
    public class GeneralLedgerTransactionBLL
    {
        public string JournalNumber { get; set; }
        public string TransactionNumber { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string AutoVoucherNumber { get; set; }
        public string ManualVoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public string AccountId { get; set; }
        public string CounterAccountId { get; set; }
        public string Amount { get; set; }
        public string DebitCredit { get; set; }
        public string DrCrJrVoucherFlag { get; set; }
        public string CashCheque { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeDate { get; set; }
        public string Description { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        public string IsApprove { get; set; }
        public string OfficeBranchId { get; set; }
    }
}
