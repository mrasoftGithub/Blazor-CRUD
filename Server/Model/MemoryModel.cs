using CRUD.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Server.Model
{
    public class MemoryModel : IModel
    {
        private readonly List<EIGENAAR> _Eigenaren = new List<EIGENAAR>
        {
            new EIGENAAR() { ID =1, Omschrijving="Sandra's auto", Regio="Noord", Voornaam="Sandra", Achternaam="Janssen"},
            new EIGENAAR() { ID =2, Omschrijving="Peter's auto", Regio="Midden", Voornaam="Peter", Achternaam="Veerman"},
            new EIGENAAR() { ID =3, Omschrijving="Olga's auto", Regio="Zuid", Voornaam="Olga", Achternaam="Mulder"},
            new EIGENAAR() { ID =4, Omschrijving="Piet's auto", Regio="Noord", Voornaam="Piet", Achternaam="Pietersen"},
            new EIGENAAR() { ID =5, Omschrijving="Klaas' auto", Regio="Midden", Voornaam="Klaas", Achternaam="Vaak"},
            new EIGENAAR() { ID =6, Omschrijving="Jan's auto", Regio="Zuid", Voornaam="Jan", Achternaam="Janssen"},
            new EIGENAAR() { ID =7, Omschrijving="Petra's auto", Regio="Noord", Voornaam="Petra", Achternaam="Petersen"},
            new EIGENAAR() { ID =8, Omschrijving="Nicole's auto", Regio="Midden", Voornaam="Nicole", Achternaam="Nicholsen"},
            new EIGENAAR() { ID =9, Omschrijving="Olga's auto", Regio="Zuid", Voornaam="Olga", Achternaam="Olafsson"},
            new EIGENAAR() { ID =10, Omschrijving="Helga's auto", Regio="Noord", Voornaam="Helga", Achternaam="Helgoland"},
            new EIGENAAR() { ID =11, Omschrijving="Maaike's auto", Regio="Midden", Voornaam="Maaike", Achternaam="Bourtange"},
            new EIGENAAR() { ID =12, Omschrijving="Eric's auto", Regio="Zuid", Voornaam="Eric", Achternaam="Ericsson"},
            new EIGENAAR() { ID =13, Omschrijving="Jürgen's auto", Regio="Noord", Voornaam="Jürgen", Achternaam="Peelhoven"},
            new EIGENAAR() { ID =14, Omschrijving="Patrick's auto", Regio="Midden", Voornaam="Patrick", Achternaam="Oss"},
            new EIGENAAR() { ID =15, Omschrijving="Kristina's auto", Regio="Zuid", Voornaam="Kristina", Achternaam="Woudrich"},
            new EIGENAAR() { ID =16, Omschrijving="Dirk's auto ", Regio="Noord", Voornaam="Dirk", Achternaam="Broekema"},
            new EIGENAAR() { ID =17, Omschrijving="Fred's auto", Regio="Midden", Voornaam="Fred", Achternaam="Seedorf"},
            new EIGENAAR() { ID =18, Omschrijving="Richard's auto", Regio="Zuid", Voornaam="Richard", Achternaam="Lith"},
            new EIGENAAR() { ID =19, Omschrijving="Herman's auto", Regio="Noord", Voornaam="Herman", Achternaam="Zwijger"},
            new EIGENAAR() { ID =20, Omschrijving="Lara's auto", Regio="Midden", Voornaam="Lara", Achternaam="Tielsen"},
            new EIGENAAR() { ID =21, Omschrijving="Bernhard's auto", Regio="Zuid", Voornaam="Bernhard", Achternaam="Amshof"},
            new EIGENAAR() { ID =22, Omschrijving="Marisca's auto", Regio="Noord", Voornaam="Marisca", Achternaam="Schiermonnik"},
            new EIGENAAR() { ID =23, Omschrijving="Tamara's auto", Regio="Midden", Voornaam="Tamara", Achternaam="Laerhoven"}
        };

        public async Task<IEnumerable<EIGENAAR>> HaalOpEigenaren()
        {
            // await Task.Delay(0);
            // throw new NotImplementedException();
            return await Task.Run(() => _Eigenaren);
        }

        public async Task<EIGENAAR> HaalopEigenaar(int ID)
        {
            // await Task.Delay(0);
            // throw new NotImplementedException();
            return await Task.Run(() => _Eigenaren.FirstOrDefault(x => x.ID == ID));
        }

        public async Task<EIGENAAR> VoegToe(EIGENAAR eigenaar)
        {
            return await Task.Run(() =>
            {
                // throw new NotImplementedException();

                // Bepaal de ID
                if (_Eigenaren.Count == 0)
                {
                    eigenaar.ID = 1;
                }
                else
                {
                    eigenaar.ID = _Eigenaren.Max(e => e.ID) + 1;
                }

                // Toevoegen
                _Eigenaren.Add(eigenaar);

                // Retourneer
                return eigenaar;
            });
        }

        public async Task<EIGENAAR> Muteer(EIGENAAR eigenaar)
        {
            return await Task.Run(() =>
            {
                // throw new NotImplementedException();

                // Haal de originele gegevens op
                var eigenaarOrg = _Eigenaren.FirstOrDefault(x => x.ID == eigenaar.ID);

                // Niks gevonden, retourneer leeg object
                if (eigenaarOrg == null) return eigenaarOrg;

                // Werk de List bij 
                var index = _Eigenaren.IndexOf(eigenaarOrg);
                _Eigenaren[index] = eigenaar;

                // Retourneer
                return eigenaar;
            });
        }

        public async Task<bool> Verwijder(int ID)
        {
            return await Task.Run(() =>
            {
                // throw new NotImplementedException();

                // Haal de originele gegevens op
                var eigenaarOrg = _Eigenaren.FirstOrDefault(x => x.ID == ID);

                // Niks gevonden, retourneer leeg object
                if (eigenaarOrg == null) return false;

                // Verwijder 
                _Eigenaren.Remove(eigenaarOrg);
                return true;
            });
        }
    }
}
