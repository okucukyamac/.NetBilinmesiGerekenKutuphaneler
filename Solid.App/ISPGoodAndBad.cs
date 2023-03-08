using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.ISPGoodAndBad
{
    // Class Library Read Impl
    // Class Library Create/Update/Delete Impl

    public class ReadProductRepository : IReadRepository
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class WriteProductRepository : IWriteRepository
    {
        public Product Create(int id)
        {
            throw new NotImplementedException();
        }

        public Product Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IReadRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
    }
    
    public interface IWriteRepository
    {
        Product Create(int id);
        Product Update(int id);
        Product Delete(int id);
    }


}
