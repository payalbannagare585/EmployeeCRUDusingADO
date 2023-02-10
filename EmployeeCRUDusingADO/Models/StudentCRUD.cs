using System.Data.SqlClient;

namespace EmployeeCRUDusingADO.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Student> GetAllStudent()
        {
            List<Student> studlist = new List<Student>();
            string qry = "select * from tblStudent where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student stud = new Student();
                    stud.Id = Convert.ToInt32(dr["id"]);
                    stud.Name = dr["Name"].ToString();
                    stud.Mobile = dr["Mobile"].ToString();
                    stud.City = dr["City"].ToString();
                    stud.Email = dr["Email"].ToString();
                    stud.Gender = dr["Gender"].ToString();
                    stud.Fees = Convert.ToDouble(dr["Fees"]);
                    stud.IsActive = Convert.ToInt32(dr["IsActive"]);
                    studlist.Add(stud);
                }
            }
            con.Close();
            return studlist;

        }
        public Student GetStudentById(int id)
        {
            Student stud = new Student();
            string qry = "select * from tblStudent where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    stud.Id = Convert.ToInt32(dr["id"]);
                    stud.Name = dr["Name"].ToString();
                    stud.Mobile = dr["Mobile"].ToString();
                    stud.City = dr["City"].ToString();
                    stud.Email = dr["Email"].ToString();
                    stud.Gender = dr["Gender"].ToString();
                    stud.Fees = Convert.ToDouble(dr["Fees"]);
                    stud.IsActive = Convert.ToInt32(dr["IsActive"]);
                }
            }
            con.Close();
            return stud;
        }

        public int AddStudent(Student stud)
        {
            int result = 0;
            stud.IsActive = 1;
            string qry = "insert into tblStudent values(@name,@mobile,@email,@city,@gender,@fees,@isactive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@mobile", stud.Mobile);
            cmd.Parameters.AddWithValue("@email", stud.Email);
            cmd.Parameters.AddWithValue("@city", stud.City);
            cmd.Parameters.AddWithValue("@gender", stud.Gender);
            cmd.Parameters.AddWithValue("@fees", stud.Fees);
            cmd.Parameters.AddWithValue("@isactive", stud.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateStudent(Student stud)
        {
            int result = 0;
            stud.IsActive = 1;
            string qry = "update tblStudent set Name=@name,Mobile=@mobile,Email=@email,City=@city,Gender=@gender,Fees=@fees,IsActive=@isactive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", stud.Id);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@mobile", stud.Mobile);
            cmd.Parameters.AddWithValue("@email", stud.Email);
            cmd.Parameters.AddWithValue("@city", stud.City);
            cmd.Parameters.AddWithValue("@gender", stud.Gender);
            cmd.Parameters.AddWithValue("@fees", stud.Fees);
            cmd.Parameters.AddWithValue("@isactive", stud.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from tblStudent where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
