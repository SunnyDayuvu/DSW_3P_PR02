using System.Collections.Concurrent;
using DSW_3P_PR02.Models;

namespace DSW_3P_PR02.Repositories;

public sealed class EventoRepository : IEventoRepository
{
    private readonly ConcurrentDictionary<int, Evento> _eventos = new();
    private int _siguienteId;

    public List<Evento> ObtenerTodos()
    {
        return _eventos.Values
            .OrderBy(evento => evento.Id)
            .Select(Copiar)
            .ToList();
    }

    public Evento? ObtenerPorId(int id)
    {
        return _eventos.TryGetValue(id, out var evento) ? Copiar(evento) : null;
    }

    public Evento Agregar(Evento evento)
    {
        var creado = Copiar(evento);
        creado.Id = Interlocked.Increment(ref _siguienteId);
        _eventos[creado.Id] = creado;
        return Copiar(creado);
    }

    public Evento? Actualizar(int id, Evento evento)
    {
        if (!_eventos.TryGetValue(id, out var existente))
            return null;

        var actualizado = Copiar(evento);
        actualizado.Id = id;
        return _eventos.TryUpdate(id, actualizado, existente) ? Copiar(actualizado) : null;
    }

    public bool Eliminar(int id)
    {
        return _eventos.TryRemove(id, out _);
    }

    private static Evento Copiar(Evento evento)
    {
        return new Evento
        {
            Id = evento.Id,
            Nombre = evento.Nombre,
            Categoria = evento.Categoria,
            Fecha = evento.Fecha,
            Lugar = evento.Lugar,
            CupoMaximo = evento.CupoMaximo,
            Activo = evento.Activo
        };
    }
}
