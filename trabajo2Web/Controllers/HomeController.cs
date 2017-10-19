using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabajo2Web.Models;
using trabajo2Web.ViewModel;
namespace trabajo2Web.Controllers
{
    public class HomeController : Controller
    {
        public User LoggedUser;
        public ActionResult Login()
        {

            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel)
        {
            try
            {
                trabajoparcialEntities context = new trabajoparcialEntities();

                User objuser = context.User.FirstOrDefault(X => X.username == objViewModel.username);
                setLoggedUser(objuser);

                if (objuser != null && objuser.password == objViewModel.password)
                {
                    Session["User"] = objuser;
                    return RedirectToAction("Dashboard");
                }

                return View(objViewModel);
            }
            catch (Exception ex)
            {

            }

            return View(objViewModel);
        }

        public void setLoggedUser(User u)
        {
            LoggedUser = u;
        }
        public User getLoggedUser()
        {
            return LoggedUser;
        }
        public ActionResult Index()
        {
            return RedirectToAction("login");
        }

        public ActionResult Dashboard()
        {
            DashboardViewModel objViewModel = new DashboardViewModel();
            objViewModel.setUserLogged((User)Session["Usuario"]);
            return View(objViewModel);
        }

        public ActionResult LstClient()
        {
            LstClientViewModel objViewModel = new LstClientViewModel();
            return View(objViewModel);
        }

        public ActionResult AddEditClient(int? clientId)
        {
            ClientViewModel objAddEdit = new ClientViewModel();
            objAddEdit.CargarDatos(clientId);
            trabajoparcialEntities context = new trabajoparcialEntities();
            objAddEdit.City = new SelectList(context.City, "cityId", "name");
            return View(objAddEdit);

        }

        public ActionResult EliminarClient(int? clientId)
        {
            try
            {
                trabajoparcialEntities context = new trabajoparcialEntities();
                Client objClient = context.Client.FirstOrDefault(x => x.clientId == clientId);
                context.SaveChanges();
                TempData["Mensaje"] = "Exito! La operación se realizó con éxito";
                return RedirectToAction("LstClient");

            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error! " + ex.Message.ToList();
                return RedirectToAction("LstClient");

            }
        }

        [HttpPost]

        public ActionResult AddEditClient(ClientViewModel objViewModel)
        {
            try
            {
                trabajoparcialEntities context = new trabajoparcialEntities();
                Client objClient = new Client();
                if (objViewModel.clientId.HasValue)
                {

                    objClient = context.Client.FirstOrDefault(x => x.clientId == objViewModel.clientId);
                    objClient.clientId = objViewModel.clientId.Value;

                }

                else
                {
                    context.Client.Add(objClient);

                }

                objClient.DNI = objViewModel.DNI;
                objClient.firstName = objViewModel.firstName;
                objClient.lastName = objViewModel.lastName;
                objClient.sex = objViewModel.sex;
                objClient.description = objViewModel.description;
                objClient.cityId = objViewModel.cityId;

                context.SaveChanges();
                TempData["Mensaje"] = "Exito! La operación se realizó con éxito";
                return RedirectToAction("LstClient");

            }


            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error! " + ex.Message.ToList();

                return View(objViewModel);

            }

        }


    }
}