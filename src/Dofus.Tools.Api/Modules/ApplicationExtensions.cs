﻿using Autofac;
using Dofus.Tools.Core.Features.Commands;
using Dofus.Tools.Core.Features.Commands.CreateCrush;
using Dofus.Tools.Core.Features.Commands.CreatePrice;
using Dofus.Tools.Core.Features.Queries.GetCrushesByIds;
using Dofus.Tools.Core.Features.Queries.GetPricesByIds;
using MediatR;
using NodaTime;

namespace Dofus.Tools.Api.Modules
{
    public static class ApplicationExtensions
    {
        public static ContainerBuilder RegisterUseCases(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterMediators();

            builder.Register(c => SystemClock.Instance).As<IClock>();
            builder.Register(c => DateTimeZoneProviders.Tzdb).As<IDateTimeZoneProvider>();

            return builder;
        }

        private static ContainerBuilder RegisterMediators(this ContainerBuilder builder)
        {
            // Uncomment to enable polymorphic dispatching of requests, but note that
            // this will conflict with generic pipeline behaviors
            // builder.RegisterSource(new ContravariantRegistrationSource());

            // Mediator itself
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterType<CreatePriceCommandHandler>().AsImplementedInterfaces();
            builder.RegisterType<CreateCrushCommandHandler>().AsImplementedInterfaces();
            builder.RegisterType<GetPricesByIdsQueryHandler>().AsImplementedInterfaces();
            builder.RegisterType<GetCrushesByIdsQueryHandler>().AsImplementedInterfaces();

            return builder;
        }
    }
}