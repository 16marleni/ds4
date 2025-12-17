using System.Collections.Generic;
using System.Web.Http;
using ProyectoFinal.DAL;
using ProyectoFinal.Models;

[RoutePrefix("api/libros")]
public class LibrosApiController : ApiController
{
    LibroDAL dal = new LibroDAL();

    [HttpGet]
    [Route("")]
    public IEnumerable<Libro> Get()
    {
        return dal.Listar();
    }
}
