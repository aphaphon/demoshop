using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shopapi.Models;

namespace shopapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<History> histories = new List<History>();

        [HttpPost]
        public void Post([FromBody]Order order)
        {
            // ดึงรายการสินค้าทั้งหมดที่มีมา
            var productCtr = new ProductController();
            var allProducts = productCtr.Get();

            // หาสินค้าที่ผู้ใช้เลือกซื้อว่ามีหรือเปล่า
            var selectedProduct = allProducts.FirstOrDefault(it => it.Id == order.Id);
            if (selectedProduct == null)
            {
                // ไม่มีสินค้าที่ผู้ใช้เลือก ไม่ทำต่อ
                return;
            }

            // มีสินค้าที่ผู้ใช้เลือก ทำการบันทึกประวัติการสั่งซื้อ
            var history = new History
            {
                Id = Guid.NewGuid().ToString(),
                Amount = order.Amount,
                Name = selectedProduct.Name,
                Price = selectedProduct.Price * order.Amount,
            };
            histories.Add(history);
        }

        [HttpGet]
        public IEnumerable<History> Get()
        {
            return histories;
        }
    }
}
