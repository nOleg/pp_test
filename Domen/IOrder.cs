
namespace pp_test;
public interface IOrder{
public int? Num{get;set;}
public int? StatusID{get;set;}
public Status? Status{get;set;}
public List<Product>? Products{get;set;}
public decimal? Total{get;set;}
public string? PostamaNum { get; set; }
public Postamat? Postamat{get;set;}
public string? Telephone{get;set;}
public string? FullName{get;set;}
}
