using Dapper;
using RepairShop.Domain.Entities;
using RepairShop.Domain.Interfaces.Repositories;
using RepairShop.Infrastructure.Database.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepairShop.Infrastructure.Repositories
{
    public class PersonRepositoryDapper : CrudBaseDapper<Person>, IPersonRepository
    {
        public PersonRepositoryDapper(string connectionString) : base(connectionString){}

        public Person Add(Person person)
        {
            string script = AllQueries.Document_Add;
            var param = new DynamicParameters();


            param.Add("@Id", person.Id, DbType.Int32);
            param.Add("@Name", person.Name, DbType.String, size: 50);
            param.Add("@Surname", person.Surname, DbType.String, size:100);
            param.Add("@BirthDate", person.BirthDate, DbType.Date);
            param.Add("@Type", person.Type, DbType.Int16);


            person.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return person;
        }

        public Person Delete(Person Person)
        {
            throw new NotImplementedException();
        }

        public Person Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetByBirthDay(DateTime birthdate)
        {
            throw new NotImplementedException();
        }

        public Person GetByDocument(string documentValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person Person)
        {
            throw new NotImplementedException();
        }
    }
}
