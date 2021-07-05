using PruebaMicroservice.CRUD.Data;
using PruebaMicroservice.CRUD.Models;

namespace PruebaMicroservice.test
{
    public class DummyData
    {
        public DummyData()
        {
        }

        public void Seed(pruebaMicroserviceContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.CargaBipRetails.Add(
                new CargaBipRetail()
                {
                    Codigo = 102
                ,
                    Entidad = "UNIMARC"
                ,
                    NombreFantasia = "UNIMARC JUAN ANTONIO RIOS"
                ,
                    Direccion = "SALOMON SACK 351"
                ,
                    Comuna = "INDEPENDENCIA"
                ,
                    HorarioReferencial = "Lun-Dom 09:00 a 20:00"
                ,
                    Este = 344653
                ,
                    Norte = 6300937
                ,
                    Longitud = -70.67080616666668
                ,
                    Latitud = -33.419566666666654
                }
            );

            context.SaveChanges();
        }
    }
}
