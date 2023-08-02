using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BDCrudTest.Paginas
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString); //Utilizamos la conexion que establecimos en el archivo Web.config
        public static string sID = "-1"; //Esto es para evitar el error de una variable no asignada al momento de hacer una consulta
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Vamos a obtener el ID
            if(!Page.IsPostBack) //En esta condicion hacemos que los datos no se re carguen, de esta manera podemos evitar algunos errores luego de ejecutar otro evento.
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C": //En este caso el usuario esta buscando CREAR, como lo definimos en el archivo index.aspx
                            this.lbltitulo.Text = "Ingresar nueva categoría";
                            this.BtnCreate.Visible = true; //De esta manera habilitamos el boton de crear
                            break;
                         case "R": //En este caso el usuario esta buscando Leer, como lo definimos en el archivo index.aspx
                            this.lbltitulo.Text = "Consultar una categoría";
                            break;
                         case "U"://En este caso el usuario esta buscando Actualizar, como lo definimos en el archivo index.aspx
                            this.lbltitulo.Text = "Editar una categoría";
                            this.BtnUpdate.Visible = true; //De esta manera habilitamos el boton de Actualizar
                            break;
                        case "D"://En este caso el usuario esta buscando Eliminar, como lo definimos en el archivo index.aspx
                            this.lbltitulo.Text = "Eliminar una categoría";
                            this.BtnDelete.Visible = true; //De esta manera habilitamos el boton de Actualizar
                            break;

                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Usp_Select_Categori_ID", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nIdCategori", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbIDCategori.Text = row[0].ToString();
            tbnombre.Text = row[1].ToString();
            int activa = row[2].GetHashCode();
            if(activa == 1)
            {
                DropDownActiva.SelectedIndex = 1;
            }else if(activa == 0)
            {
                DropDownActiva.SelectedIndex = 0;
            }
            con.Close();
        }
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Usp_Ins_Co_Categoria", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nIdCategori", SqlDbType.Int).Value = tbIDCategori.Text;
            cmd.Parameters.Add("@cNombCateg", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@cEsActiva", SqlDbType.Bit).Value = DropDownActiva.SelectedIndex;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Usp_UPDATE_Co_Categoria", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nIdCategori", SqlDbType.Int).Value = tbIDCategori.Text;
            cmd.Parameters.Add("@cNombCateg", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@cEsActiva", SqlDbType.Bit).Value = DropDownActiva.SelectedIndex;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Usp_Delete_Co_Categoria", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nIdCategori", SqlDbType.VarChar).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}