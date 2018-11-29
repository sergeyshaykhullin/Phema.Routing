using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Phema.Routing.Tests
{
	public class RouteBuilderExtensionsTests
	{
		private readonly IServiceCollection services;

		public RouteBuilderExtensionsTests()
		{
			services = new ServiceCollection();
		}
		
		[Fact]
		public void AddHttpHeadConstraint()
		{
			services.AddMvcCore()
				.AddRouting(routing =>
					routing.AddController<TestController>("test", controller => {})
						.HttpHead());

			var provider = services.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<RoutingOptions>>().Value;
			
			var (_, actionMetadata) = Assert.Single(options.Controllers);
			var constraint = Assert.Single(actionMetadata.Constraints)(provider);

			var methodActionConstraint = Assert.IsType<HttpMethodActionConstraint>(constraint);
			
			Assert.Equal(RouteBuilderExtensions.HttpHeadMethod, Assert.Single(methodActionConstraint.HttpMethods));
		}
		
		[Fact]
		public void AddHttpGetConstraint()
		{
			services.AddMvcCore()
				.AddRouting(routing =>
					routing.AddController<TestController>("test", controller => {})
						.HttpGet());

			var provider = services.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<RoutingOptions>>().Value;
			
			var (_, actionMetadata) = Assert.Single(options.Controllers);
			var constraint = Assert.Single(actionMetadata.Constraints)(provider);

			var methodActionConstraint = Assert.IsType<HttpMethodActionConstraint>(constraint);
			
			Assert.Equal(RouteBuilderExtensions.HttpGetMethod, Assert.Single(methodActionConstraint.HttpMethods));
		}
		
		[Fact]
		public void AddHttpGetOrHeadConstraint()
		{
			services.AddMvcCore()
				.AddRouting(routing =>
					routing.AddController<TestController>("test", controller => {})
						.HttpGetOrHead());

			var provider = services.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<RoutingOptions>>().Value;
			
			var (_, actionMetadata) = Assert.Single(options.Controllers);
			var constraint = Assert.Single(actionMetadata.Constraints)(provider);

			var methodActionConstraint = Assert.IsType<HttpMethodActionConstraint>(constraint);
			
			Assert.Collection(methodActionConstraint.HttpMethods,
				s => Assert.Equal(RouteBuilderExtensions.HttpHeadMethod, s),
				s => Assert.Equal(RouteBuilderExtensions.HttpGetMethod, s));
		}
		
		[Fact]
		public void AddHttpPostConstraint()
		{
			services.AddMvcCore()
				.AddRouting(routing =>
					routing.AddController<TestController>("test", controller => {})
						.HttpPost());

			var provider = services.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<RoutingOptions>>().Value;
			
			var (_, actionMetadata) = Assert.Single(options.Controllers);
			var constraint = Assert.Single(actionMetadata.Constraints)(provider);

			var methodActionConstraint = Assert.IsType<HttpMethodActionConstraint>(constraint);
			
			Assert.Equal(RouteBuilderExtensions.HttpPostMethod, Assert.Single(methodActionConstraint.HttpMethods));
		}
		
		[Fact]
		public void AddHttpPutConstraint()
		{
			services.AddMvcCore()
				.AddRouting(routing =>
					routing.AddController<TestController>("test", controller => {})
						.HttpPut());

			var provider = services.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<RoutingOptions>>().Value;
			
			var (_, actionMetadata) = Assert.Single(options.Controllers);
			var constraint = Assert.Single(actionMetadata.Constraints)(provider);

			var methodActionConstraint = Assert.IsType<HttpMethodActionConstraint>(constraint);
			
			Assert.Equal(RouteBuilderExtensions.HttpPutMethod, Assert.Single(methodActionConstraint.HttpMethods));
		}
		
		[Fact]
		public void AddHttpDeleteConstraint()
		{
			services.AddMvcCore()
				.AddRouting(routing =>
					routing.AddController<TestController>("test", controller => {})
						.HttpDelete());

			var provider = services.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<RoutingOptions>>().Value;
			
			var (_, actionMetadata) = Assert.Single(options.Controllers);
			var constraint = Assert.Single(actionMetadata.Constraints)(provider);

			var methodActionConstraint = Assert.IsType<HttpMethodActionConstraint>(constraint);
			
			Assert.Equal(RouteBuilderExtensions.HttpDeleteMethod, Assert.Single(methodActionConstraint.HttpMethods));
		}
	}
}