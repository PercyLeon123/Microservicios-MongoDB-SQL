using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
<<<<<<< HEAD
    [BsonCollection("Autor")] /* Nombre de la tabla en MongoDB */
    public class AutorEntity : Document /* Hereda la clase */
    {
        [BsonElement("nombre")] /* Nombre del campo en MongoDB */
=======
    [BsonCollection("Autor")]
    public class AutorEntity : Document
    {
        [BsonElement("nombre")]
>>>>>>> bab830fca3d29e30815a6c4a1ad9f8a6965ff2de
        public string Nombre { get; set; }
        [BsonElement("apellido")]
        public string Apellido { get; set; }
        [BsonElement("gradoAcademico")]
        public string GradoAcademico { get; set; }
    }
}
