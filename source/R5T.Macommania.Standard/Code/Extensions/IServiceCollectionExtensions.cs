using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy.Standard;

using R5T.Macommania.Default;


namespace R5T.Macommania.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IExecutableFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddExecutableFilePathProvider(this IServiceCollection services)
        {
            services.AddDefaultExecutableFilePathProvider();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IExecutableFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<IExecutableFilePathProvider> AddExecutableFilePathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IExecutableFilePathProvider>(() => services.AddExecutableFilePathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IExecutableFileDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddExecutableFileDirectoryPathProvider(this IServiceCollection services)
        {
            services.AddDefaultExecutableFileDirectoryPathProvider(
                services.AddDefaultExecutableFilePathProviderAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IExecutableFileDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddExecutableFileDirectoryPathProvider<TExecutableFileDirectoryPathProvider>(this IServiceCollection services)
            where TExecutableFileDirectoryPathProvider: IExecutableFileDirectoryPathProvider
        {
            services.AddExecutableFileDirectoryPathProvider();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IExecutableFileDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IExecutableFileDirectoryPathProvider> AddExecutableFileDirectoryPathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IExecutableFileDirectoryPathProvider>(() => services.AddExecutableFileDirectoryPathProvider());
            return serviceAction;
        }
    }
}
