using Servicios.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Repository
{
<<<<<<< HEAD
    /* Interface generica de tipo IDocument de del CRUD para la persistencia  */
=======
>>>>>>> bab830fca3d29e30815a6c4a1ad9f8a6965ff2de
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task<IEnumerable<TDocument>> GetAll();

        Task<TDocument> GetById(string Id);

        Task InsertDocument(TDocument document);

        Task UpdatetDocument(TDocument document);

        Task DeleteByID(string Id);

        Task<PaginationEntity<TDocument>> PaginationBy(
            Expression<Func<TDocument, bool>> filterExpression, 
            PaginationEntity<TDocument> pagination
        );

        Task<PaginationEntity<TDocument>> PaginationByFilter(
           PaginationEntity<TDocument> pagination
        );
    }
}
