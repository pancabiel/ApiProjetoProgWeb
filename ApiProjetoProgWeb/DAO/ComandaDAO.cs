using ApiProjetoProgWeb.Database;
using ApiProjetoProgWeb.Model;
using ApiProjetoProgWeb.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoProgWeb.DAO
{
    public class ComandaDAO
    {
        private AppContextDb _context;

        public ComandaDAO(AppContextDb context)
        {
            _context = context;
        }

        public List<Comanda> buscar()
        {
            return _context.Comandas
                .Include(c => c.comandaProdutos)
                .ThenInclude(cp => cp.produto)
                .ToList();
        }

        public Comanda buscarPorId(int id)
        {
            return _context.Comandas
                .Include(c => c.comandaProdutos)
                .ThenInclude(cp => cp.produto)
                .FirstOrDefault(x => x.id == id);
        }

        public void adicionar(ComandaDTO comandaDTO)
        {
            Comanda comanda = popularComandaDTOParaComanda(comandaDTO);
            _context.Add(comanda);
            _context.SaveChanges();
        }
        internal void alterar(int id, ComandaDTO comandaDTO)
        {
            Comanda comanda = alterarDadosEnviados(id, comandaDTO);
            _context.Update(comanda);
            _context.SaveChanges();
        }

        private Comanda popularComandaDTOParaComanda(ComandaDTO comandaDTO)
        {
            var comanda = new Comanda
            {
                id = comandaDTO.id.Value,
                nomeUsuario = comandaDTO.nomeUsuario,
                telefoneUsuario = comandaDTO.telefoneUsuario,
                comandaProdutos = new List<ComandaProduto>()
            };

            foreach (var item in comandaDTO.comandaProdutos)
            {
                Produto produto = _context.Produtos.FirstOrDefault(x => x.id == item.idProduto);
                comanda.comandaProdutos.Add(new ComandaProduto
                {
                    id = item.id,
                    idComanda = comanda.id,
                    idProduto = item.idProduto,
                    quantidade = item.quantidade,
                    produto = produto
                });
            }

            return comanda;
        }

        private Comanda alterarDadosEnviados(int id, ComandaDTO comandaDTO)
        {
            var comanda = _context.Comandas.Include(x => x.comandaProdutos).ThenInclude(x => x.produto).FirstOrDefault(x => x.id == id);

            if (comandaDTO.telefoneUsuario != null && comandaDTO.telefoneUsuario.Any())
            {
                comanda.telefoneUsuario = comandaDTO.telefoneUsuario;
            }

            if (comandaDTO.nomeUsuario != null && comandaDTO.nomeUsuario.Any())
            {
                comanda.nomeUsuario = comandaDTO.nomeUsuario;
            }

            if (comandaDTO.comandaProdutos != null && comandaDTO.comandaProdutos.Any())
            {
                foreach (var item in comandaDTO.comandaProdutos)
                {
                    var comandaProduto = comanda.comandaProdutos.FirstOrDefault(x => x.id == item.id || x.idProduto == item.idProduto);
                    if (comandaProduto != null)
                        comandaProduto.quantidade = item.quantidade;
                    else
                    {
                        comanda.comandaProdutos.Add(new ComandaProduto
                        {
                            idProduto = item.idProduto,
                            quantidade = item.quantidade
                        });
                    }
                        
                }
            }

            return comanda;
        }

        public void deletar(int id)
        {
            var comanda = _context.Comandas.FirstOrDefault(x => x.id == id);
            _context.Remove(comanda);
            _context.SaveChanges();
        }
    }
}
