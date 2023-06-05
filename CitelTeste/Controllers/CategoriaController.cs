using CitelTeste.DTO;
using CitelTeste.Model;
using CitelTeste.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CitelTeste.Controllers
{
    [ApiController]
    [Route("Categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _catgoriaService;

        public CategoriaController(ICategoriaService catgoriaService)
        {
            _catgoriaService = catgoriaService;
        }

        [HttpPost("Cadastrar")]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            try
            {
                _catgoriaService.CadastrarCategoria(categoria);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListaCategoria")]
        public ActionResult<List<Categoria>> ListaCategoria()
        {
            var listaCategoriaCadastrado = _catgoriaService.ListaCategoriaCadastro();

            return listaCategoriaCadastrado;
        }

        [HttpPut("EditarCategoria")]
        public ActionResult Editarcategoria(Categoria categoria)
        {
            try
            {
              _catgoriaService.EditarCategoria(categoria);
              
              return Ok();
            }
            catch(Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ApagarCategoria")]
        public ActionResult ApagarCategoria(ObjetoDTO categoriaDTO)
        {
            try
            {
                _catgoriaService.ApagarCategoria(categoriaDTO.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
