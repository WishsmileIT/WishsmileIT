using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;

namespace QuickKartService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        QuickKartRepository repository;
        public ProductController()
        {
            repository = new QuickKartRepository();
        }
        [HttpGet]
        public JsonResult GetAllProducts()
        {
            List<Products> products = new List<Products>();
            try
            {
                products = repository.GetAllProducts();
            }
            catch (Exception)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpGet]
        public JsonResult GetProductById(string productId)
        {
            Products product = null;
            try
            {
                product = repository.GetProductById(productId);
            }
            catch (Exception )
            {
                product = null;
            }
            return Json(product);
        }

        [HttpPost]
        public JsonResult AddProductUsingParams(string productName, byte categoryId, decimal price, int quantityAvailable)
        {
            bool status = false;
            string productId = null;
            string message;
            try
            {
                status = repository.AddProduct(productName, categoryId, price, quantityAvailable, out productId);
                if (status)
                {
                    message = "Successful addition operation, ProductId = " + productId;
                }
                else
                {
                    message = "Unsuccessful addition operation!";
                }
            }
            catch (Exception)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }


    }
}