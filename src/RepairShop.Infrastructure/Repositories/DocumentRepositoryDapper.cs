using Dapper;
using Google.Protobuf.WellKnownTypes;
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
using static Dapper.SqlMapper;
using Document = RepairShop.Domain.Entities.Document;

namespace RepairShop.Infrastructure.Repositories
{
    public class DocumentRepositoryDapper : CrudBaseDapper<Document>, IDocumentRepository
    {

        public DocumentRepositoryDapper(string connectionString) : base(connectionString) { }

        public Document Add(Document document)
        {
            string script = AllQueries.Document_Add;
            var param = new DynamicParameters();


            param.Add("@Id", document.Id, DbType.Int32);
            param.Add("@Value", document.Value, DbType.String, size: 14);
            param.Add("@TypeId", document.TypeId, DbType.Int16);
            param.Add("@CreationDate", document.CreationDate, DbType.DateTime);

            document.Id = ExecuteScriptWithTransactionSingle<int>(script, param);

            return document;
        }


        public void Update(Document document)
        {
            string script = AllQueries.Document_Update;
            var param = new DynamicParameters();


            param.Add("@Id", document.Id, DbType.Int32);
            param.Add("@TypeId", document.TypeId, DbType.Int16);
            param.Add("@Active", document.Active, DbType.Boolean);

            ExecuteScriptWithTransaction(script, param);

             
        }

        public Document GetById(Int64 id)
        {
            string script = AllQueries.Document_ById;
            var param = new DynamicParameters();


            param.Add("@Id", id, DbType.Int64);

            return ExecuteScriptWithoutTransactionSingle<Document>(script, param);
        }
        public Document GetByValue(string value)
        {
            string script = AllQueries.Document_ByValue;
            var param = new DynamicParameters();


            param.Add("@Value", value, DbType.String, size: 14);

            return ExecuteScriptWithoutTransactionSingle<Document>(script, param);

            
        }
    }


}
