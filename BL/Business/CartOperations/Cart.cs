﻿using BL.Business.Cart;
using BL.Business.Global;
using BL.Repositories;
using CL;
using CL.Cart;
using CL.DBModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Business.CartOperations
{
    public class Cart
    {
        ACart cart;
        GenericUnitOfWork _dbContext;
        string _prmUserAgent;
        public Cart(IHttpContextAccessor context)
        {
            _prmUserAgent = Hash.SHA256(context.HttpContext.Request.Headers["User-Agent"].ToString());
            _dbContext = new GenericUnitOfWork();
            switch (Configuration.prmCartServer)
            {
                case CartLogic.Redis:
                    cart = new CartRedis();
                    break;
                case CartLogic.MemoryCache:
                    break;
            }
        }

        public async Task<object> GetCart()
        {

            List<ProductCart> cartData = new List<ProductCart>();
            try
            {
                string resultData = await cart.GetCart(_prmUserAgent);
                var listData = JsonConvert.DeserializeObject<List<ProductCart>>(resultData);
                cartData.AddRange(listData);
            }
            catch (System.Exception ex)
            {

            }
            return cartData;
        }

        public async Task<object> AddCart(int prmId)
        {
            List<ProductCart> cartData = await GetCart() as List<ProductCart>;
            ProductCart prmFind = cartData.Where(x => x.id == prmId).FirstOrDefault();
            product product = await _dbContext.Repository<product>().First(x => x.id == prmId);
            stock stock = await _dbContext.Repository<stock>().First(x => x.product == prmId);
            if (prmFind != null)
            {
                prmFind.quantity += 1;
                prmFind.totalAmount = prmFind.amount * prmFind.quantity;
            }
            else
            {
                cartData.Add(new ProductCart { id = prmId, quantity = 1, name = product.name, amount = stock.price, totalAmount = stock.price });
            }
            cart.AddCart(_prmUserAgent, JsonConvert.SerializeObject(cartData));
            return cartData;
        }

        public async Task<object> RemoveCart(int prmId)
        {
            List<ProductCart> cartData = await GetCart() as List<ProductCart>;
            ProductCart prmFind = cartData.Where(x => x.id == prmId).FirstOrDefault();
            if (prmFind==null)
            {
                cart.AddCart(_prmUserAgent, JsonConvert.SerializeObject(new List<ProductCart>()));
                return new List<ProductCart>();
            }
            else
            {
                cartData.Remove(prmFind);
                cart.AddCart(_prmUserAgent, JsonConvert.SerializeObject(cartData));
                return cartData;
            }
        }
    }
}
