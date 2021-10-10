

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pp_test{
public class Product{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID{get;set;}
    [Required]
    public string Name{get;set;}
    }
}