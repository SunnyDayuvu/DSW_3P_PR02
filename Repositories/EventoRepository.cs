using DSW_3P_PR02.Data;
using DSW_3P_PR02.Models;
using Microsoft.EntityFrameworkCore;

namespace DSW_3P_PR02.Repositories;

public sealed class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context;

    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Evento> ObtenerTodos()
    {
        return _context.Eventos
            .AsNoTracking()
            .OrderBy(evento => evento.Id)
            .ToList();
    }

    public Evento? ObtenerPorId(int id)
    {
        return _context.Eventos
            .AsNoTracking()
            .FirstOrDefault(evento => evento.Id == id);
    }

    public Evento Agregar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
        return evento;
    }

    public Evento? Actualizar(int id, Evento evento)
    {
        var existente = _context.Eventos.FirstOrDefault(actual => actual.Id == id);
        if (existente is null)
            return null;

        existente.Nombre = evento.Nombre;
        existente.Categoria = evento.Categoria;
        existente.Fecha = evento.Fecha;
        existente.Lugar = evento.Lugar;
        existente.CupoMaximo = evento.CupoMaximo;
        existente.Activo = evento.Activo;

        _context.SaveChanges();
        return existente;
    }

    public bool Eliminar(int id)
    {
        var evento = _context.Eventos.FirstOrDefault(actual => actual.Id == id);
        if (evento is null)
            return false;

        _context.Eventos.Remove(evento);
        _context.SaveChanges();
        return true;
    }
}
