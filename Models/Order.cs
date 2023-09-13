// Номер заказа (int)//
// Статус заказа (int)//
// Состав заказа: массив товаров (string[])//
// Стоимость заказа (decimal)//
// Номер постамата доставки (string)//
// Номер телефона получателя (string)//
// ФИО получателя (string)


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using pp_test.Controllers;
namespace pp_test;
public class Order:IOrder{

// PPTestContext _db;

// public Order(ILogger<OrderController>? logger,PPTestContext context):base(logger,context){
//     _db = context;
// }
//public Order(IStatus status,List<IProduct> listProduct,IPostamat postamat)=>(Status,Products,Postamat)=(status,listProduct,postamat);

[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int? Num{get;set;}
[Required]
public int? StatusID{get;set;}
[ForeignKey("StatusID")]
public Status? Status{get;set;}
public List<Product>? Products{get;set;}
[Required]
public decimal? Total{get;set;}
//[Required]
 public string? PostamaNum { get; set; }
[ForeignKey("PostamaNum")]
public Postamat? Postamat{get;set;}
[Required]
public string? Telephone{get;set;}
[Required]
public string? FullName{get;set;}

//    public override void Delete()
//     {
//         _db.Remove(this);
//         _db.SaveChanges();
       
//     }

//    public  IOrder Read()
//     {
//         return  this;
//     }
}
