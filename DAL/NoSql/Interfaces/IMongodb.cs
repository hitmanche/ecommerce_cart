using System.Threading.Tasks;

namespace DAL.NoSql.Interfaces
{
    public interface IMongodb
    {
        public void SetString(string prmKey, string prmValue);
        public Task<string> GetString(string prmKey);
    }
}
