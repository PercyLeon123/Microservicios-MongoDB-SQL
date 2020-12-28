using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Servicios.api.Libreria.Core;
using Servicios.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Repository
{
    /* TDocument es una clase generica, esta clase generia debe ser de tipo IDocument */
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        /* Aqui se guardara la intancia a la coleccion de mongoDB */
        private readonly IMongoCollection<TDocument> _collection;

        /*Creamos la conexion con la DB e instanciamos nuestra coleccion */
        public MongoRepository(IOptions<MongoSettings> options) 
        {
            var client = new MongoClient(options.Value.ConnectionString);/*Creamos la conexion*/
            var _db = client.GetDatabase(options.Value.Database); /*instanciamos la DB*/
            _collection = _db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));/*instanciamos la coleccion*/
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

        public async Task<TDocument> GetById(string Id)
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

        public async Task<PaginationEntity<TDocument>> PaginationBy(Expression<Func<TDocument, bool>> filterExpression, PaginationEntity<TDocument> pagination)
        {
            var sort = Builders<TDocument>.Sort.Ascending(pagination.Sort);
            if (pagination.SortDirection == "desc") 
            {
                sort = Builders<TDocument>.Sort.Descending(pagination.Sort);
            }

            if (string.IsNullOrEmpty(pagination.Filter))
            {
                pagination.Data = await _collection.Find(p => true)
                                .Sort(sort)
                                .Skip((pagination.Page - 1) * pagination.PageSize)
                                .Limit(pagination.PageSize)
                                .ToListAsync();
            }
            else 
            {
                pagination.Data = await _collection.Find(filterExpression)
                                .Sort(sort)
                                .Skip((pagination.Page - 1) * pagination.PageSize)
                                .Limit(pagination.PageSize)
                                .ToListAsync();
            }

            long totalDocument = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            var totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalDocument/pagination.PageSize)));
            pagination.PagesQuantity = totalPages;
            return pagination;
        }

        public async Task<PaginationEntity<TDocument>> PaginationByFilter(PaginationEntity<TDocument> pagination)
        {
            var sort = Builders<TDocument>.Sort.Ascending(pagination.Sort);
            if (pagination.SortDirection == "desc")
            {
                sort = Builders<TDocument>.Sort.Descending(pagination.Sort);
            }

            var totalDocument = 0;
            if (pagination.FilterValue == null)
            {
                pagination.Data = await _collection.Find(p => true)
                                .Sort(sort)
                                .Skip((pagination.Page - 1) * pagination.PageSize)
                                .Limit(pagination.PageSize)
                                .ToListAsync();
                totalDocument = (await _collection.Find(p => true).ToListAsync()).Count();
            }
            else
            {
                var valueFilter = ".*" + pagination.FilterValue.Valor + ".*";
                var filter = Builders<TDocument>.Filter.Regex(pagination.FilterValue.Propiedad, new BsonRegularExpression(valueFilter, "i"));

                pagination.Data = await _collection.Find(filter)
                                .Sort(sort)
                                .Skip((pagination.Page - 1) * pagination.PageSize)
                                .Limit(pagination.PageSize)
                                .ToListAsync();
                totalDocument = (await _collection.Find(filter).ToListAsync()).Count();
            }

            //long totalDocument = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            var round = Math.Ceiling(totalDocument / Convert.ToDecimal(pagination.PageSize));

            var totalPages = Convert.ToInt32(round);

            pagination.PagesQuantity = totalPages;
            pagination.TotalRows = Convert.ToInt32(totalDocument);
            return pagination;
        }
    }
}
