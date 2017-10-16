using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using trabajo2Web.Models;
using System.Web.Mvc;
namespace trabajo2Web.ViewModel
{
 
        public class LstClientViewModel
        {
            public List<Client> LstClient { get; set; }

            public LstClientViewModel()
            {
                trabajoparcialEntities context = new trabajoparcialEntities();
                LstClient = context.Client.ToList();
            }

        }
    
}