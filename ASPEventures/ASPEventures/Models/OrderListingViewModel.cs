namespace ASPEventures.Models
{
    public class OrderListingViewModel
    {
        public string Id { get; set; }
        
        public string OrderedOn { get; set; }
        
        public string EventId { get; set; }
        
        public string EventName { get; set; }
        
        public string EventStart { get; set; }
        
        public string EventEnd { get; set; }
        
        public string EventPlace { get; set; }
        
        public string CustomerId { get; set; }
        
        public string CustomerUsername { get; set; }
        
        public int TicketsCount { get; set; }
    }
}