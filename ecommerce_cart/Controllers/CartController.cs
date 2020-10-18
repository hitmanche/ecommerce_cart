using BL.Business.CartOperations;
using BL.Business.ControlOperations;
using BL.Business.FilterOperations;
using BL.Repositories;
using CL.DBModel;
using Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce_cart.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AgentFilter]
    public class CartController : ControllerBase
    {
        language _lang;
        Cart _cart;

        public CartController(language lang,Cart cart)
        {
            _lang = lang;
            _cart = cart;
        }

        [HttpGet]
        public async Task<ActionResult> Add(int id)
        {
            var prmResult = await new StockControl().GeneralControl(id);
            if (!prmResult.prmControl)
            {
                return BadRequest(_lang.GetErrorString(prmResult.prmData));
            }
            else
            {
                var returnData=await _cart.AddCart(id);
                return Ok(returnData);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _cart.GetCart());
        }

        [HttpGet]
        public async Task<ActionResult> Remove(int id)
        {
            return Ok(await _cart.RemoveCart(id));
        }
    }
}
