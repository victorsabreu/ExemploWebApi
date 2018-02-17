using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public Cliente()
        {
        }

        public Cliente(int id, string nome, string sobrenome)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public List<Cliente> ListaClientes()
        {
            var path = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(path);
            var lista = JsonConvert.DeserializeObject<List<Cliente>>(json);
            
            return lista;
        }

        public bool Adicionar(List<Cliente> listaClientes)
        {
            var path = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaClientes, Formatting.Indented);

            File.WriteAllText(path, json);

            return true;
        }
        public Cliente Inserir(Cliente cliente)
        {
            var lista = this.ListaClientes();

            var maxId = lista.Max(_cliente => _cliente.Id);

            cliente.Id = maxId +1;

            lista.Add(cliente);

            Adicionar(lista);

            return cliente;
        }
        public Cliente Atualizar(int id, Cliente cliente)
        {
            var lista = this.ListaClientes();

            var index = lista.FindIndex(p => p.Id == id);
            if (index >= 0)
            {
                cliente.Id = id;
                lista[index] = cliente;
            }
            else
            {
                return null;
            }

            Adicionar(lista);
            return cliente;
        }
        public bool Remover(int id)
        {
            var lista = this.ListaClientes();

            var index = lista.FindIndex(p => p.Id == id);
            if (index >= 0)
            {
                lista.RemoveAt(index);
            }
            else
            {
                return false;
            }

            Adicionar(lista);
            return true;
        }
    }
}