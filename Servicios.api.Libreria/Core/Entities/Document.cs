using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
    public class Document : IDocument /* Implementa la interfaz */
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] /* Declaramos que es el Id de Mongo */
        public string Id { get; set; }

        public DateTime CreateDate => DateTime.Now;
    }
}
