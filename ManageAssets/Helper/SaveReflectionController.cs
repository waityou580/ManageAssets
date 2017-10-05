using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageAssets.Models;

namespace ManageAssets.Helper
{
    public class SaveReflectionController
    {

        AssetsManagerEntities db = new AssetsManagerEntities();
        public void SaveReflection()
        {
            ReflectionController reflection = new ReflectionController();

            List<Type> listController = reflection.GetControllers();
            foreach (Type controller in listController)
            {
                if (!(db.Sys_Controller.Any(n => n.Controller_ID == controller.Name)))
                {
                    Sys_Controller controllerDB = new Sys_Controller();
                    controllerDB.Controller_ID = controller.Name;
                    db.Sys_Controller.Add(controllerDB);
                    db.SaveChanges();
                }

                List<string> listAction = reflection.GetAction(controller);
                foreach (string action in listAction)
                {
                    var controllerID = db.Sys_Controller.Where(p => p.Controller_ID == controller.Name).SingleOrDefault().Controller_ID;
                    var checkActionDB = db.Sys_Action.Any(n => n.Action_ID == (controllerID.Remove(controllerID.Length - 10)) + "-" + action && n.Controller_ID == controllerID);
                    if (!checkActionDB)
                    {
                        Sys_Action actionDB = new Sys_Action();
                        string actionID = controllerID.Remove(controllerID.Length - 10) + "-" + action;
                        actionDB.Action_ID = actionID;
                        actionDB.Controller_ID = controllerID;
                        db.Sys_Action.Add(actionDB);
                        db.SaveChanges();
                    }

                }
            }
        }
    }
}