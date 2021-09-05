using CRUD.Server.Data;
using CRUD.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Server.Model
{
    public class DBModel : IModel
    {
        private readonly DbContextClass _dbContextClass;

        public DBModel(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<IEnumerable<EIGENAAR>> HaalOpEigenaren()
        {
            // await Task.Delay(0);
            // throw new NotImplementedException();
            return await _dbContextClass.EIGENAAR.ToListAsync();
        }

        public async Task<EIGENAAR> HaalopEigenaar(int ID)
        {
            return await _dbContextClass.EIGENAAR.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<EIGENAAR> VoegToe(EIGENAAR eigenaar)
        {
            // Toevoegen
            _dbContextClass.EIGENAAR.Add(eigenaar);
            await _dbContextClass.SaveChangesAsync();

            // Retourneer
            return await _dbContextClass.EIGENAAR.FirstOrDefaultAsync(x => x.ID == eigenaar.ID);
        }

        public async Task<EIGENAAR> Muteer(EIGENAAR eigenaar)
        {
            // throw new NotImplementedException();
            var eigenaarOrg = await _dbContextClass.EIGENAAR.FirstOrDefaultAsync(x => x.ID == eigenaar.ID);

            // Niks gevonden, retourneer leeg object
            if (eigenaarOrg == null) return eigenaarOrg;

            eigenaarOrg.Omschrijving = eigenaar.Omschrijving;
            eigenaarOrg.Voornaam = eigenaar.Voornaam;
            eigenaarOrg.Achternaam = eigenaar.Achternaam;
            eigenaarOrg.Regio = eigenaar.Regio;

            await _dbContextClass.SaveChangesAsync();

            // Retourneer
            return await _dbContextClass.EIGENAAR.FirstOrDefaultAsync(x => x.ID == eigenaar.ID);
        }

        public async Task<bool> Verwijder(int ID)
        {
            var eigenaarOrg = await _dbContextClass.EIGENAAR.FirstOrDefaultAsync(x => x.ID == ID);

            // Niks gevonden, retourneer leeg object
            if (eigenaarOrg == null) return false;

            // En verwijder
            _dbContextClass.EIGENAAR.Remove(eigenaarOrg);
            await _dbContextClass.SaveChangesAsync();

            return true;
        }
    }
}
