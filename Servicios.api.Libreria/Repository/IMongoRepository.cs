﻿using Servicios.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Repository
{
    /* Interface generica de tipo IDocument de del CRUD para la persistencia  */
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
