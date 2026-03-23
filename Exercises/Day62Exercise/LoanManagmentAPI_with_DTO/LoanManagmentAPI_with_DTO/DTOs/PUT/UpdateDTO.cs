namespace LoanManagmentAPI_with_DTO.DTOs.Update
{
    public class UpdateDto
    {
        public int LoanId { get; set; }

        public string BorrowerName { get; set; }

        public decimal Amount { get; set; }

        public int LoanTermMonths { get; set; }

        public bool IsApproved { get; set; }
    }
}
