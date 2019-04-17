using App.Data.Repository;
using App.Data.Repository.Interfaces.QuerySpecifications;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class SeguridadService : ISeguridadService
    {
        public IEnumerable<Usuario> GetAll(string nombre)
        {
            IEnumerable<Usuario> result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                var additionalInfo = new GetAdditionalSimpleInfo<Usuario>()
                {
                    Filters= item=>String.Concat(item.Nombres, " ", item.Apellidos).Contains(nombre)
                };

                result = unitOfWork.UsuarioRepository.GetAll(additionalInfo).ToList();

            }
            return result;
        }

        public Usuario VerificarUsuario(string login, string password)
        {
            Usuario result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                var additionalInfo = new GetAdditionalSimpleInfo<Usuario>()
                {
                    Filters = item => item.Login == login
                        && item.Password == password
                };

                result = unitOfWork.UsuarioRepository.GetAll(additionalInfo).SingleOrDefault();

            }
            return result;
        }
    }
}
