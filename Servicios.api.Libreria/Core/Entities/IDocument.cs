using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  /* Declaramos que es el Id de Mongo */
        string Id { get; set; }
        DateTime CreateDate { get; } /* Solo lectura */
    }
}
