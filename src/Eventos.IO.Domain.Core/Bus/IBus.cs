using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;//Enviado atraves de uma camada superior

        void RaiseEvent<T>(T theEvent) where T : Event;//Lançado para que faça algum efeito(notificação, persistencia)

    }
}
