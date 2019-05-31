using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TimeManagement.Data
{
    public class EmployeeProcessor : IEmployeeProcessor
    {
        private readonly string _connectionString;

        public EmployeeProcessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("insert into Employee(first_name, last_name, address, home_phone, cell_phone) VALUES (@FirstName, @LastName, @Address, @HomePhone, @CellPhone)",
                    new { employee.FirstName, employee.LastName, employee.Address, employee.HomePhone, employee.CellPhone });
            }
        }

        public void Delete(int employeeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Employee WHERE id=@Id", new { Id = employeeId });
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UPDATE Employee SET first_name =@FirstName, last_name =@LastName, address=@Address, home_phone=@HomePhone, cell_phone=@CellPhone WHERE id=@Id",
                    new { employee.FirstName, employee.LastName, employee.Address, employee.HomePhone, employee.CellPhone, employee.Id });
            }
            
        }
    }
}
