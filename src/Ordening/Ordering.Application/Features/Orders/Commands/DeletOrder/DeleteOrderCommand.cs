using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeletOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
