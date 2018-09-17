using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class Manager
    {
        SqlConnection conection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Company;User ID=CompanyClient;Password=septiembre");

        //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Company;User ID=CompanyClient;Password=septiembre");
        #region Conection
        //Open the conection
        void Open_Conection()
        {
            if (conection.State ==ConnectionState.Closed)
            {
                conection.Open();
            }
        }
        //Close the current conection
         void Close_Conection()
        {
            if (conection.State==ConnectionState.Open)
            {
                conection.Close();
            }
        }
        #endregion

        //execute stored procedure  insert/update/delete 
        public void SP_Excute ( string SPName , List<Parameters> ParametersList)
        {
            SqlCommand cmd;
            try
            {
                Open_Conection();
                cmd = new SqlCommand(SPName, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (ParametersList!=null)
                foreach (var itemParameter in ParametersList)
                {
                    if (itemParameter.Direction==ParameterDirection.Input)
                    {
                            cmd.Parameters.AddWithValue(itemParameter.Name, itemParameter.Value);
                    }

                    if (itemParameter.Direction == ParameterDirection.Output)
                    {
                            cmd.Parameters.Add(itemParameter.Name, itemParameter.Type, itemParameter.LengthValue).Direction=ParameterDirection.Output;
                    }
                }
                cmd.ExecuteNonQuery();

                //Recuperar parametro de salida 
                var OutputParameters = ParametersList.Where(R => R.Direction == ParameterDirection.Output).ToList();
              for (int i=0; i<ParametersList.Count; i ++)
                {
                    if (cmd.Parameters[i].Direction==ParameterDirection.Output)
                    {
                        ParametersList[i].Value = cmd.Parameters[i].Value.ToString();
                    }
                }
              
            }
            catch (Exception ex)
            {
                throw ex ;
            }finally
            {
                Close_Conection();
            }
        }


        //execute stored procedure  insert/update/s

        public DataTable  ListResult (string SPName , List<Parameters> ParametersList)
        {
            DataTable Result = new DataTable();
            SqlDataAdapter adapter;

            try
            {
                Open_Conection();
                adapter = new SqlDataAdapter(SPName, conection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (ParametersList!=null)
                    foreach (var item in ParametersList)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(item.Name, item.Value);
                    }
                adapter.Fill(Result);

            }
            catch (Exception ex )
            {

                throw ex ;
            }
            finally
            {
                Close_Conection();
            }
            return Result;
        }
    }
}
