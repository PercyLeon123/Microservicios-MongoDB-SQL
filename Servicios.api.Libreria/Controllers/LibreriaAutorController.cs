using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.api.Libreria.Core.Entities;
using Servicios.api.Libreria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaAutorController : ControllerBase
    {
<<<<<<< HEAD
        /* Variable de solo lectura, se esta usando la clase generica para la persistencia de datos */
        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;

        /* Injeccion de dependencias, se esta instanciando MongoDB tabla */
=======
        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;

>>>>>>> bab830fca3d29e30815a6c4a1ad9f8a6965ff2de
        public LibreriaAutorController(IMongoRepository<AutorEntity> autorGenericoRepository) 
        {
            _autorGenericoRepository = autorGenericoRepository;
        }

<<<<<<< HEAD
        /* Utilizamos la instancia para usar los metodos ya definidos en nuestra clase generica */
=======
>>>>>>> bab830fca3d29e30815a6c4a1ad9f8a6965ff2de

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Get() 
        {
            return Ok(await _autorGenericoRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetById(string Id)
        {
            var autor = await _autorGenericoRepository.GetById(Id);
            return Ok(autor);
        }

        [HttpPost]
        public async Task Post(AutorEntity autor)
        {
            await _autorGenericoRepository.InsertDocument(autor);
        }

        [HttpPut("{id}")]
        public async Task Put(string Id, AutorEntity autor)
        {
            autor.Id = Id;
            await _autorGenericoRepository.UpdatetDocument(autor);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string Id)
        {
            await _autorGenericoRepository.DeleteByID(Id);
        }

        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPagination(PaginationEntity<AutorEntity> pagination)
        {
            var resultados = await _autorGenericoRepository.PaginationBy(
                                    filter => filter.Nombre == pagination.Filter,
                                    pagination);
            return Ok(resultados);
        }

        [HttpPost("paginationFilter")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPaginationFilter(PaginationEntity<AutorEntity> pagination)
        {
            var resultados = await _autorGenericoRepository.PaginationByFilter(pagination);
            return Ok(resultados);
        }
    }
}
