using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formprin
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReferenceAutos.WebServiceAutosSoapClient ws = new ServiceReferenceAutos.WebServiceAutosSoapClient();

            DGTAutos.DataSource = ws.ObtenerAutos();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FormularioAgregar formHija = new FormularioAgregar();
            formHija.ShowDialog();  
            Refresh();
        }
    }
}
