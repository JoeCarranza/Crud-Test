using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;

namespace BDCrudTest.Paginas
{
    public partial class index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString); //Utilizamos la conexion que establecimos en el archivo Web.config
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        void CargarProductos()
        {
            //Este evento servira para que cuando entremos al index se carguen todos los productos que se encuentra en la BD, este evento lo llamaremos en el Page_Load
            SqlCommand cmd = new SqlCommand("Usp_Sel_Co_Categoria", con); //De esta manera llamamos al procedimiento almacenado que nos muestra todas las categorías
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlCommand cmd2 = new SqlCommand("Usp_Sel_Co_Productos", con); //De esta manera llamamos al procedimiento almacenado que nos muestra todos los productos
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open(); //Abrimos la conexion
            //Para la tabla de categorías
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            coCategori.DataSource = dt;
            coCategori.DataBind();

            //Para la tabla de productos
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            TablaProductos.DataSource = dt2;
            TablaProductos.DataBind();
            con.Close(); //Cerramos la conexion
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/CRUD.aspx?op=C"); //Aqui especificamos de donde se van a enviar los datos y por que motivo viene el usuario en este caso a insertar datos
        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsulta = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsulta.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/CRUD.aspx?id=" + id+"&op=R"); //En este caso indicamos que es una lectura, por eso se cambio la C que es de "Create" por una R de "Read"
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsulta = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsulta.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/CRUD.aspx?id=" + id + "&op=U"); //En este caso indicamos que es un actualizar, por eso se cambio la C que es de "Create" por una U de "Update"
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsulta = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsulta.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/CRUD.aspx?id=" + id + "&op=D"); //En este caso indicamos que es un eliminar, por eso se cambio la C que es de "Create" por una D de "Delete"
        }

        protected void btn_MostrarProductoId_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Usp_Sel_Co_Productos_Categori", con); //De esta manera llamamos al procedimiento almacenado que nos muestra todos los productos
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open(); //Abrimos la conexion
            //Para la tabla de categorías
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            TablaProductos.DataSource = dt;
            TablaProductos.DataBind();
            con.Close(); //Cerramos la conexion
        }

        protected void btn_MostrarProductoId2_Click(object sender, EventArgs e)
        {

        }

        protected void btnVerProduct_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsulta = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsulta.NamingContainer;
            id = selectedrow.Cells[1].Text;
           
            con.Open(); //Abrimos la conexion

            //Para la tabla de productos
            SqlDataAdapter da = new SqlDataAdapter("Usp_Sel_Co_Productos_Categori", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nIdCategori", SqlDbType.Int).Value = id;
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            TablaProductos.DataSource = dt2;
            TablaProductos.DataBind();
            con.Close();

        }
    }
}