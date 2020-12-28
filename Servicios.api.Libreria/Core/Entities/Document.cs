using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
<<<<<<< HEAD
    public class Document : IDocument /* Implementa la interfaz */
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] /* Declaramos que es el Id de Mongo */
=======
    public class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
>>>>>>> bab830fca3d29e30815a6c4a1ad9f8a6965ff2de
        public string Id { get; set; }

        public DateTime CreateDate => DateTime.Now;
    }
}
