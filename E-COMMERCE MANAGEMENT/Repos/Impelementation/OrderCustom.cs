using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.DTOs.Order;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE_MANAGEMENT.Repos.Impelementation
{
    public class OrderCustom : GenaricRepo<Order>, IOrdeCustom
    {
        private readonly AppDbcontext _context;
        public OrderCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<TotalAmounDto?> GetOrder(int id)
        {
            return await _context.orders.Include(a => a.orderItems)
                .Where(a => a.Id == id).Select(a => new TotalAmounDto
                {
                    OId = a.Id,
                    //Id = a.Id,
                    //OrderDate = a.OrderDate,
                    //Status = a.Status,
                    TotalPrice = a.orderItems.Sum(b=>b.Quantity*b.UnitPrice)

                }).FirstOrDefaultAsync();




        }

        public async Task<OrderRevenuo?> Revenio()
        {
            return await _context.orders.Include(a => a.orderItems).
                Where(a=>a.Status== "Completed").
                Select( v =>new  OrderRevenuo
                {
                    Revenio = v.orderItems.Sum( y=>y.UnitPrice * y.Quantity)

                }



            ).FirstOrDefaultAsync();
        }
    }
}
