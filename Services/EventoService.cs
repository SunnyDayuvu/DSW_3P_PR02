using DSW_3P_PR02.Models;
using DSW_3P_PR02.Repositories;

namespace DSW_3P_PR02.Services;

public sealed class EventoService : IEventoService
{
    private readonly IEventoRepository _repository;

    public EventoService(IEventoRepository repository)
    {
        _repository = repository;
    }

    public List<Evento> ObtenerTodos()
    {
        return _repository.ObtenerTodos();
    }

    public Evento? ObtenerPorId(int id)
    {
        return _repository.ObtenerPorId(id);
    }

    public Evento Agregar(Evento evento)
    {
        ArgumentNullException.ThrowIfNull(evento);
        return _repository.Agregar(evento);
    }

    public Evento? Actualizar(int id, Evento evento)
    {
        ArgumentNullException.ThrowIfNull(evento);
        return _repository.Actualizar(id, evento);
    }

    public bool Eliminar(int id)
    {
        return _repository.Eliminar(id);
    }
}
