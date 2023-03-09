using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.DIPGoodAndBad
{
    public class ProductService
    {
        private readonly ProductRepositoryFromSqlServer _repository;

        public ProductService(ProductRepositoryFromSqlServer repository)
        {
            _repository = repository;
        }

        public List<string> GetAll()
        {
            return _repository.GetAll();
        }
    }

    public class ProductRepositoryFromSqlServer:IRepository
    {
        public List<string> GetAll()
        {
            return new List<string> { "sqlKalem 1", "sqlKalem 2" };

        }

    }
    
    public class ProductRepositoryFromOracle:IRepository
    {
        public List<string> GetAll()
        {
            return new List<string> { "oracleKalem 1", "oracleKalem 2" };

        }

    }

    public interface IRepository
    {
        List<string> GetAll();
    }

}
