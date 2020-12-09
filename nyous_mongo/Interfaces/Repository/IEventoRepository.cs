using nyous_mongo.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nyous_mongo.Interfaces.Repository
{
    public interface IEventoRepository
    {
        List<EventoDomain> Listar();

        EventoDomain BuscarPorId(string id);

        void Adicionar(EventoDomain evento);

        void Atualizar(string id, EventoDomain evento);

        void Remover(string id);
    }
}
