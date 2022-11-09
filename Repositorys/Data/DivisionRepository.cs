using API.Context;
using API.Models;
using API.Repository.Interface;
using API.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace API.Repository.Data
{
    public class DivisionRepository : GeneralRepository<Division>
    {
        private readonly MyContext _context;

        public DivisionRepository(MyContext context) : base(context)
        {
            _context = context;
        }



        [HttpGet("Name")]
        public IEnumerable<Division> Get(string name)
        {
            return _context.Divisions.Where(x => x.Name == name).ToList();
        }


    }
}
