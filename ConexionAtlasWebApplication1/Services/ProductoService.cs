using MongoDB.Driver;
using Zapateria.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Zapateria.Services
{
    public class ProductoService
    {
        private readonly IMongoCollection<Producto> _productos;

        public ProductoService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _productos = database.GetCollection<Producto>("Productos");
        }

        public List<Producto> Get() =>
            _productos.Find(producto => true).ToList();

        public Producto Get(string id) =>
            _productos.Find<Producto>(producto => producto.Id == id).FirstOrDefault();

        public Producto Create(Producto producto)
        {
            _productos.InsertOne(producto);
            return producto;
        }

        public void Update(string id, Producto productoIn) =>
            _productos.ReplaceOne(producto => producto.Id == id, productoIn);

        public void Remove(Producto productoIn) =>
            _productos.DeleteOne(producto => producto.Id == productoIn.Id);

        public void Remove(string id) =>
            _productos.DeleteOne(producto => producto.Id == id);
    }
}
