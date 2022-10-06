// <copyright file="ServiceMapper.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.Mappers
{
    using System.Collections.ObjectModel;
    using AutoMapper;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using Self = ServiceMapper;

    /// <summary>
    /// The AutoMapper Service Mapper.
    /// </summary>
    internal static class ServiceMapper
    {
        /// <summary>
        /// The mapper object.
        /// </summary>
        private static readonly IMapper Mapper;

        /// <summary>
        /// Initializes static members of the <see cref="ServiceMapper"/> class.
        /// </summary>
        static ServiceMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IAuditBO, IAuditDTO>();
            });

            Self.Mapper = config.CreateMapper();
        }

        /// <summary>
        /// Maps to a Data Transfer Object.
        /// </summary>
        /// <param name="auditEntries">The audit entries.</param>
        /// <returns>
        /// The mapped Data Transfer Object.
        /// </returns>
        public static Collection<IAuditDTO> MapToDTO(this Collection<IAuditBO> auditEntries)
        {
            return Self.Mapper.Map<Collection<IAuditBO>, Collection<IAuditDTO>>(auditEntries);
        }
    }
}