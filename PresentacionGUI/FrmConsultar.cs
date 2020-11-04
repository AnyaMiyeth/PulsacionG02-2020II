using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace PresentacionGUI
{
    public partial class FrmConsultar : Form
    {
        private readonly PersonaService personaService;
        public FrmConsultar()
        {
            InitializeComponent();
            personaService = new PersonaService();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            var response = personaService.ConsultarTodos();
            if (response.Encontrado)
            {
                ConfigurarGrid();

                DtgPersona.Columns[0].Name = "Identificacion";
                DtgPersona.Columns[1].Name = "Nombre";
                DtgPersona.Columns[2].Name = "Pulsaciones";
                DtgPersona.Columns[3].Name = "Edad";
                DtgPersona.Columns[4].Name = "Sexo";
                foreach (var item in response.Personas)
                {
                    DtgPersona.Rows.Add(item.Identificacion, item.Nombre, item.Pulsacion, item.Edad, item.Sexo);
                }
            }
            else
            {
                MessageBox.Show(response.Message, "Información al Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfigurarGrid()
        {
            // Create an unbound DataGridView by declaring a column count.
            DtgPersona.ColumnCount = 4;
            DtgPersona.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            DtgPersona.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {

        }

        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {
            if (CmbFiltroSexo.Text.Equals("Todos"))
            {
                ConsultarTodos();
            }
            else
            {
                ConsultaConFiltroSexo();
            }

        }

        private void ConsultarTodos()
        {
            var respuesta = personaService.ConsultarTodos();
            if (respuesta.Encontrado)
            {
                DtgPersona.DataSource = respuesta.Personas;
            }
            else
            {
                MessageBox.Show(respuesta.Message, "Informacion de Consulta");
            }
        }

       

        private void ConsultaConFiltroSexo()
        {

            var response = personaService.ConsultarPorSexo(CmbFiltroSexo.Text);
            if (response.Encontrado)
            {
                   
                DtgPersona.DataSource = response.Personas;

            }
            else
            {
                MessageBox.Show(response.Message, "Informacion Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
