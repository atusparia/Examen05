using Examen05.Models;
using Examen05.Requests;
using Examen05.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen05.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public List<CategoriaResponse> Listar()
        {
            using (var context = new AppDbContext())
            {
                var categorias = context.Categorias.ToList();

                var response = categorias.Select(x => new CategoriaResponse
                {
                    CategoriaID = x.CategoriaID,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                }).ToList();

                return response;
            }
        }

        [HttpGet]
        public List<CategoriaResponse> ListarID(int Id)
        {
            using (var context = new AppDbContext())
            {
                var categorias = context.Categorias.ToList();

                var response = categorias.Where(x => x.CategoriaID == Id).Select(x => new CategoriaResponse
                {
                    CategoriaID = x.CategoriaID,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                }).ToList();

                return response;
            }
        }


        [HttpPost]
        public ResponseBase Insertar(CategoriaRequest request)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                using (var context = new AppDbContext())
                {
                    Categoria categoria = new Categoria()
                    {
                        Nombre = request.Nombre,
                        Descripcion = request.Descripcion,
                    };

                    context.Categorias.Add(categoria);
                    context.SaveChanges();

                    response.Mensaje = "Registro exitoso";
                    response.CodigoError = 0;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.ToString();
                response.CodigoError = -100;
            }
            return response;
        }
    }
}

