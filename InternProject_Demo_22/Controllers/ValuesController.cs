using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace InternProject_Demo_22.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server = cdtssql740d; database = TrainingDB; user id = sqluser; password = sqluser; Trusted_Connection = False; MultipleActiveResultSets=true;");
        
        /** This is used to get all the Intern Data **/

        [HttpGet]
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Sadman_Intern].[Intern_ID], [Intern_Name], [Project_Name] FROM [Sadman_Intern] LEFT Join [Sadman_Project] on [Sadman_Intern].[Intern_ID] = [Sadman_Project].[Intern_ID]", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data Found";
            }
        }

        /** This is used to get a single Intern Data **/

        [HttpGet]
        public string Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Sadman_Intern WHERE Intern_Id = '" + id + "'", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data Found";
            }
        }

        /** This is used to add a single Intern ID **/

        [HttpPost]
        public string Post([FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("Insert Into Sadman_Intern(Intern_ID) VALUES('" + value+ "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i == 1)
            {
                return ($"The entry with ID: {value} was successfully created.");
            }
            else
            {
                return ("Entry was not created.");
            }
        }

        /** This is used to set Intern Name to Intern ID **/

        [HttpPut]
        public string Put(int id, [FromBody]string value)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Sadman_Intern SET Intern_Name = '" + value + "' WHERE Intern_Id = '" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i == 1)
            {
                return ($"Name of Intern: {id} was set to {value}");
            }
            else
            {
                return ("The entry is missing or cannot be updated");
            }
        }

        /** This is used to delete a single Intern Data **/

        [HttpDelete]
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Sadman_Intern WHERE Intern_ID = '" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return ($"The entry of {id} was successfully deleted.");
            }
            else
            {
                return ("The entry is missing or cannot be updated");
            }
        }
    }
}
