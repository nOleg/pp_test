// Создание заказа
// Изменение заказа
// Получение информации по заказу
// Отмена заказа

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pp_test;

namespace pp_test.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{

    internal readonly PPTestContext? _db;

    private readonly ILogger<OrderController>? _logger;

    private readonly CRUD.Orders ord;
    private readonly CRUD.Orders.Deleted del;

    public OrderController(ILogger<OrderController>? logger, PPTestContext? context)
    {
        _logger = logger;
        _db = context;
        ord = new CRUD.Orders(logger, context);
        del = new(ord.Delete);

        //deleted= CRUD.Deleted(orders.Delete);   
    }

    [HttpPost]
    public Task<ActionResult<IOrder>> AddOrder(Order order)
    {
        if (!PPRegex.PhoneRegex(order!.Telephone!))
        {
            throw new Exception("Неверный формат телефона.(+7XXX-XXX-XX-XX)");
        }
        else if (!PPRegex.PostamatRegex(order!.PostamaNum!))
        {
            throw new Exception("Неверный формат ПОСТАМАТА.(XXXX-XXX)");
        }
        else if (order!.Products!.Count > 10)
        {
            throw new Exception("Кол-во товаров не должно превышать 10.");
        }

        return Task.Run<ActionResult<IOrder>>(() =>
        {
            try
            {
                return Ok(ord.Add(order));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                throw new Exception($"Отсутствуе номер ПОСТАМАТА {order!.PostamaNum}", ex);
            }


        });

    }

    [HttpGet]
    public async Task<IEnumerable<IOrder>> AllOrders()
    {
        return await ord.Read();
    }
    
    [HttpGet]
    public ActionResult<string> DeleteOrder(int id)
    {
        try
        {
            ord.Delete(id);
            return Ok("Заказ удален!");
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

}

