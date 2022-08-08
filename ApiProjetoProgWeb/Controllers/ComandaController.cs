using ApiProjetoProgWeb.DAO;
using ApiProjetoProgWeb.Model;
using ApiProjetoProgWeb.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoProgWeb.Controllers
{
    [ApiController]
    [Route("comandas")]
    public class ComandaController : ControllerBase
    {
        private ComandaDAO _comandaDAO;

        public ComandaController(ComandaDAO comandaDAO)
        {
            _comandaDAO = comandaDAO;
        }

        [HttpGet(Name = "GetComandas")]
        public IActionResult GetComandas()
        {
            try
            {
                return Ok(_comandaDAO.buscar().Select(comanda => new
                {
                    idUsuario = comanda.id,
                    nomeUsuario = comanda.nomeUsuario,
                    telefoneUsuario = comanda.telefoneUsuario,
                    comandaProdutos = comanda.comandaProdutos.Select(item => new
                    {
                        id = item.id,
                        idProduto = item.idProduto,
                        quantidade = item.quantidade,
                        produto = new
                        {
                            nome = item.produto.nome,
                            preco = item.produto.preco,
                        }
                    }).ToList()
                }).ToList());
            }
            catch (Exception ex)
            {
                return Problem(title: "Ocorreu um erro ao buscar as comandas", detail: ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetComanda")]
        public IActionResult GetComanda(int id)
        {
            try
            {
                var comanda = _comandaDAO.buscarPorId(id);

                if (comanda != null)
                    return Ok(new
                    {
                        idUsuario = comanda.id,
                        nomeUsuario = comanda.nomeUsuario,
                        telefoneUsuario = comanda.telefoneUsuario,
                        comandaProdutos = comanda.comandaProdutos.Select(item => new
                        {
                            id = item.id,
                            idProduto = item.idProduto,
                            quantidade = item.quantidade,
                            produto = new
                            {
                                nome = item.produto.nome,
                                preco = item.produto.preco,
                            }
                        }).ToList()
                    });
                else
                    return NotFound("Comanda não encontrada");
            }
            catch (Exception ex)
            {
                return Problem(title: "Ocorreu um erro ao buscar a comanda", detail: ex.Message);
            }
        }

        [HttpPost("PostComanda")]
        public IActionResult PostComanda(ComandaDTO comanda)
        {
            try
            {
                _comandaDAO.adicionar(comanda);
                return Ok(comanda);
            }
            catch (Exception ex)
            {
                return Problem(title: "Ocorreu um erro ao criar a comanda", detail: ex.Message);
            }
        }

        [HttpPut("{id}", Name = "PutComanda")]
        public IActionResult PutComanda(int id, ComandaDTO comanda)
        {
            try
            {
                _comandaDAO.alterar(id, comanda);
                return Ok(comanda);
            }
            catch (Exception ex)
            {
                return Problem(title: "Ocorreu um erro ao alterar a comanda", detail: ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteComanda")]
        public IActionResult DeleteComanda(int id)
        {
            try
            {
                _comandaDAO.deletar(id);
                return Ok("Comanda removida");
            }
            catch (Exception ex)
            {
                return Problem(title: "Ocorreu um erro ao deletar a comanda", detail: ex.Message);
            }
        }

        [HttpDelete("autorizado/{id}", Name = "DeleteComandaAutorizado")]
        [Authorize]
        public IActionResult DeleteComandaAutorizado(int id)
        {
            try
            {
                _comandaDAO.deletar(id);
                return Ok("Comanda removida");
            }
            catch (Exception ex)
            {
                return Problem(title: "Ocorreu um erro ao deletar a comanda", detail: ex.Message);
            }
        }
    }
}
