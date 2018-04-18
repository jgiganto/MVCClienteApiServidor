using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVCClienteApiServidor.Models
{
    public class ModeloDepartamentos
    {
        private string UrlApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        
        public ModeloDepartamentos()
        {
            this.UrlApi = "http://webapidepartamentoscompletojgd.azurewebsites.net/";
            this.mediaheader = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Departamento>> GetDepartamentos()
        {
            using(HttpClient cliente = new HttpClient())
            {
                String peticion = "api/departamentos";
                cliente.BaseAddress = new Uri(this.UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta =
                    await cliente.GetAsync(peticion);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Departamento> departamentos = await respuesta.Content.ReadAsAsync<List<Departamento>>();
                    return departamentos;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Departamento> BuscarDepartamento(int deptno)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Departamentos/" + deptno;
                cliente.BaseAddress = new Uri(this.UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta =
                    await cliente.GetAsync(peticion);
                if (respuesta.IsSuccessStatusCode)
                {
                    Departamento dept =
                        await respuesta.Content.ReadAsAsync<Departamento>();
                    return dept;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task InsertarDepartamento(int num,string nom,string loc)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Departamentos";
                cliente.BaseAddress = new Uri(this.UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(mediaheader);
                Departamento dept = new Departamento
                { Numero = num, Nombre = nom, Localidad = loc };
                await cliente.PostAsJsonAsync(peticion, dept);
            }

        }
        public async Task
            ModificarDepartamento(int num, String nom, String loc)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Departamentos/" + num;
                cliente.BaseAddress = new Uri(this.UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(mediaheader);
                Departamento dept = new Departamento
                { Numero = num, Nombre = nom, Localidad = loc };
                await cliente.PutAsJsonAsync(peticion, dept);
            }
        }

        public async Task EliminarDepartamento(int deptno)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Departamentos/" + deptno;
                cliente.BaseAddress = new Uri(this.UrlApi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(mediaheader);
                await cliente.DeleteAsync(peticion);
            }
        }



    }

}