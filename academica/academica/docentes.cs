using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace academica
{
    public partial class docentes : Form
    {
        Conexion objConexion = new Conexion();
        DataSet ds = new DataSet();
        DataTable miTabla = new DataTable();

        public int posicion = 0;
        String accion = "nuevo";

        public docentes()
        {
            InitializeComponent();
        }

        private void docentes_Load(object sender, EventArgs e)
        {
            actualizarDs();
        }
        private void actualizarDs()
        {
            ds.Clear();
            ds = objConexion.obtenerDatos();
            miTabla = ds.Tables["docentes"];
            miTabla.PrimaryKey = new DataColumn[] { miTabla.Columns["IdDocentes"] };
            grdDatosDocente.DataSource = miTabla;
            mostrarDatosDocentes();
        }
        private void mostrarDatosDocentes()
        {
            if (miTabla.Rows.Count > 0)
            {
                txtCodigoDocente.Text = miTabla.Rows[posicion].ItemArray[1].ToString();
                txtNombreDocente.Text = miTabla.Rows[posicion].ItemArray[2].ToString();
                txtDireccionDocente.Text = miTabla.Rows[posicion].ItemArray[3].ToString();
                txtTelefonoDocente.Text = miTabla.Rows[posicion].ItemArray[4].ToString();
                txtDuiDocente.Text = miTabla.Rows[posicion].ItemArray[5].ToString();
                txtEmailDocente.Text = miTabla.Rows[posicion].ItemArray[6].ToString();
                cboxEspecialidadDocente.SelectedItem = miTabla.Rows[posicion].ItemArray[7].ToString();

                lblRegistrosDocentes.Text = (posicion + 1) + " de " + miTabla.Rows.Count;


            }
        }

        private void btnSiguienteDocente_Click(object sender, EventArgs e)
        {
            if (posicion < miTabla.Rows.Count - 1)
            {
                posicion++;
                mostrarDatosDocentes();
            }
            else
            {
                MessageBox.Show("Esta en el ultimo registro", "Navegacion de alumnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnteriorDocente_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatosDocentes();
            }
            else
            {
                MessageBox.Show("Esta en el primer registro", "Navegacion de alumnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUltimoDocente_Click(object sender, EventArgs e)
        {
            posicion = miTabla.Rows.Count - 1;
            mostrarDatosDocentes();
        }

        private void btnPrimeroDocente_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatosDocentes();
        }
        private void estadoControles(Boolean estado)
        {
            grbDatosDocente.Enabled = estado;
            grbNavegacionDocente.Enabled = !estado;
            btnEliminarDocente.Enabled = !estado;
        }

        private void btnNuevoDocente_Click(object sender, EventArgs e)
        {
            if (btnNuevoDocente.Text == "Nuevo")
            {
                btnNuevoDocente.Text = "Guardar";
                btnModificarDocente.Text = "Cancelar";
                accion = "nuevo";
                estadoControles(true);
                limpiarCajas();
            }
            else
            {//Guardar
                String[] docentes = {
                    accion, miTabla.Rows[posicion].ItemArray[0].ToString(),
                    txtCodigoDocente.Text, txtNombreDocente.Text, txtDireccionDocente.Text, txtTelefonoDocente.Text, txtDuiDocente.Text, txtEmailDocente.Text, cboxEspecialidadDocente.SelectedItem.ToString()
                };
                String respuesta = objConexion.administrarDocentes(docentes);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error en el registro de alumnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnNuevoDocente.Text = "Nuevo";
                    btnModificarDocente.Text = "Modificar";
                    estadoControles(false);
                    actualizarDs();
                }
            }
        }
        void limpiarCajas()
        {
            txtCodigoDocente.Text = "";
            txtNombreDocente.Text = "";
            txtDireccionDocente.Text = "";
            txtTelefonoDocente.Text = "";
            txtDuiDocente.Text = "";
            txtEmailDocente.Text = "";
            cboxEspecialidadDocente.SelectedItem = "";
        }

        private void btnModificarDocente_Click(object sender, EventArgs e)
        {
            if (btnModificarDocente.Text == "Modificar")
            {
                btnNuevoDocente.Text = "Guardar";
                btnModificarDocente.Text = "Cancelar";
                accion = "modificar";
                estadoControles(true);

            }
            else
            {//Cancelar
                mostrarDatosDocentes();
                btnNuevoDocente.Text = "Nuevo";
                btnModificarDocente.Text = "Modificar";
                estadoControles(false);
            }
        }

        private void btnEliminarDocente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar a " + txtNombreDocente.Text.Trim() + "?", "Eliminar Docentes", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String[] docentes = {
                    "eliminar", miTabla.Rows[posicion].ItemArray[0].ToString()
                };
                String respuesta = objConexion.administrarAlumnos(docentes);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error en el registro de docentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDs();
                    mostrarDatosDocentes();
                }
            }
        }
        private void filtrarDatos(String filtro)
        {
            DataView dv = miTabla.DefaultView;
            dv.RowFilter = "codigo like '%" + filtro + "%' OR nombre like '%" + filtro + "%'";
            grdDatosDocente.DataSource = dv;
        }

        private void txtBuscarDocente_TextChanged(object sender, EventArgs e)
        {
            filtrarDatos(txtBuscarDocente.Text);
            //if (e.KeyValue == 13) {//tecla enter
            seleccionarADocente();
        }
        private void seleccionarADocente()
        {
            posicion = miTabla.Rows.IndexOf(miTabla.Rows.Find(grdDatosDocente.CurrentRow.Cells["idDocentes"].Value.ToString()));
            mostrarDatosDocentes();
        }
        private void grdDatosDocente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarADocente();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Form1 objForm = new Form1();
            this.Close();
        }
    }
}
