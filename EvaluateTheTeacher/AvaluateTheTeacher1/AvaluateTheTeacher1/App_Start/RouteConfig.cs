using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvaluateTheTeacher1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DetailsGroups",
                url: "groups-list/details-group/{id}",
                defaults: new { controller = "Group", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditGroups",
                url: "group-list/edit-group/{id}",
                defaults: new { controller = "Group", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateGroups",
                url: "groups-list/new-subject/",
                defaults: new { controller = "AddingGroup", action = "AddNewGroup" }
            );

            routes.MapRoute(
                name: "DeleteGroups",
                url: "groups-list/delete-group/{id}",
                defaults: new { controller = "Group", action = "Delete", id = UrlParameter.Optional }
            );
            //
            routes.MapRoute(
                name: "DetailsSubjects",
                url: "subjects-list/details-subject/{id}",
                defaults: new { controller = "Subjects", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditSubjects",
                url: "subjects-list/edit-subject/{id}",
                defaults: new { controller = "Subjects", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateSubjects",
                url: "subjects-list/new-subject/",
                defaults: new { controller = "Subjects", action = "Create" }
            );

            routes.MapRoute(
                name: "DeleteSubjects",
                url: "subjects-list/delete-subject/{id}",
                defaults: new { controller = "Subjects", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditTeacher",
                url: "teachers-list/edit-teacher/{id}",
                defaults: new { controller = "Teachers", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteTeacher",
                url: "teachers-list/delete-teacher/{id}",
                defaults: new { controller = "Teachers", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddNewTeacher",
                url: "teachers-list/new-teacher/",
                defaults: new { controller = "AddingTeacher", action = "AddNewTeacher" }
            );

            routes.MapRoute(
                name: "AddNewStudent",
                url: "new-student/",
                defaults: new { controller = "AddingStudent", action = "AddNewStudent" }
            );

            routes.MapRoute(
                name: "ListOfUsers",
                url: "users-list/{id}",
                defaults: new { controller = "Admin", action = "ListOfUsers", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GroupsList",
                url: "groups-list/",
                defaults: new { controller = "Group", action = "Index" }
            );

            routes.MapRoute(
                name: "TeachersList",
                url: "teachers-list/",
                defaults: new { controller = "Teachers", action = "Index" }
            );

            routes.MapRoute(
                name: "SubjectsList",
                url: "subjects-list/",
                defaults: new { controller = "Subjects", action = "Index" }
            );

            routes.MapRoute(
                name: "AdminPersonalAreaManage",
                url: "personal-area/",
                defaults: new { controller = "Admin", action = "Home" }
            );

            routes.MapRoute(
                name: "AdminPersonalArea",
                url: "admin-personal-area/",
                defaults: new { controller = "Admin", action = "Home" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login/",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "ChangeLogin",
                url: "personal-area-manage/change-user-name/",
                defaults: new { controller = "Manage", action = "EditUserName" }
            );

            routes.MapRoute(
                name: "ChangePassword",
                url: "personal-area-manage/change-password/",
                defaults: new { controller = "Manage", action = "ChangePassword" }
            );

            routes.MapRoute(
                name: "Manage",
                url: "personal-area-manage/",
                defaults: new { controller = "Manage", action = "Index" }
            );

            routes.MapRoute(
                name: "VoteAccepted",
                url: "voting-page/vote-accepted/",
                defaults: new { controller = "Votings", action = "VoteAccepted" }
            );

            routes.MapRoute(
                name: "Votings",
                url: "voting-page/{id}",
                defaults: new { controller = "Votings", action = "Votings", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Raiting",
                url: "your-teachers/",
                defaults: new { controller = "Raiting", action = "VoitingMain" }
            );

            routes.MapRoute(
                name: "Dashboard",
                url: "dashboard/",
                defaults: new { controller = "Teachers", action = "Dashboard" }
            );

            routes.MapRoute(
                name: "MoreInfoAboutTeacher",
                url: "more-info/{id}",
                defaults: new { controller = "MoreInfoForteacher", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ListOfTeachers",
                url: "list-of-teacher/{id}",
                defaults: new { controller = "ListOfTeachers", action = "ListOfTeachers", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HomePage",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "LogOff",
                url: "log-off/",
                defaults: new { controller = "Account", action = "LogOff" }
            );

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/

            routes.MapRoute(
                name: "CatchAll",
                url: "{*url}",
                defaults: new { controller = "Error", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
