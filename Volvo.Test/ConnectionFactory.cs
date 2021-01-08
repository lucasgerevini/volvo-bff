
using System;
using Microsoft.EntityFrameworkCore;
using Volvo.BFF.Data;

namespace Volvo.Test
{
    public class ConnectionFactory: IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public VolvoContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<VolvoContext>().UseInMemoryDatabase(databaseName: $"VolvoDbInMemory").Options;

            var context = new VolvoContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
