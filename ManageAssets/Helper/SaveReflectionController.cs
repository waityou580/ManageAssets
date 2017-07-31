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
            Sys_Controller sysController = new Sys_Controller();
            Sys_Action sysAction = new Sys_Action();
            ReflectionController reflection = new ReflectionController();

            List<Type> listController = reflection.GetControllers();
            foreach (Type controller in listController)
            {
                try
                {
                    var controllerName = db.Sys_Controller.Where(p => p.Controller_Name == controller.Name).SingleOrDefault();
                    if (controllerName == null)
                    {
                        sysController.Controller_Name = controller.Name;
                        db.Sys_Controller.Add(sysController);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                }
                List<string> listAction = reflection.GetAction(controller);
                foreach (string action in listAction)
                {
                    var controllerID = db.Sys_Controller.Where(p => p.Controller_Name == controller.Name).SingleOrDefault().Controller_ID;
                    if (db.Sys_Action.Where(p => p.Action_Name == action && p.Controller_ID == controllerID).SingleOrDefault() == null)
                    {
                        sysAction.Controller_ID = controllerID;
                        sysAction.Action_Name = action;
                        db.Sys_Action.Add(sysAction);
                        db.SaveChanges();
                    }
                }
            }
            var lstAction = db.Sys_Action.ToList();
            Sys_Role role = new Sys_Role();
            foreach (var i in lstAction)
            {
                if(db.Sys_Role.Where(n => n.RoleID == i.Action_ID.ToString()).SingleOrDefault() == null)
                {
                    role.RoleID = i.Action_ID.ToString();
                    role.RoleName = db.Sys_Controller.Find(i.Controller_ID).Controller_Name.ToString() + "-" + i.Action_Name.ToString();
                    db.Sys_Role.Add(role);
                    db.SaveChanges();
                }
            }
        }
    }
}