﻿using System;
using System.Linq;
using Nancy;

namespace Okanshi.Dashboard
{
	public class SettingsModule : NancyModule
	{
		public SettingsModule(IConfiguration configuration)
		{
			Get["/settings"] = p =>
			{
				var servers = configuration.GetAll().ToArray();
				return View["settings.html", servers];
			};
			Post["/settings"] = p =>
			{
				var name = Request.Form.Name;
				var url = Request.Form.url;
				var refreshRate = Convert.ToInt64(Request.Form.refreshRate.Value);
				var server = new OkanshiServer(name, url, refreshRate);
				configuration.Add(server);
				return Response.AsRedirect("/settings");
			};
			Post["/settings/delete"] = p =>
			{
				var name = (string)Request.Form.InstanceName;
				configuration.Remove(name);
				return Response.AsRedirect("/settings");
			};
		}	
	}
}