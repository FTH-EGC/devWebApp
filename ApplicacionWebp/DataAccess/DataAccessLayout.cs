using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ApplicacionWebp.Models.ViewModels;
using ApplicacionWebp.Models;

namespace ApplicacionWebp.DataAccess
{
    public class DataAccessLayout
    {
        public List<ListTablaViewModel> GetData()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<ListTablaViewModel> usuList = null;
            ListTablaViewModel usuObj = null;

            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", "READ");


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                usuList = new List<ListTablaViewModel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    usuObj = new ListTablaViewModel();
                    usuObj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    usuObj.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    usuObj.Apellido_Paterno = ds.Tables[0].Rows[i]["apellido_paterno"].ToString();
                    usuObj.Apellido_Materno = ds.Tables[0].Rows[i]["apellido_materno"].ToString();
                    usuObj.Edad = ds.Tables[0].Rows[i]["edad"].ToString();
                    usuObj.isactive = Convert.ToBoolean(ds.Tables[0].Rows[i]["isactve"]);
                    usuList.Add(usuObj);
                }
                return usuList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }


        }
    }
}