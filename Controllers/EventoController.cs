using DSW_3P_PR02.Models;
using DSW_3P_PR02.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSW_3P_PR02.Controllers;

[ApiController]
[Route("api/eventos")]
public sealed class EventoController : ControllerBase
{
    private readonly IEventoService _service;

    public EventoController(IEventoService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Evento>), StatusCodes.Status200OK)]
    public ActionResult<List<Evento>> ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Evento), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Evento> ObtenerPorId(int id)
    {
        var evento = _service.ObtenerPorId(id);
        if (evento is null)
            return NotFound();

        return Ok(evento);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Evento), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Evento> Agregar([FromBody] Evento evento)
    {
        var creado = _service.Agregar(evento);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Evento), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Evento> Actualizar(int id, [FromBody] Evento evento)
    {
        var actualizada = _service.Actualizar(id, evento);
        if (actualizada is null)
            return NotFound();

        return Ok(actualizada);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Eliminar(int id)
    {
        if (!_service.Eliminar(id))
            return NotFound();

        return NoContent();
    }
}
