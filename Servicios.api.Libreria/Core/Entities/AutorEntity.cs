using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
    [BsonCollection("Autor")] /* Nombre de la tabla en MongoDB */
    public class AutorEntity : Document /* Hereda la clase */
    {
        [BsonElement("nombre")] /* Nombre del campo en MongoDB */
        public string Nombre { get; set; }
        [BsonElement("apellido")]
        public string Apellido { get; set; }
        [BsonElement("gradoAcademico")]
        public string GradoAcademico { get; set; }
    }
}
