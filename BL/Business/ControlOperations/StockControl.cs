using BL.Repositories;
using CL.DBModel;
using Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Business.ControlOperations
{
    public class StockControl
    {
        GenericUnitOfWork dbConnect;
        public StockControl()
        {
            dbConnect = new GenericUnitOfWork();
        }

        public async Task<(bool prmControl, string prmData)> GeneralControl(Int64 prmProductId)
        {
            stock sto = await dbConnect.Repository<stock>().First(x => x.product == prmProductId);
            product pro = await dbConnect.Repository<product>().First(x => x.id == prmProductId);
            if (pro == null)
            {
                return (false, "1006");
            }
            else if (sto == null)
            {
                return (false, "1003");
            }
            else if (!StockUsingDate(sto))
            {
                return (false, "1008");
            }
            else if (!StockStatus(sto))
            {
                return (false, "1005");
            }
            else if (!ProductStatus(pro))
            {
                return (false, "1007");
            }
            else if (!Quantity(sto))
            {
                return (false, "1004");
            }
            return (true, null);
        }

        private bool Quantity(stock pro)
        {
            if (pro.quantity < 1)
            {
                return false;
            }
            return true;
        }

        private bool StockStatus(stock pro)
        {
            if (pro.status == false)
            {
                return false;
            }
            return true;
        }
        private bool StockUsingDate(stock pro)
        {
            if (pro.using_date < DateTime.Now)
            {
                return false;
            }
            return true;
        }
        private bool ProductStatus(product pro)
        {
            if (pro.status == false)
            {
                return false;
            }
            return true;
        }
    }
}
