using Microsoft.AspNetCore.Mvc;

using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository bookRepository;
        public CartController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Add(int id)
        {
            var book = bookRepository.GetById(id);
            Cart cart;
            if (!HttpContext.Session.tryGetCart(out cart))
                cart = new Cart();
            if (cart.Item.ContainsKey(id))

                cart.Item[id]++;

            else

                cart.Item[id] = 1;

            cart.Amount += book.Price;
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new { id });
        }
    }
}
