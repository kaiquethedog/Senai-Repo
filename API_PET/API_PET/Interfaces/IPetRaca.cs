using API_PET.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PET.Interfaces
{
    interface IPetRaca
    {
        PetRaca Registrar(PetRaca pr);

        List<PetRaca> LerTodos();

        PetRaca BuscarPorId(int id);

        PetRaca Alterar(PetRaca pr);

        PetRaca Excluir(PetRaca pr);
    }
}
