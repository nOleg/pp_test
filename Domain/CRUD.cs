using Microsoft.EntityFrameworkCore;


namespace pp_test.Controllers;


public abstract class CRUD
{
   

    private static PPTestContext? _db;
    public readonly ILogger<OrderController>? _logger;

    public CRUD(ILogger<OrderController>? logger, PPTestContext? context)
    {
        _logger = logger;
        _db = context;
    }

    public class Orders : CRUD
    {
        public delegate void Deleted(int id);
        public Orders(ILogger<OrderController>? logger, PPTestContext? context) : base(logger, context) { }
        public async Task<IEnumerable<IOrder>> Read()
        {
            return await _db!.Orders!
                .Include(pr => pr.Products)
                .Include(po => po.Postamat)
                .Include(st => st.Status).ToListAsync();
        }
        public async Task<Order> ReadById(int? id)
        {

            return await _db!.Orders!
                 .Where(or => or.Num == id)
                 .Include(pr => pr.Products)
                 .FirstAsync();
        }
        public async void Delete(int ID)
        {
            Order order = await this.ReadById(ID);
            _db!.Orders!.Remove(order);
            _db.SaveChanges();
        }

        public async Task<IOrder> Add(Order order)
        {
            _db!.Orders!.Add(order);
            _db.SaveChanges();
            IOrder ord = await this.ReadById(order.Num);
            return ord;
        }

    }

    public class Postamat : CRUD
    {
        public Postamat(ILogger<OrderController>? logger, PPTestContext? context) : base(logger, context) { }
        public async Task<IEnumerable<IPostamat>> Read()
        {
            return await _db!.Postamats!
            .Where(ps => ps.Status == true)
            .OrderBy(s => s.Num).ToArrayAsync();
        }

        public async Task<IPostamat> ReadById(string id)
        {
            return await _db!.Postamats!
                .Where(or => or.Num == id)
                .FirstAsync();

        }
    }
}