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
    public class LibreriaServicioController : Controller
    {
        private readonly IAutorRepository _autorRepository;/*Interface unica para una clase*/
        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository; /* Interface generica */
        private readonly IMongoRepository<EmpleadoEntity> _empleadoGenericoRepository;

        public LibreriaServicioController(IAutorRepository autorRepository, 
            IMongoRepository<AutorEntity> autorGenericoRepository,
            IMongoRepository<EmpleadoEntity> empleadoGenericoRepository) 
        {
            _autorRepository = autorRepository;
            _autorGenericoRepository = autorGenericoRepository;
            _empleadoGenericoRepository = empleadoGenericoRepository;
        }

        [HttpGet("EmpleadoGenerico")]
        public async Task<ActionResult<IEnumerable<EmpleadoEntity>>> GetEmpleadoGenerico()
        {
            var empleado = await _empleadoGenericoRepository.GetAll();
            return Ok(empleado);
        }

        [HttpGet("autoresGenerico")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutorGenerico() 
        {
            var autores = await _autorGenericoRepository.GetAll();
            return Ok(autores);
        }

        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorRepository.GetAutores();
            return Ok(autores);
        }
    }
}
