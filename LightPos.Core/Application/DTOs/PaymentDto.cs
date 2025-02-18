namespace LightPos.Core.Application.DTOs;

public class PaymentDto
{
    public Guid OrderItemId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
} 