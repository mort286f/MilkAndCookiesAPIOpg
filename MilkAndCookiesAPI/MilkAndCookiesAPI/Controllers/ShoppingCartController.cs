using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkAndCookiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet("GetShoppingCart")]
        public IEnumerable<Product> GetCart()
        {
            List<Product> cart;
            //Get the session with the shoppingCart key string, to check ifs made
            cart = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");
            if (cart == null)
            {
                //if the cart is not yet made then a new cart is created
                cart = new List<Product>();
                //the new cart is set as the object on the session, which is a list of products.
                HttpContext.Session.SetObjectAsJson("shoppingCart", cart);
                //the newly created list object which i placed in the session, i then set equal to the cart list, and return it.
                cart = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");
            }
            return cart;

        }

        [HttpGet("AddItemToShoppingCart")]
        public IEnumerable<Product> AddProduct(string productName, double price)
        {
            //temporary list
            //Also gets the object from the shoppingCart session, and places it in the temporary list, so I can add a new item to it.
            List<Product> tempProdList = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");



            tempProdList.Add(new Product(productName, price));
            //After adding the new product, i place the temporary list as the session object.
            HttpContext.Session.SetObjectAsJson("shoppingCart", tempProdList);
            return tempProdList;
        }

        [HttpDelete("RemoveProduct")]
        public IEnumerable<Product> RemoveProduct(string productName, double price)
        {
            //List for holding the session object
            List<Product> tempProducts = HttpContext.Session.GetObjectFromJson<List<Product>>("shoppingCart");

            //new list for adding all items that are not the item you want to remove
            List<Product> tempProductsNew = new List<Product>();
            //Looks for all items that are not the product you want to remove, and move them to another list
            tempProductsNew = tempProducts.Where(x => x.Name != productName).ToList();
            //The list of all the products you wanna keep in the cart is then returned to the session object
            HttpContext.Session.SetObjectAsJson("shoppingCart", tempProductsNew);
            return tempProductsNew;
        }
    }
}
