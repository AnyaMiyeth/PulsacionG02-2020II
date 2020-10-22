using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
using System.Windows.Forms;

namespace PresentacionGUI
{
    public partial class FrmRegistroPersona : Form
    {
        public FrmRegistroPersona()
        {
            InitializeComponent();
           
        }

        private void FrmRegistroPersona_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            Persona persona = new Persona();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = int.Parse(TxtEdad.Text);
            if (CmbSexo.Text.Equals("Femenino"))
            {
                persona.Sexo = "F";
            }
            else
            {
                persona.Sexo = "M";
            }
            PersonaService service = new PersonaService();
            string mensaje=service.Guardar(persona);
            MessageBox.Show(mensaje);
        }

      
    }
}
