using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class DoshamService : IDoshamRepository
    {
        readonly IDoshamService doshamServiceobj;

        public DoshamService(IDoshamService doshamService)
        {
            doshamServiceobj = doshamService;
        }
        public List<Dosham> GetDoshams(string doshamName)
        {
            return doshamServiceobj.GetDoshams(doshamName);
        }

        public Task<int> PostDosham(Dosham dosham)
        {
            return doshamServiceobj.PostDosham(dosham);
        }

        public int DeleteDosham(int doshamId)
        {
            return doshamServiceobj.DeleteDosham(doshamId);
        }
        }
}
