using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plattform_partizipatives_neophytenmanagement.Data;
using plattform_partizipatives_neophytenmanagement.Models; // Add the appropriate namespace for FarmerHelpRequest and FarmerHelperMatchContext


namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FarmerHelpRequestsController : ControllerBase
    {
        private readonly FarmerHelperMatchContext _context;

        public FarmerHelpRequestsController(FarmerHelperMatchContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FarmerHelpRequest>> GetFarmerHelpRequests()
        {
            return _context.FarmerHelpRequests.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<FarmerHelpRequest> GetFarmerHelpRequest(int id)
        {
            var farmerHelpRequest = _context.FarmerHelpRequests.Find(id);

            if (farmerHelpRequest == null)
            {
                return NotFound();
            }

            return farmerHelpRequest;
        }

        [HttpPost]
        public ActionResult<FarmerHelpRequest> CreateFarmerHelpRequest(FarmerHelpRequest farmerHelpRequest)
        {
            _context.FarmerHelpRequests.Add(farmerHelpRequest);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFarmerHelpRequest), new { id = farmerHelpRequest.Id }, farmerHelpRequest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFarmerHelpRequest(int id, FarmerHelpRequest farmerHelpRequest)
        {
            if (id != farmerHelpRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(farmerHelpRequest).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFarmerHelpRequest(int id)
        {
            var farmerHelpRequest = _context.FarmerHelpRequests.Find(id);

            if (farmerHelpRequest == null)
            {
                return NotFound();
            }

            _context.FarmerHelpRequests.Remove(farmerHelpRequest);
            _context.SaveChanges();

            return NoContent();
        }
    }
}