using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyHack
{
    public static class SesionDeUsuario //Clase para tener el id del usuario con que se haya iniciado sesion
    {
        public static int CurrentUser { get; private set; }

        public static void SetCurrentUser(int userId)
        {
            CurrentUser = userId;
        }

        public static void CerrarSession()
        {
            CurrentUser = 0;
        }
    }
}
