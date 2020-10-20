using BL.Repositories;
using CL.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Business.ControlOperations
{
    public class StockQuantity
    {
        GenericUnitOfWork _dbContext;
        public StockQuantity()
        {
            _dbContext = new GenericUnitOfWork();
        }

        public async void ReservedQuantityClear(int product)
        {
            stock st = await _dbContext.Repository<stock>().First(x => x.product == product);
            st.reserved_quantity = 0;
            await _dbContext.Repository<stock>().Update(st, new object[2] { st.id, st.product });
            await _dbContext.SaveChanges();
        }

        public async void ReservedQuantityAdd(int product, int quantity)
        {
            try
            {
                stock st = await _dbContext.Repository<stock>().First(x => x.product == product);
                st.reserved_quantity += quantity;
                await _dbContext.Repository<stock>().Update(st, new object[2]{ st.id,st.product});
                var res=await _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async void ReservedQuantityRemove(int product,int quantity)
        {
            stock st = await _dbContext.Repository<stock>().First(x => x.product == product);
            st.reserved_quantity -= quantity;
            st.reserved_quantity = st.reserved_quantity < 0 ? 0 : st.reserved_quantity;
            await _dbContext.Repository<stock>().Update(st, new object[2] { st.id, st.product });
            var res = await _dbContext.SaveChanges();
        }
    }
}
