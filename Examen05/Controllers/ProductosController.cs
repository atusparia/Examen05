using Examen05.Models;
using Examen05.Requests;
using Examen05.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen05.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public List<ProductoResponse> Listar()
        {
            using (var context = new AppDbContext())
            {
                var productos = context.Productos.ToList();

                var response = productos.Select(x => new ProductoResponse
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                }).ToList();

                return response;
            }
        }

        [HttpGet]
        public List<ProductoResponse> ListarID(int Id)
        {
            using (var context = new AppDbContext())
            {
                var productos = context.Productos.ToList();

                var response = productos.Where(x => x.ProductoID == Id).Select(x => new ProductoResponse
                {
                    Nombre= x.Nombre,
                    Precio = x.Precio,
                    
                }).ToList();

                return response;
            }
        }


        [HttpPost]
        public ResponseBase Insertar(ProductoRequest request)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                using (var context = new AppDbContext())
                {
                    Producto producto = new Producto()
                    {
                        Nombre = request.Nombre,
                        Precio = request.Precio,
                        CategoriaID=request.CategoriaID,
                    };

                    context.Productos.Add(producto);
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
