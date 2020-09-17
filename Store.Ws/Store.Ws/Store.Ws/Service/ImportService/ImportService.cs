using System.Collections.Generic;
using Store.Data;
using StoreWS.UnitOfWork;

namespace StoreWS.Service
{
    public class ImportService : IImportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Compras> AllListaItens()
        {
            var ListItens = new ListCompras();

            List<Compras> ListDeCompras = new List<Compras>();

            foreach (Compras item in ListItens.ListCompra)
            {
                    var Compras = new Compras();

                    Compras.ClientId = item.ClientId;
                    Compras.ProdutoId = item.ProdutoId;
                    Compras.QuantityId = item.QuantityId;

                    ListDeCompras.Add(Compras);
            }

            return ListDeCompras;
        }

        public void Example()
        {

        }

        public List<Compras> ListaItens(List<Compras> Itens)
        {
            var ListItens = new ListCompras();

            ListItens.ListCompra = new List<Compras>();

            foreach (Compras item in Itens)
            {
                if (Itens != null)
                {
                    var Compras = new Compras();

                    Compras.ClientId = item.ClientId;
                    Compras.ProdutoId = item.ProdutoId;
                    Compras.QuantityId = item.QuantityId;

                    ListItens.ListCompra.Add(Compras);
                }
            }

            return Itens;
        }
    }
}