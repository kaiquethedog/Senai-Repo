using API_PET.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PET.Interfaces
{
    interface ITipoDePet
    {
        TipoDePet Registrar(TipoDePet tp);

        List<TipoDePet> LerTodos();

        TipoDePet BuscarPorId(int id);

        TipoDePet Alterar(TipoDePet tp);

        TipoDePet Excluir(TipoDePet tp);
    }
}
