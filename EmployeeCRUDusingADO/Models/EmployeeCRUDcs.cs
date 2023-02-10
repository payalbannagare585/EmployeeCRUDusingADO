using System.Data.SqlClient;

namespace EmployeeCRUDusingADO.Models
{
    public class EmployeeCRUDcs
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeCRUDcs(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Employee> GetAllStudent()
        {
            List<Employee> emplist = new List<Employee>();
            string qry = "select * from tblEmployee where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Mobile = dr["Mobile"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.IsActive = Convert.ToInt32(dr["IsActive"]);
                    emplist.Add(emp);
                }
            }
            con.Close();
            return emplist;

        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string qry = "select * from tblEmployee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Mobile = dr["Mobile"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.IsActive = Convert.ToInt32(dr["IsActive"]);
                }
            }
            con.Close();
            return emp;
        }

        public int AddEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "insert into tblEmployee values(@name,@mobile,@email,@city,@gender,@salary,@isactive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@city", emp.City);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "update tblEmployee set Name=@name,Mobile=@mobile,Email=@email,City=@city,Gender=@gender,Salary=@salary,IsActive=@isactive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@city", emp.City);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "delete from tblEmployee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }

}

