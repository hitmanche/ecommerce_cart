namespace CL
{
    public static class Configuration
    {
        //ORNEK E-TICARET VERITABANI ADRESI #####
        public const string prmSqlConnection = "Server=database.ilogic.com.tr,3334;Application Name=BEAUTYWARE-SERVICE;Database=ecommerce;User ID=userecommerce;Password=userecommerce;Pooling=False";
        //REDIS SERVER ADRESI #####
        public const string prmRedisUrl = "213.159.7.199:6379";
        // MONGODB SERVER ADRESI ########
        public const string prMongodb = "mongodb://213.159.7.199:27017";
        //KARTA ATILAN URUNLERIN KARTTA KALACAGI SURE (DK) #####
        public const int prmExpiresCart = 180;
        //KARTA ATILAN VERILER HANGI SERVER UZERINDE TUTULACAK #####
        public const CartLogic prmCartServer = CartLogic.Mongodb;
    }

    public enum CartLogic
    {
        Redis=0,
        Mongodb=1
    }
}
