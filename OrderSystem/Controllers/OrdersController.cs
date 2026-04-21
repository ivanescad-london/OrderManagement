using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.DTOs;
using OrderSystem.Models;
using System.Diagnostics;

namespace OrderSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("Get All")]
    public async Task<IEnumerable<OrderReadDto>> GetOrders()
    {
        Debug.WriteLine($".\nOrder Get All ");
        return await _context.Orders
            .Select(c => new OrderReadDto
            {
                Id = c.Id,
                OrderDate = c.OrderDate,
                Client = c.Client.Name,
                Supplier = c.Supplier.Name,
                Goods = c.Goods.Name,
                Quantity = c.Quantity,
            })
            .ToListAsync();
    }

    [HttpGet("GetBySupplier/{id}")]
    public async Task<IEnumerable<OrderReadDto>> GetOrdersBySupplier(int id)
    {
        Debug.WriteLine($"Get Orders Supplier={id}  All_Orders={_context.Orders.Count()}");

        var list = _context.Orders
            .Where(p => p.SupplierId == id)
            .Select(c => new OrderReadDto
            {
                Id = c.Id,
                OrderDate = c.OrderDate,
                Client = c.Client.Name,
                Supplier = c.Supplier.Name,
                Goods = c.Goods.Name,
                Quantity = c.Quantity,
            })
            .ToList();
        Debug.WriteLine($"Get Orders : Supplier Orders.Count={list.Count()}");

        return list;
    }

    [HttpGet("GetByClient/{id}")]
    public async Task<IEnumerable<OrderReadDto>> GetOrdersByClient(int id)
    {
        Debug.WriteLine($".\nGet Orders Client={id}  All_Orders={_context.Orders.Count()}");

        var list = _context.Orders
            .Where(p => p.ClientId == id)
            .Select(c => new OrderReadDto
            {
                Id = c.Id,
                OrderDate = c.OrderDate,
                Client = c.Client.Name,
                Supplier = c.Supplier.Name,
                Goods = c.Goods.Name,
                Quantity = c.Quantity,
            })
            .ToList();
        Debug.WriteLine($"Get Orders : Client Orders.Count={list.Count()}");

        return list;
    }

    [HttpPost("Create")]
    public async Task<ActionResult<OrderReadDto>> Create(OrderCreateDto dto)
    {
        Debug.WriteLine($".\nOrder Create");
        var order = new Order
        {
            OrderDate = dto.OrderDate,
            ClientId = dto.ClientId,
            SupplierId = dto.SupplierId,
            GoodsId = dto.GoodsId,
            Quantity = dto.Quantity,
        };

        _context.Orders.Add(order);
        Debug.WriteLine($"Create order Quantity={order.Quantity} Orders={_context.Orders.Count()}");
        await _context.SaveChangesAsync();

        // Reload with relationships
        var createdOrder = await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Supplier)
            .Include(o => o.Goods)
            .FirstAsync(o => o.Id == order.Id);

        return new OrderReadDto
        {
            Id = order.Id,
            OrderDate = createdOrder.OrderDate,
            Client = createdOrder.Client!.Name,
            Supplier = createdOrder.Supplier!.Name,
            Goods = createdOrder.Goods!.Name,
            Quantity = createdOrder.Quantity,
        };
    }
}

