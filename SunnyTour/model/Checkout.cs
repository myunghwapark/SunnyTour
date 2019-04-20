
namespace SunnyTour.model
{
    public class Checkout
    {
        public int checkOutSeqNo { get; set; }
        public string serviceType { get; set; }
        public string serviceSeqId { get; set; }
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string paymentType { get; set; }
        public string nameOnCard { get; set; }
        public string creditCardType { get; set; }
        public string creditCardNumber { get; set; }
        public string expirationMonth { get; set; }
        public string expirationYear { get; set; }
        public string cardVerificationNumber { get; set; }
        public string paidStatus { get; set; }
        public string payAmount { get; set; }


    }
}