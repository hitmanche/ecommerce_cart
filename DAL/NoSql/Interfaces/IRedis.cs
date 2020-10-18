using System.Threading.Tasks;

namespace DAL.Operations.Interfaces
{
    public interface IRedis
    {
        public void SetString(string prmKey, string prmValue);
        public Task<string> GetString(string prmKey);
    }
}
