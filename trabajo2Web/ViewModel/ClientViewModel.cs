using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using trabajo2Web.Models;
using System.Web.Mvc;
namespace trabajo2Web.ViewModel
{
    public class ClientViewModel
    {

        public int? clientId { get; set; }
        public string DNI { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int sex { get; set; }
        public string description { get; set; }
        public SelectList City { get; set; }
        public int cityId { get; set; }

        public ClientViewModel()
        {

        }

        public void CargarDatos(int? clientId)
        {
            this.clientId = clientId;

            if(clientId.HasValue)
            {trabajoparcialEntities context = new trabajoparcialEntities();
            Client objClient = context.Client.FirstOrDefault(x=>x.clientId == clientId);
            this.DNI = objClient.DNI;
            this.firstName = objClient.firstName;
            this.lastName = objClient.lastName;
            this.sex = objClient.sex;
            this.description = objClient.description;
            this.cityId = objClient.cityId;
            }
        }

    }
}