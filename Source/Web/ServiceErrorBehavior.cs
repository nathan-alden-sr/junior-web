using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using Junior.Common;

namespace Junior.Web
{
	/// <summary>
	/// Adds an error handler type to the list of error handlers associated with all channel dispatchers.
	/// </summary>
	public class ServiceErrorBehaviorAttribute : Attribute, IServiceBehavior
	{
		private readonly Type _errorHandlerType;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceErrorBehaviorAttribute"/> class.
		/// </summary>
		/// <param name="errorHandlerType">The type of error handler to associate with all channel dispatchers.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="errorHandlerType"/> is null.</exception>
		public ServiceErrorBehaviorAttribute(Type errorHandlerType)
		{
			errorHandlerType.ThrowIfNull("errorHandlerType");

			_errorHandlerType = errorHandlerType;
		}

		/// <summary>
		/// Provides the ability to inspect the service host and the service description to confirm that the service can run successfully.
		/// </summary>
		/// <param name="serviceDescription">The service description.</param>
		/// <param name="serviceHostBase">The service host that is currently being constructed.</param>
		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
		}

		/// <summary>
		/// Provides the ability to pass custom data to binding elements to support the contract implementation.
		/// </summary>
		/// <param name="serviceDescription">The service description of the service.</param>
		/// <param name="serviceHostBase">The host of the service.</param>
		/// <param name="endpoints">The service endpoints.</param>
		/// <param name="bindingParameters">Custom objects to which binding elements have access.</param>
		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
		{
		}

		/// <summary>
		/// Provides the ability to change run-time property values or insert custom extension objects such as error handlers, message or parameter interceptors, security extensions, and other custom extension objects.
		/// </summary>
		/// <param name="serviceDescription">The service description.</param>
		/// <param name="serviceHostBase">The host that is currently being built.</param>
		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			var errorHandler = (IErrorHandler)Activator.CreateInstance(_errorHandlerType);

			foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
			{
				channelDispatcher.ErrorHandlers.Add(errorHandler);
			}
		}
	}
}