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

namespace pp_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        PPTestContext db = new PPTestContext();
   
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }


        [HttpPost("add")]
        public  Task<Order> Post(Order order)
        {
            if(!PhoneRegex(order.Telephone)){
                throw new Exception("Неверный формат телефона.(+7XXX-XXX-XX-XX)");
            }
            else if(!PostamatRegex(order.PostamaNum)){
                throw new Exception("Неверный формат ПОСТАМАТА.(XXXX-XXX)");
            }
            else if(order.Products.Count>10){
                throw new Exception("Кол-во товаров не должно превышать 10.");
            }
            
            var ord= Task.Run<Order>(()=>{
            try{
            db.Orders.Add(order);
            db.SaveChanges();
            }catch(Microsoft.EntityFrameworkCore.DbUpdateException ex){
                throw new Exception($"Отсутствуе номер ПОСТАМАТА {order.PostamaNum}",ex);
            }
            return db.Orders.Where(or=>or.Num==order.Num).FirstAsync();
            });
            return ord;
            
            
        }



   [HttpGet("all")]
        public async Task<IEnumerable<Order>> Post()
        {
            var order= await Task.Run<IEnumerable<Order>>(()=>db.Orders
            .Include(pr=>pr.Products)
            .Include(po=>po.Postamat)
            .Include(st=>st.Status).ToList()) ;
            return order;
        }

       bool PhoneRegex(string phone){
                //+7XXX-XXX-XX-XX
            try
            {
                return Regex.IsMatch(phone,
                    @"\+7\d{3}-\d{3}-\d{2}-\d{2}",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
       }


            bool PostamatRegex(string postamatnum){
                //XXXX-XXX
            try
            {
                return Regex.IsMatch( postamatnum,
                    @"\d{4}-\d{3}",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
       }
    

    [HttpGet("delete")]
        public async Task<string> Delete(int id)
        {
            try{
                var ord=await db.Orders
                .Where(or=>or.Num==id)
                .Include(pr=>pr.Products)
                .FirstAsync();
            
                db.Orders.Remove(ord);
                db.SaveChanges();
                return "Заказ удален!";
            }catch(Exception ex){
                return ex.Message;
            }
        }

    }
}
