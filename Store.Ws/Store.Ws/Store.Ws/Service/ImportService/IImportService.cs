using System.Collections.Generic;

namespace StoreWS.Service
{
    public interface IImportService
    {
        void Example();

        List<Store.Data.Compras> ListaItens(List<Store.Data.Compras> Itens);

        List<Store.Data.Compras> AllListaItens();
    }
}
