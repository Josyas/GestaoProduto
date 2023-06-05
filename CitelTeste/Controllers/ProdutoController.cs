using AutoMapper;
using CitelTeste.DTO;
using CitelTeste.Model;
using CitelTeste.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CitelTeste.Controllers
{
    [ApiController]
    [Route("Produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _mapper = mapper;
            _produtoService = produtoService;
        }

        [HttpPost("Cadastrar")]
        public ActionResult CadastroProduto(ProdutoDTO produto)
        {
            try
            {
                var produtoDTO = _mapper.Map<Produto>(produto);

                _produtoService.CadastrarProduto(produtoDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListaProduto")]
        public ActionResult<List<Produto>> ListaProduto()
        {
            var listaProdutoCadastrado = _produtoService.ListaProdutroCadastrado();
                   
            return Ok(listaProdutoCadastrado);
        }


        [HttpPut("Editar")]
        public ActionResult EditarProduto(ProdutoDTO produto)
        {
            try
            {
                var produtoDTO = _mapper.Map<Produto>(produto);

                _produtoService.EditarProduto(produtoDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Apagar")]
        public ActionResult ApagarProduto(ObjetoDTO protudoDTO)
        {
            _produtoService.ApagarProduto(protudoDTO.Id);

            return Ok();
        }
    }
}
