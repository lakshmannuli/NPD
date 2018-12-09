﻿using System.Web;
using System.Web.Optimization;

namespace NPD_UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // App Styles
            bundles.Add(new StyleBundle("~/Content/appCss").Include(
                "~/Content/app/css/app.css",
                "~/Content/mvc-override.css"
            ));

            // Bootstrap Styles
            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include(
                "~/Content/app/css/bootstrap.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new ScriptBundle("~/bundles/Angle").Include(
                // App init
                "~/Scripts/app/app.init.js",
                // Modules
                "~/Scripts/app/modules/bootstrap-start.js",
                //"~/Scripts/app/modules/calendar.js",
                //"~/Scripts/app/modules/easypiechart.js",
                "~/Scripts/app/modules/clear-storage.js",
                "~/Scripts/app/modules/constants.js",
                "~/Scripts/app/modules/flatdoc.js",
                "~/Scripts/app/modules/trigger-resize.js",
                "~/Scripts/app/modules/fullscreen.js",
                //"~/Scripts/app/modules/gmap.js",
                "~/Scripts/app/modules/load-css.js",
                //"~/Scripts/app/modules/localize.js",
                //"~/Scripts/app/modules/maps-vector.js",
                //"~/Scripts/app/modules/navbar-search.js",
                "~/Scripts/app/modules/notify.js",
                "~/Scripts/app/modules/now.js",
                "~/Scripts/app/modules/panel-tools.js",
                "~/Scripts/app/modules/play-animation.js",
                "~/Scripts/app/modules/porlets.js",
                "~/Scripts/app/modules/sidebar.js",
                "~/Scripts/app/modules/skycons.js",
                "~/Scripts/app/modules/slimscroll.js",
                "~/Scripts/app/modules/sparkline.js",
                "~/Scripts/app/modules/table-checkall.js",
                "~/Scripts/app/modules/toggle-state.js",
                "~/Scripts/app/modules/utils.js",
                //"~/Scripts/app/modules/chart.js",
                //"~/Scripts/app/modules/morris.js",
                //"~/Scripts/app/modules/rickshaw.js",
                //"~/Scripts/app/modules/chartist.js",
                //"~/Scripts/app/modules/tour.js",
                "~/Scripts/app/modules/sweetalert.js",
                //"~/Scripts/app/modules/color-picker.js",
                //"~/Scripts/app/modules/imagecrop.js",
                //"~/Scripts/app/modules/chart-knob.js",
                //"~/Scripts/app/modules/chart-easypie.js",
                "~/Scripts/app/modules/select2.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Vendor/jquery/dist/jquery.js"
          ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Vendor/modernizr/modernizr.custom.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Vendor/bootstrap/dist/js/bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/matchMedia").Include(
                  "~/Vendor/matchMedia/matchMedia.js"
          ));

            bundles.Add(new ScriptBundle("~/bundles/storage").Include(
            "~/Vendor/jQuery-Storage-API/jquery.storageapi.js"
          ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryEasing").Include(
           "~/Vendor/jquery.easing/js/jquery.easing.js"
         ));

            bundles.Add(new ScriptBundle("~/bundles/animo").Include(
            "~/Vendor/animo.js/animo.js"
          ));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
             "~/Vendor/slimscroll/jquery.slimscroll.min.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/screenfull").Include(
           "~/Vendor/screenfull/dist/screenfull.js"
         ));

            bundles.Add(new ScriptBundle("~/bundles/demoRTL").Include(
               "~/Scripts/demo/demo-rtl.js"
           ));




            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
          "~/Vendor/fontawesome/css/font-awesome.min.css", new CssRewriteUrlTransform()
        ));

            bundles.Add(new StyleBundle("~/bundles/simpleLineIcons").Include(
            "~/Vendor/simple-line-icons/css/simple-line-icons.css", new CssRewriteUrlTransform()
          ));
            bundles.Add(new StyleBundle("~/bundles/animatecss").Include(
                        "~/Vendor/animate.css/animate.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/whirl").Include(
            "~/Vendor/whirl/dist/whirl.css"
          ));

            bundles.Add(new StyleBundle("~/bundles/select2Css").Include(
            "~/Vendor/select2/dist/css/select2.css",
            "~/Vendor/select2-bootstrap-theme/dist/select2-bootstrap.css"
          ));



        }
    }
}
