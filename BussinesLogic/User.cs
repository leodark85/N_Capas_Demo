using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using System.Data;

namespace BussinesLogic
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        Manager DataManager = new Manager();

        public string   AltaUser()
        {
            string Result = string.Empty;

            List<Parameters> parameters = new List<Parameters>();
            string Message = string.Empty;
            try
            {
                parameters.Add(new Parameters("@name",Name));
                parameters.Add(new Parameters("@email", Email));
                parameters.Add(new Parameters("@mensaje", SqlDbType.NVarChar,200));
                DataManager.SP_Excute("sp_AddUser", parameters);
                Message = parameters.Last().Value.ToString();
            }
            catch (Exception ex )
            {

                throw ex ;
            }

            return Result;
        }

        public DataTable ListUsers()
        {
            DataTable Result = new DataTable();

            Result= DataManager.ListResult("ListUsers", null );
            return Result;
        }
        
    }
}
