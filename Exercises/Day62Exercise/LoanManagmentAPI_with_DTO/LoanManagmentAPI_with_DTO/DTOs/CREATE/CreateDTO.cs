namespace LoanManagmentAPI_with_DTO.DTOs.Create
{
    public class CreateDTO
    {
        public string BorrowerName { get; set; }

        public decimal Amount { get; set; }

        public int LoanTermMonths { get; set; }

        public bool IsApproved { get; set; }
    }
}
