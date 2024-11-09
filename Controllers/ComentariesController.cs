using BlogCsAngular.Data.ViewModels;
using BlogCsAngular.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCsAngular.Controllers
{
    [Route("api/comentary")]
    [ApiController]
    public class ComentariesController : ControllerBase
    {
        private readonly ComentariesService _comentariesService;

        public ComentariesController(ComentariesService comentariesService)
        {
            _comentariesService = comentariesService;
        }

        [HttpGet("AllComent")]
        public async Task<ActionResult<ComentaryViewModel>> GetAll()
        {
            try
            {
                var listaComentarios = await _comentariesService.GetAll();
                return Ok(listaComentarios);
            }
            catch (Exception ex)
            {
                throw new Exception("Error"+ex);
            }
        }
    }   
}
