using PhoneBook_Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Homework.Interfaces
{
    public interface Interface_DB
    {
        public void Insert(Person person);
        public void Delete(int ID);
        public void Update(int ID, Person person);
        public List<Person> GetAllConnected();
        public List<Person> Search(string keyword);
    }
}
