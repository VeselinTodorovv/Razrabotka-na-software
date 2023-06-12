using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPEventures.Domain
{
    public class Order
    {
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public string Id { get; set; }
        
        public DateTime OrderedOn { get; set; }
        
        public string EventId { get; set; }
        
        public Event Event { get; set; }
        
        public string CustomerId { get; set; }
        
        public EventuresUser Customer { get; set; }
        
        public int TicketsCount { get; set; }
    }
}