using BusinessProject.Core.Interfaces;
using BusinessProject.DataModelLayer.DbContext;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Services
{
   public class EntityDatabaseTransaction : IEntityDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;
        public EntityDatabaseTransaction(ApplicationContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            // when all changes has been aplied succssfully
            _transaction.Commit();
        }

        public void RollBack()
        {
            // when changes does not applied
            _transaction.Rollback();
        }


        public void Dispose()
        {
            // Destroy the object Of database
            _transaction.Dispose();
        }
    }
}
