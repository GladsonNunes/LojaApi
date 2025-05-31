using AutoMapper;
using LojaApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CoreController<TCreateDTO, TEntity> : ControllerBase where TEntity : Identificador, new()
    {
        private readonly IServCore<TEntity> _service;
        protected readonly IMapper _mapper;

        public CoreController(IServCore<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var items = _service.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = _service.GetById(id);
                if (item == null)
                {
                    return NotFound(new { error = "id not found", id = id });
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }

        [HttpPost]
        public virtual ActionResult<TEntity> Create([FromBody] TCreateDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }

                var item = _mapper.Map<TEntity>(dto);

                var createdItem = _service.Add(item);
                return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar o item.", details = ex.Message });
            }

        }

        [HttpPut("{id}")]
        public ActionResult<TEntity> Update(int id, [FromBody] TCreateDTO dto)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var item = _mapper.Map<TEntity>(dto);
                var itemUpdated = _service.Update(item);
                return Ok(itemUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", details = ex.Message });
            }
        }
    }
}
