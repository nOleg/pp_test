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
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {

       internal readonly PPTestContext _db;
   
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger,PPTestContext context)
        {
            _logger = logger;
            _db = context;
        }


        [HttpPost]
        public  Task<ActionResult<IOrder>> AddOrder(Order order)
        {
            if(!PhoneRegex(order!.Telephone!)){
                throw new Exception("Неверный формат телефона.(+7XXX-XXX-XX-XX)");
            }
            else if(!PostamatRegex(order!.PostamaNum!)){
                throw new Exception("Неверный формат ПОСТАМАТА.(XXXX-XXX)");
            }
            else if(order!.Products!.Count>10){
                throw new Exception("Кол-во товаров не должно превышать 10.");
            }
            
            return Task.Run<ActionResult<IOrder>>(()=>{
            try{
            _db.Orders!.Add(order);
            _db.SaveChanges();
            }catch(Microsoft.EntityFrameworkCore.DbUpdateException ex){
                throw new Exception($"Отсутствуе номер ПОСТАМАТА {order!.PostamaNum}",ex);
            }
            return Ok(_db.Orders.Where(or=>or.Num==order!.Num)
            .Include(pr=>pr.Products)
            .Include(po=>po.Postamat)
            .Include(st=>st.Status).FirstAsync());
            
            });
            
        }



   [HttpGet]
        public async Task<IEnumerable<IOrder>> AllOrders()
        {
           // var order= 
            return //await Task.Run<IEnumerable<IOrder>>(()=>
            await _db.Orders!
            .Include(pr=>pr.Products)
            .Include(po=>po.Postamat)
            .Include(st=>st.Status).ToListAsync();
            //.ToList()) ;
            //return order;
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
    

    [HttpGet]
        public async Task<ActionResult<string>> DeleteOrder(int id)
        {
            try{
                var ord=await _db.Orders!
                .Where(or=>or.Num==id)
                .Include(pr=>pr.Products)
                .FirstAsync();
            
                _db.Orders!.Remove(ord);
                _db.SaveChanges();
                return  Ok("Заказ удален!");
            }catch(Exception ex){
                return ex.Message;
            }
        }

    }
}
