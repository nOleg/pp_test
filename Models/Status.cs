// Зарегистрирован = 1
// Принят на складе = 2
// Выдан курьеру = 3
// Доставлен в постамат = 4
// Доставлен получателю = 5
// Отменен = 6


using System.ComponentModel.DataAnnotations;

namespace pp_test
{
public class Status{
[Key]
public int ID{get;set;}
//[Required]
public string Name{get;set;}
}
}