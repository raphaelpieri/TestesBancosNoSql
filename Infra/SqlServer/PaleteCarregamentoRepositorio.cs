using System;
using System.Collections.Generic;
using System.Linq;
using Domain.PaletesCarregamento;
using Microsoft.EntityFrameworkCore;

namespace Infra.SqlServer
{
    public class PaleteCarregamentoRepositorio : IPaleteCarregamentoRepositorio
    {
        private readonly SqlServerContext _context;

        public PaleteCarregamentoRepositorio(SqlServerContext context)
        {
            _context = context;
        }


        public void Salvar(PaleteCarregamento paletesCarregamento)
        {
            _context.Paletes.Add(paletesCarregamento);
            _context.SaveChanges();
        }

        public IList<PaleteCarregamento> BuscarTodos()
        {
            return _context.Paletes.ToList();
        }

        public PaleteCarregamento Buscar(Guid id)
        {
            return _context.Paletes.FirstOrDefault(x => x.Id == id);
        }

        public PaleteCarregamento BuscarElasticSearch(Guid id)
        {
            throw new NotImplementedException();
        }

        public PaleteCarregamento Buscar(string nome)
        {
            return _context.Paletes.FirstOrDefault(x => x.NumeroDocumento.Equals(nome));
        }
    }
}