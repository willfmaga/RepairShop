﻿using Dapper;
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
        public PersonRepositoryDapper(string connectionString) : base(connectionString) { }

        public Person Add(Person person)
        {
            string script = AllQueries.Person_Add;
            var param = new DynamicParameters();


            param.Add("@Id", person.Id, DbType.Int64);
            param.Add("@Name", person.Name, DbType.String, size: 50);
            param.Add("@Surname", person.Surname, DbType.String, size: 100);
            param.Add("@BirthDate", person.BirthDate, DbType.Date);
            param.Add("@TypeId", person.TypeId, DbType.Int16);
            param.Add("@DocumentId", person.TypeId, DbType.Int64);
            param.Add("@CreationDate", person.CreationDate, DbType.DateTime);

            person.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return person;
        }

        
        public Person GetById(Int64 id)
        {
            string script = AllQueries.Person_ById;
            var param = new DynamicParameters();


            param.Add("@Id", id, DbType.Int64);

            return ExecuteScriptWithoutTransactionSingle<Person>(script, param);
        }

        public IEnumerable<Person> GetByBirthDay(DateTime birthdate)
        {
            string script = AllQueries.Person_ByBirthDate;
            var param = new DynamicParameters();


            param.Add("@BirthDate", birthdate, DbType.Date);

            return ExecuteScriptWithoutTransactionList<Person>(script, param);
        }

        public Person GetByDocument(string documentValue)
        {
            string script = AllQueries.Person_ByDocument;
            var param = new DynamicParameters();


            param.Add("@DocumentValue", documentValue, DbType.String, size: 14);

            return ExecuteScriptWithoutTransactionSingle<Person>(script, param);
        }

        public IEnumerable<Person> GetByName(string name)
        {
            string script = AllQueries.Person_ByName;
            var param = new DynamicParameters();


            param.Add("@Name", name, DbType.String, size: 50);

            return ExecuteScriptWithoutTransactionList<Person>(script, param);
        }

        public IEnumerable<Person> GetBySurname(string surname)
        {
            string script = AllQueries.Person_BySurname;
            var param = new DynamicParameters();


            param.Add("@Surname", surname, DbType.String, size: 100);

            return ExecuteScriptWithoutTransactionList<Person>(script, param);
        }

        public void Update(Person person)
        {
            string script = AllQueries.Person_Update;
            var param = new DynamicParameters();


            param.Add("@Id", person.Id, DbType.Int64);

            param.Add("@Name", person.Name, DbType.String, size: 50);
            param.Add("@Surname", person.Surname, DbType.String, size: 100);
            param.Add("@BirthDate", person.BirthDate, DbType.Date);
            param.Add("@TypeId", person.TypeId, DbType.Int16);
            param.Add("@DocumentId", person.DocumentId, DbType.Int64);
            param.Add("@Active", person.Active, DbType.Boolean);

            ExecuteScriptWithTransaction(script, param);
        }
    }
}
