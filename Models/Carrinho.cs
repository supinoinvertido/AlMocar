
using AlMocar.Context;
using Microsoft.EntityFrameworkCore;
namespace AlMocar.Models
    {
        public class Carrinho
        {
            private readonly AppDbContext _context;
            public Carrinho(AppDbContext context)
            {
                _context = context;
            }

            public string CarrinhoId { get; set; }
            public List<CarrinhoItem> CarrinhoItens { get; set; }
            public static Carrinho GetCarrinhoCompra(IServiceProvider
            services)
            {

                ISession session =

                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

                var context = services.GetService<AppDbContext>();
                string carrinhoId = session.GetString("CarrinhoId") ??

                Guid.NewGuid().ToString();

                session.SetString("CarrinhoId", carrinhoId);
                return new Carrinho(context)
                {
                    CarrinhoId = carrinhoId
                };

            }
            public void AdicionarItemCarrinho(Item item)
            {
                var carinhoItem = _context.CarrinhoItems.SingleOrDefault(s =>

            s.Item.itemid == item.itemid && s.CarrinhoId == CarrinhoId);

                if (carinhoItem == null)
                {
                    carinhoItem = new CarrinhoItem
                    {
                        CarrinhoId = CarrinhoId,
                        Item = item,
                        Quantidade = 1
                    };
                    _context.CarrinhoItems.Add(carinhoItem);
                }
                else
                {
                    carinhoItem.Quantidade++;
                }
                _context.SaveChanges();
            }
            public int RemoverItemDoCarrinhoCompra(Item item)
            {
                var carrinhoQuantidade = 0;
                var carinhoItem = _context.CarrinhoItems.SingleOrDefault(s =>

                s.Item.itemid == item.itemid && s.CarrinhoId == CarrinhoId);

                if (carinhoItem != null)
                {
                    if (carinhoItem.Quantidade > 1)
                    {
                        carinhoItem.Quantidade--;
                        carrinhoQuantidade = carinhoItem.Quantidade;
                    }
                    else
                    {
                        _context.CarrinhoItems.Remove(carinhoItem);
                    }

                }
                _context.SaveChanges();
                return carrinhoQuantidade;
            }
            public List<CarrinhoItem> GetCarrinhoCompraItems()
            {
                return CarrinhoItens ?? _context.CarrinhoItems.Where(c =>c.CarrinhoId == CarrinhoId).Include(s => s.Item).ToList();
            }
            public void LimparCarrinho()
            {
                var carrinhoCompra = _context.CarrinhoItems.Where(c =>

            c.CarrinhoId == CarrinhoId);

                _context.CarrinhoItems.RemoveRange(carrinhoCompra);
                _context.SaveChanges();
            }
            public double GetCarrinhoCompraTotal()
            {
                List<double> total = _context.CarrinhoItems.Where(_c =>

                _c.CarrinhoId == CarrinhoId).Select(c =>
                c.Quantidade * c.Item.Valor).ToList();
                double totalr = 0;
                foreach (double t in total)
                {
                    totalr = totalr + t;
                }
                return totalr;
            }
        }
    }