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
<<<<<<< HEAD
        [BsonRepresentation(BsonType.ObjectId)]  /* Declaramos que es el Id de Mongo */
        string Id { get; set; }
        DateTime CreateDate { get; } /* Solo lectura */
=======
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
        DateTime CreateDate { get; }
>>>>>>> bab830fca3d29e30815a6c4a1ad9f8a6965ff2de
    }
}
