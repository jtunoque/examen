using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IAppUnitOfWork:IDisposable
    {
        ITareaRepository TareaRepository { get; set; }
        IUsuarioRepository UsuarioRepository { get; set; }
        int Complete();

    }
}
