using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WServicioAutos.Model;

namespace WServicioAutos
{
    /// <summary>
    /// Descripción breve de WebServiceAutos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceAutos : System.Web.Services.WebService
    {

        [WebMethod(Description ="Consultar los autos de la base de datos")]
        public List<Autos> ObtenerAutos()
        {
            using (var conexion = new CasoPrac3Entities())
            {
                var consulta = from c in conexion.Autos select c;
                return consulta.ToList();   
                
            }
                
        }


        [WebMethod(Description = "Insertar datos a la bd")]
        public bool InsertarAuto(string _marca, string _modelo, string _anio_fabricacion, decimal _precio, string _color)
        {

            try
            {
                using (var conexion = new CasoPrac3Entities())
                {
                    Autos nuevo = new Autos();
                    nuevo.ID_Auto = Guid.NewGuid();
                    nuevo.Marca = _marca;
                    nuevo.Modelo = _modelo;
                    nuevo.anio_Fabricacion = _anio_fabricacion;
                    nuevo.Precio = _precio;
                    nuevo.Color = _color;

                    conexion.Autos.Add(nuevo);
                    conexion.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        [WebMethod(Description = "Modificar datos de Autos")]
        public bool Modificar(string _id, string _marcaM, string _modeloM, string _anio_fabricacionM, decimal _precioM)
        {

            try
            {
                using (var conexion = new CasoPrac3Entities())
                {
                    Guid idCar = Guid.Parse(_id);
                    var consulta = (from c in conexion.Autos
                                    where c.ID_Auto == idCar
                                    select c).FirstOrDefault();
                    if (consulta != null)
                    {
                        consulta.Marca = _marcaM;
                        consulta.Modelo = _modeloM;
                        consulta.anio_Fabricacion = _anio_fabricacionM;
                        consulta.Precio = _precioM;
                        conexion.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }



        }

        [WebMethod(Description = "Eliminar datos a la bd")]
        public bool EliminarAuto(string _id)
        {

            try
            {
                using (var conexion = new CasoPrac3Entities())
                {
                    Guid idAuto = Guid.Parse(_id);
                    var consulta = (from c in conexion.Autos
                                    where c.ID_Auto
                                   == idAuto
                                    select c).FirstOrDefault();

                    if (consulta != null)
                    {
                        conexion.Autos.Remove(consulta);
                        conexion.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        [WebMethod(Description = "Consultar por modelo de auto")]
        public string  ObtenerMarca(string _marca)
        {

              using (var conexion = new CasoPrac3Entities())
                {
                   
                    var consulta = (from c in conexion.Autos
                                    where c.Marca == _marca                  
                                    select c.Marca).FirstOrDefault();

                    return consulta;
                }

        }
    }
}
