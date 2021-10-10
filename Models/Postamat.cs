// Номер (string)
// Адрес постамата (string)
// Статус постамата (bool, Рабочий = true, иначе закрыт)

using System.ComponentModel.DataAnnotations;

namespace pp_test{
public class Postamat{
[Key]
public string Num{get;set;}

public string Adress{get;set;}
[Required]
public bool Status{get;set;}
}}