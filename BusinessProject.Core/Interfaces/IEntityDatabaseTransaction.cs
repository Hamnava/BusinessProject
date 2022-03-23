using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Interfaces
{
   public interface IEntityDatabaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
