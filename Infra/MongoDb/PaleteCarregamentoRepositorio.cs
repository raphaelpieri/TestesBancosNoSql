﻿using System;
using System.Collections.Generic;
using Domain.PaletesCarregamento;
using MongoDB.Driver;

namespace Infra.MongoDb
{
    public class PaleteCarregamentoRepositorio : IPaleteCarregamentoRepositorio
    {
        public PaleteCarregamentoRepositorio(MongoDbContext context)
        {
            _context = context;
        }

        private readonly MongoDbContext _context;
        
        public void Salvar(PaleteCarregamento paletesCarregamento)
        {
            _context.PaletesCarregamento.InsertOne(paletesCarregamento);
        }

        public IList<PaleteCarregamento> BuscarTodos()
        {
            return _context.PaletesCarregamento.Find(m => true).ToList();
        }

        public PaleteCarregamento Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public PaleteCarregamento BuscarElasticSearch(Guid id)
        {
            throw new NotImplementedException();
        }

        public PaleteCarregamento Buscar(string nome)
        {
            throw new NotImplementedException();
        }
    }
}