﻿using MinecControlReport.Filters;
using System.Web;
using System.Web.Mvc;

namespace MinecControlReport
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new InitializeSimpleMembershipAttribute());
        }
    }
}