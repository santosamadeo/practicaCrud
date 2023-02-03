using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using practicaCrud1.Clases;

namespace practicaCrud1
{
    public partial class estudiantecontrolpersonalizado : UserControl
    {
        Estudiantes es= new Estudiantes();
        Transacciones t = new Transacciones();

        public estudiantecontrolpersonalizado()
        {
            InitializeComponent();
            cargar();
        }

        private void cargar()
        {
            this.dgvTabla.DataSource = t.consultar("Estudiante");
    }


        private void estudiantecontrolpersonalizado_Load(object sender, EventArgs e)
        {

        }
    }
    
}
