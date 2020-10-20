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

        public async Task<(bool prmControl, string prmData)> GeneralControl(Int64 prmProductId, int prmQuantity)
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
            else if (ProductDeleted(pro))
            {
                return (false, "1010");
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
            else if (!QuantityControl(sto, prmQuantity))
            {
                return (false, "1009");
            }
            else if (!ReservedQuantity(sto, prmQuantity))
            {
                return (false, "1011");
            }
            return (true, null);
        }

        private bool ReservedQuantity(stock pro, int prmQuantity)
        {
            if (pro.quantity < prmQuantity + pro.reserved_quantity)
            {
                return false;
            }
            return true;
        }

        private bool QuantityControl(stock pro, int prmQuantity)
        {
            if (pro.quantity < prmQuantity)
            {
                return false;
            }
            return true;
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
        private bool ProductDeleted(product pro)
        {
            if (pro.deleted == true)
            {
                return true;
            }
            return false;
        }
    }
}
