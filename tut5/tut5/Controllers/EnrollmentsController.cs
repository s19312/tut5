using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using tut5.Models;

namespace tut5.Controllers { 
    

    [ApiController]
    [Route("api/enrollment")]
    public class EnrollmentsController : ControllerBase
    {

        [HttpPost]
        public IActionResult Enrollment(Student student)
        {
            var result = new List<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19312;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                con.Open();
                var tran = con.BeginTransaction();
                com.Connection = con;
                com.CommandText = $"INSERT INTO Student(IndexNumber, FirstName, LastName) VALUES (@FirstName,@LastName,@BirthDate,@IdEnrollment)";
                com.Parameters.AddWithValue("FistName", student.FirstName);
                com.Parameters.AddWithValue("FistName", student.LastName);
                com.Parameters.AddWithValue("FistName", student.BirthDate);
                com.Parameters.AddWithValue("FistName", student.IdEnrollment);

                tran.Commit();
                com.CommandText = "Select * from Student";
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.IdEnrollment = dr["IdEnrollment"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    result.Add(st);
                }
            }
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(result);
        }




    }
}
