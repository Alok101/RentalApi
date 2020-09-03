using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental.API.Business.Interface;
using Rental.API.Data.Models;
using Rental.API.Infrastructures;
using Rental.API.Model;
using Rental.API.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Rental.API.Controllers
{
    [Route("api/Internal")]
    [ApiController]
    public class InternalController : ControllerBase
    {
        private readonly ILogger<InternalController> _logger;
        private readonly RentalDbContext _context;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        /// <summary>
        /// [controller]
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <param name="serviceRepository"></param>
        public InternalController(RentalDbContext context, ILogger<InternalController> logger,IServiceRepository serviceRepository,IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        //Get Field Records By Id
        [HttpGet]
        [ActionName("MastersByIdAsync")]
        [Route("masters/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(FieldMaster), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<FieldMaster>> MastersByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var rowData = await _context.FieldMasters.SingleOrDefaultAsync(ci => ci.Id == id);
            if (rowData != null)
            {
                return rowData;
            }
            return NotFound();
        }

        //Post : Save common master details
        [Route("masters")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> SaveCommonMaster([FromBody]MasterViewModel master)
        {
            FieldMaster model = new FieldMaster()
            {
                Name = master.Name,
                GroupCode = master.GroupCode,
                Status = master.Status,
                CreateDate = master.CreateDate,
                Description=master.Description
            };
            _context.FieldMasters.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(MastersByIdAsync), new { id = model.Id }, model);
        }

        //Get : All Field Master Records
        [Route("masters/all/groups")]
        [HttpGet]
        [ProducesResponseType(typeof(List<FieldMaster>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<FieldMaster>>> GetAllMastersGroup()
        {
            return await _context.FieldMasters.ToListAsync();
        }
        
        //Get : Records By Name
        [Route("masters/records")]
        [HttpGet]
        [ProducesResponseType(typeof(FieldMaster),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<FieldMaster>>GetMasterRecordsByName(string name)
        {
            return await _context.FieldMasters.SingleOrDefaultAsync(x => x.Name == name);
        }

        //Patch : Update Records
        [Route("masters/records/{id:int}")]
        [HttpPatch]
        public async Task<IActionResult> PatchMasterRecords(int id,[FromBody] JsonPatchDocument<FieldMasterForUpdateDto> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }
            var existingFieldMaster = await _context.FieldMasters.SingleOrDefaultAsync(x => x.Id == id);
            if (existingFieldMaster == null)
            {
                return NotFound();
            }
            var masterToPatch = _mapper.Map<FieldMasterForUpdateDto>(existingFieldMaster);
            patchDoc.ApplyTo(masterToPatch, ModelState);
            var isValid = TryValidateModel(existingFieldMaster);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(masterToPatch, existingFieldMaster); // apply updates from the updatable category to the db entity so we can apply the updates to the database
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        //Delete : Records By Id
        [Route("masters/records/{id:int}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var master = await _context.FieldMasters.SingleOrDefaultAsync(x => x.Id == id);

            if (master == null)
            {
                return NotFound();
            }
            _context.FieldMasters.Remove(master);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}