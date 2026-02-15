using System;
namespace Domain;

public class SupportTicket
{
    public string TicketId { get; set; }
    public string IssueDescription { get; set; }
    public int SeverityLevel { get; set; }
}