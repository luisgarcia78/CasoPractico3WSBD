using Formprin.ServiceReferenceAutos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WServicioAutos.Model;
using Autos = WServicioAutos.Model.Autos;

namespace Formprin
{
    public partial class FormularioAgregar : Form
    {
        public FormularioAgregar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            using (var conexion = new CasoPrac3Entities())
            {
                Autos nuevo = new Autos();

                nuevo.Marca = txtMarca.Text;
                nuevo.Modelo = txtModelo.Text;
                nuevo.anio_Fabricacion = txtAniofab.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                conexion.Autos.Add(nuevo);
                conexion.SaveChanges();
                this.Close();
              
                
            }

            

          
          


        }
    }
}
