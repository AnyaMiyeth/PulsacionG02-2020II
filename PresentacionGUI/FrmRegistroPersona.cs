using BLL;
using Entity;
using System;
using System.Windows.Forms;

namespace PresentacionGUI
{
    public partial class FrmRegistroPersona : Form
    {
        private readonly PersonaService servicePersona;
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
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTexto();
        }
        private bool LimpiarTexto()
        {
            foreach (Control itemControl in this.Controls)
            {
                if (itemControl is TextBox || itemControl is ComboBox)
                {
                    itemControl.Text= "";
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

        private string Buscar(string identificacion)
        {
            
            if (!String.IsNullOrEmpty(identificacion))
            {
                var response = servicePersona.BuscarPorIdentificacion(identificacion);
                if (!response.Encontrado)
                {
                    return response.Message;
                }
                else
                {
                    MapearPersonaATexto(response.Persona);
                    return "Persona Encontrada";
                }
                
            }
            else
            {
                return "Digite una Identificación Válida";
            }
        }
        private Persona MapearTextoAPersona()
        {
            var persona = new Persona();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = int.Parse(TxtEdad.Text);
            persona.Sexo = MapearComboASexo(CmbSexo.Text);
            persona.CalcularPulsacion();
            TxtPulsacion.Text = persona.Pulsacion.ToString();
            return persona;
        }

        private void MapearPersonaATexto(Persona persona)
        {
            TxtIdentificacion.Text=persona.Identificacion;
            TxtNombre.Text=persona.Nombre;
            TxtEdad.Text=persona.Edad.ToString();
            CmbSexo.Text=persona.Sexo;
            TxtPulsacion.Text = persona.Pulsacion.ToString();
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

        
        private bool ValidarTextosVacios()
        {
            foreach (Control itemControl in this.Controls)
            {
                if (itemControl is TextBox && itemControl.Name != "TxtPulsacion")
                {
                    if (String.IsNullOrEmpty(((TextBox)itemControl).Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
           string mensaje= Buscar(TxtIdentificacion.Text);
            MessageBox.Show(mensaje, "Información al Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
