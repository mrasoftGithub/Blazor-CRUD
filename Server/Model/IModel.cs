using CRUD.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Server.Model
{
    public interface IModel
    {
        Task<IEnumerable<EIGENAAR>> HaalOpEigenaren();

        Task<EIGENAAR> HaalopEigenaar(int ID);

        Task<EIGENAAR>  VoegToe (EIGENAAR eigenaar);

        Task <EIGENAAR> Muteer(EIGENAAR eigenaar);

        Task<bool> Verwijder(int ID);
    }
}
