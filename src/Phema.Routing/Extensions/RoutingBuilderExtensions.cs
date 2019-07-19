using System;

namespace Phema.Routing
{
	public static class RoutingBuilderExtensions
	{
		public static IControllerRouteBuilder AddController<TController>(
			this IRoutingBuilder builder,
			Action<IControllerBuilder<TController>> action)
		{
			return builder.AddController(RoutingDefaults.DefaultTemplate, action);
		}
	}
}