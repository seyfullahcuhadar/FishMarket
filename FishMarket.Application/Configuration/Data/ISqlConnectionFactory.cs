using System.Data;

namespace FishMarket.Application.Configuration.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}