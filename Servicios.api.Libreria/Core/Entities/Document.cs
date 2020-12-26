using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreateDate => Id.CreationTime;
    }
}
