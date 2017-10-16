using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using trabajo2Web.Models;
using trabajo2Web.Controllers;
namespace trabajo2Web.ViewModel
{
    public class DashboardViewModel
    {
        public User user { get; set; }

        public DashboardViewModel()
        {

        }

        public void setUserLogged(User obj)
        {
            user = obj;
        }

        public User getUserLogged()
        {
            return user;
        }

        public void Inicializar()
        {
            trabajoparcialEntities context = new trabajoparcialEntities();
        }
    }
}

