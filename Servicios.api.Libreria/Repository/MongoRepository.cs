using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Servicios.api.Libreria.Core;
using Servicios.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Repository
{
    /*TDocument es una clase genreica esta clase generia debe ser de tipo IDocument*/
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection; /*aqui se guardara intancia a la coleccion de mongoDB */

        /*Creamos la conexion con la DB e intanciamos nuestra coleccion */
        public MongoRepository(IOptions<MongoSettings> options) 
        {
            var client = new MongoClient(options.Value.ConnectionString);/*Creamos la conexion*/
            var _db = client.GetDatabase(options.Value.Database); /*instanciamos la DB*/
            _collection = _db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument))); /*instanciamos la coleccion*/
        }

        /*Este metodo obtendra el nombre de la clase  para poder relacionarlo con en MongoDB*/
        private protected string GetCollectionName(Type documentType) 
        {
            return ((BsonCollectionAttribute)documentType
                .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault()).CollectionName;
        }

        public async Task<IEnumerable<TDocument>> GetAll()
        {
            return await _collection.Find(p=>true).ToListAsync();
        }

        public async Task<TDocument> GetBy(string Id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task InsertDocument(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task UpdatetDocument(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public async Task DeleteByID(string Id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
            await _collection.FindOneAndDeleteAsync(filter);
        }
    }
}
