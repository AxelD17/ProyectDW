﻿using System.Web;
using System.Web.Optimization;

namespace ProyectDW2
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/sb-admin-2.min.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/sb-admin-2.min.css",
                      "~/Content/vendor/fontawesome-free/css/all.min.css"));
        }
    }
}
