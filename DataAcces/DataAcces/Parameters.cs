using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
   public class Parameters
    {
        //Parameters
        public string Name { get; set; }
        public Object  Value{ get; set; }
        public SqlDbType Type { get; set; }
        public Int32 LengthValue { get; set; }
        public ParameterDirection Direction { get; set; }


        //constructors
        //input parameters
        public  Parameters( string Object_Name , object Object_Value)
        {
            Name = Object_Name;
            Value = Object_Value;
            Direction = ParameterDirection.Input;
        }
        //output parameters
        public Parameters (string Object_Name , SqlDbType Object_Type, Int32 Object_LengthValue)
        {
            Name = Object_Name;
            Type = Object_Type;
            LengthValue = Object_LengthValue;
            Direction = ParameterDirection.Output;
        }
    }
}
