using System.Collections.Generic;

namespace Okanshi.Dashboard.Models
{
	public class Service
	{
		public IEnumerable<Metric> Metrics { get; set; }
		public IEnumerable<HealthCheck> HealthChecks { get; set; }
	}
}