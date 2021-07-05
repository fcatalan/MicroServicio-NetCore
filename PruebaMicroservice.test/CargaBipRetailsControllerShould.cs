using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_microservice.Controllers;
using PruebaMicroservice.CRUD.Data;
using PruebaMicroservice.CRUD.Interface;
using PruebaMicroservice.CRUD.Models;
using PruebaMicroservice.CRUD.Repository;
using Xunit;

namespace PruebaMicroservice.test
{
    public class CargaBipRetailsControllerShould
    {

        public CargaBipRetailsController cargaBipReatilController;
        public IRepository<CargaBipRetail> _reposytory;

        public static DbContextOptions<pruebaMicroserviceContext> dbContextOptions { get; set; }
        public static string connectionString = "Server=localhost, 1433;Database=pruebaMicroservice;User=sa;Password=PasswordPrueba|1;";

        public CargaBipRetailsControllerShould()
        {
            dbContextOptions = new DbContextOptionsBuilder<pruebaMicroserviceContext>()
                            .UseSqlServer(connectionString)
                            .Options;

            var context = new pruebaMicroserviceContext(dbContextOptions);
            DummyData db = new DummyData();
            db.Seed(context);

            _reposytory = new RopositoryCargaBipRetail(context);

            cargaBipReatilController = new CargaBipRetailsController(_reposytory);
        }

        [Fact]
        public void ValidateActionResultGetCargaBipRetailByIdReturn()
        {

            var cargaRetail = cargaBipReatilController.GetCargaBipRetailById(1);

            Assert.IsType<ActionResult<CargaBipRetail>>(cargaRetail.Result);
        }

        [Fact]
        public void ValidateNotNullGetCargaBipRetailById()
        {

            var cargaRetail = cargaBipReatilController.GetCargaBipRetailById(1);

            Assert.NotNull(cargaRetail.Result);
        }


        [Theory]
        [InlineData(1, "204")]
        public void ValidatePutCargaBipRetail(int id, string expected)
        {
            var carga = _reposytory.GetById(id);

            carga.Result.Codigo = 103;

            var cargaRetail = cargaBipReatilController.PutCargaBipRetail(1, carga.Result);

            NoContentResult result = (NoContentResult)cargaRetail.Result;


            Assert.Equal(expected, result.StatusCode.ToString());
        }

        [Fact]
        public void ValidatePostCargaBipRetail()
        {
            var carga = new CargaBipRetail()
            {
                Codigo = 103
                , Entidad = "UNIMARC"
                , NombreFantasia = "UNIMARC JUAN ANTONIO RIOS 2"
                , Direccion = "SALOMON SACK 351"
                , Comuna = "INDEPENDENCIA"
                , HorarioReferencial = "Lun-Dom 09:00 a 20:00"
                , Este = 344653
                , Norte = 6300937
                , Longitud = -70.67080616666668
                , Latitud = -33.419566666666654
            };

            var resp = cargaBipReatilController.PostCargaBipRetail(carga);

            Assert.NotNull(resp.Result);
        }

        [Theory]
        [InlineData(1, "204")]
        public void DeleteCargaBipRetail(int id, string expected)
        {
            var cargaRetail = cargaBipReatilController.DeleteCargaBipRetail(id);

            NoContentResult result = (NoContentResult)cargaRetail.Result;

            Assert.Equal(expected, result.StatusCode.ToString());
        }
    }
}
