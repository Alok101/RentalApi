using Microsoft.EntityFrameworkCore;
using Rental.API.Business.Interface;
using Rental.API.Infrastructures;
using Rental.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.API.Business.Model
{
    public class ServiceRepository:IServiceRepository
    {
        private readonly RentalDbContext _context;
        public ServiceRepository(RentalDbContext context)
        {
            _context = context;
        }
       
    }
}
