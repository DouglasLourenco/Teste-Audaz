using Store.Web.Models;
using Store.Web.StoreWS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult import(HttpPostedFileBase file)
        {
            var client = new ServiceSoapClient();
            client.Example();

            return View();
        }

        [HttpPost]
        public ActionResult Import(upload arq)
        {
            string nomeArquivo = "";

            try
            {
                if (arq.Arquivo.ContentLength > 0)
                {
                    nomeArquivo = arq.Arquivo.FileName;
                    var caminho = Path.Combine(Server.MapPath("~/Documentos"), nomeArquivo);
                    arq.Arquivo.SaveAs(caminho);
                }

                ViewBag.Mensagem = "Arquivo : " + nomeArquivo + " ,enviado com sucesso.";
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro : " + ex.Message;
            }

            List<Data.Compras> ListDeCompras = new List<Data.Compras>();

            Compras[] Itens = new Compras[30];

            var Produto = new ServiceSoapClient();

            int count = 0;
            int count2 = 0;

            using (StreamReader reader = new StreamReader(Server.MapPath("~/Documentos/") + nomeArquivo))
            {
                while (!reader.EndOfStream)
                {
                    var ComprasItens = new Data.Compras();

                    string linha = reader.ReadLine();

                    string[] str_Array = linha.Split(';');

                    if (count > 0)
                    {
                        if (linha.Length > 0)
                        {
                            ComprasItens.ClientId = str_Array.GetValue(0).ToString();
                            ComprasItens.ProdutoId = str_Array.GetValue(1).ToString();
                            ComprasItens.QuantityId = str_Array.GetValue(2).ToString();

                            Itens[count2] = new Compras();

                            Itens[count2].ClientId = ComprasItens.ClientId;
                            Itens[count2].ProdutoId = ComprasItens.ProdutoId;
                            Itens[count2].QuantityId = ComprasItens.QuantityId;

                            count2 += 1;
                        }
                    }
                    count += 1;   
                }

                Produto.ImportarListaItens(Itens);
            }
            

            return View();
        }
    }
}