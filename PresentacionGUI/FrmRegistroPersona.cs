using BLL;
using Entity;
using System;
using System.Windows.Forms;

namespace PresentacionGUI
{
    public partial class FrmRegistroPersona : Form
    {
        private PersonaService servicePersona;
        public FrmRegistroPersona()
        {
            InitializeComponent();
            servicePersona = new PersonaService();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = Guardar();
            MessageBox.Show(mensaje, "Información al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private bool ValidarTextosVacios()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox && x.Name != "TxtPulsacion")
                {
                    if (String.IsNullOrEmpty(((TextBox)x).Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private bool LimpiarTexto()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text= "";
                }
            }
            return true;
        }
        private string Guardar()
        {
            if (ValidarTextosVacios())
            {
                Persona persona = MapearTextoAPersona();
                string mensaje = servicePersona.Guardar(persona);
                return mensaje;
            }
            else
            {
                return "Los datos suministrados están incompletos";
            }
        }

        private Persona MapearTextoAPersona()
        {
            Persona persona = new Persona();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = int.Parse(TxtEdad.Text);
            persona.Sexo = MapearComboASexo(CmbSexo.Text);
            persona.CalcularPulsacion();
            TxtPulsacion.Text = persona.Pulsacion.ToString();
            return persona;
        }

        private string MapearComboASexo(string sexo)
        {
            if (sexo.Equals("Femenino"))
            {
                return "F";
            }
            else
            {
                return "M";
            }
        }
    }
}
