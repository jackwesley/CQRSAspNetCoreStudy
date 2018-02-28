using System;
using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Interfaces;

namespace ConsoleTesting
{


    public class FakeUow : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            return new CommandResponse(false);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}