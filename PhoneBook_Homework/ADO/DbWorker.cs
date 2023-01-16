using Microsoft.VisualBasic;
using PhoneBook_Homework.Interfaces;
using PhoneBook_Homework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Homework.ADO
{
    public class DbWorker : Interface_DB
    {
        private SqlConnection connection;
        private SqlCommand command;

        public DbWorker(string connectionString)
        {
             this.connection = new SqlConnection(connectionString);
        }

        public void Insert(Person person)
        {
            this.command = new SqlCommand();
            this.command.Connection = this.connection;

            this.command.CommandText = "INSERT INTO People VALUES ( @FirstName, @LastName, @Phone, @Email)";
            this.command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
            this.command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
            this.command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = person.Phone;
            this.command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;

            if (connection.State == ConnectionState.Closed) connection.Open();
            this.command.ExecuteNonQuery();

            this.connection.Close();

            Console.WriteLine($"Contact {person.FirstName + " " + person.LastName} has been added!");
        }

        public void Delete(int ID)
        {
            this.command = new SqlCommand();
            this.command.Connection = this.connection;

            this.command.CommandText = "DELETE FROM People WHERE PeopleID = @ID";
            this.command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            if (this.connection.State == ConnectionState.Closed) this.connection.Open();

            this.command.ExecuteNonQuery();

            this.connection.Close();

            Console.WriteLine($"Contact has been deleted!");
        }

        public void Update(int ID, Person person)
        {
            this.command = new SqlCommand();
            this.command.Connection = this.connection;

            this.command.CommandText = "UPDATE People SET FirstName = @Name, LastName = @Surname, Phone = @NewPhone, Email = @NewMail WHERE PeopleID = @IDUpdate";
            this.command.Parameters.Add("@IDUpdate", SqlDbType.Int).Value = ID;
            this.command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = person.FirstName;
            this.command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = person.LastName;
            this.command.Parameters.Add("@NewPhone", SqlDbType.NVarChar).Value = person.Phone;
            this.command.Parameters.Add("@NewMail", SqlDbType.NVarChar).Value = person.Email;
        

            if (this.connection.State == ConnectionState.Closed) this.connection.Open();

            this.command.ExecuteNonQuery();

            this.connection.Close();

            Console.WriteLine($"Contact {person.FirstName + " " + person.LastName} has been Updated!");
        }

        public List<Person> GetAllConnected()
        {
            this.command = new SqlCommand();
            this.command.Connection = this.connection;

            this.command.CommandText = "SELECT * FROM People";

            if (this.connection.State == ConnectionState.Closed) this.connection.Open();
            List<Person> persons = new List<Person>();


            SqlDataReader dr = this.command.ExecuteReader();
            

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Person person = new();
                    person.ID = Convert.ToInt32(dr[0]);
                    person.FirstName = dr["FirstName"].ToString();
                    person.LastName = dr["LastName"].ToString();
                    person.Phone = dr["Phone"].ToString();
                    person.Email = dr["Email"].ToString();

                    persons.Add(person);
                }
            }

            dr.Close();
            this.connection.Close();
            return persons;
        }

        public List<Person> Search(string keyword)
        {
            this.command = new SqlCommand();
            this.command.Connection = this.connection;

            this.command.CommandText = "SELECT * FROM People WHERE FirstName LIKE @Keyword OR LastName LIKE @Keyword OR Phone LIKE @Keyword OR Email LIKE @Keyword";
            this.command.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = keyword;

            if (this.connection.State == ConnectionState.Closed) this.connection.Open();
            List<Person> persons = new List<Person>();

            SqlDataReader dr = this.command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Person person = new();
                    person.ID = Convert.ToInt32(dr[0]);
                    person.FirstName = dr["FirstName"].ToString();
                    person.LastName = dr["LastName"].ToString();
                    person.Phone = dr["Phone"].ToString();
                    person.Email = dr["Email"].ToString();

                    persons.Add(person);
                }
            }

            dr.Close();
            this.connection.Close();
            return persons;
        }

    }
}
