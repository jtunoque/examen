using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface ISeguridadService
    {
        IEnumerable<Usuario> GetAll(string nombre);

        Usuario VerificarUsuario(string login, string password);
    }
}
