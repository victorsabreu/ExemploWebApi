using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<Cliente> Get()
        {
            Cliente clientes = new Cliente();
            return clientes.ListaClientes();
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {
            Cliente clientes = new Cliente();

            return clientes.ListaClientes().Where(p => p.Id == id).FirstOrDefault();
        }

        // POST: api/Cliente
        public List<Cliente> Post([FromBody]Cliente cliente)
        {
            Cliente clientes = new Cliente();
            clientes.Inserir(cliente);
            return clientes.ListaClientes();
        }

        // PUT: api/Cliente/5
        public List<Cliente> Put(int id, [FromBody]Cliente cliente)
        {
            Cliente clientes = new Cliente();
            clientes.Atualizar(id, cliente);
            return clientes.ListaClientes();
        }

        // DELETE: api/Cliente/5
        public List<Cliente> Delete(int id)
        {
            Cliente clientes = new Cliente();
            clientes.Remover(id);
            return clientes.ListaClientes();
        }
    }
}
