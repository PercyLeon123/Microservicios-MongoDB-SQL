using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute /* Crea Atributos */
    {
        public string CollectionName { get; } /* Se guarda el nombre de la coleccion*/

        public BsonCollectionAttribute(string collectionName) 
        {
            CollectionName = collectionName;
        }

    }
}
