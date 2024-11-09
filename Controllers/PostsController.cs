using BlogCsAngular.Data.ViewModels;
using BlogCsAngular.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BlogCsAngular.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostsService _service;

        public PostsController(PostsService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<PostsViewModel>> ListAll()
        {
            try
            {
                var posts = await _service.GetAll();

                return Ok(posts);   
            }
            catch
            {
                throw new Exception("Error");
            }

        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<PostsViewModel>> GetPost(int id)
        {
            try
            {
                var post = await _service.GetPost(id);
                return Ok(post);
            }
            catch(Exception ex)
            {
                throw new Exception($"No se encontro el posts {ex.Message}");
            }
        }

        [HttpPost("addPost")]
        public async Task<ActionResult> AddPost(PostsViewModel model)
        {
            try
            {
                await _service.AddPost(model);
                return Ok("Dato Agregado Correctamente");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditarPost( PostsViewModel model, int id)
        {
            if (model == null)
            {
                return BadRequest("El modelo no puede estar vacío");
            }

            var post = await  _service.EditPost(id, model);

            if (post == null) // Verificar si el post fue encontrado y editado
            {
                return NotFound("No se encontró el post con el ID especificado.");
            }

            return Ok("Dato editado correctamente");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await _service.DeletePost(id);
                return Ok("Dato eliminado Correctamente");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
