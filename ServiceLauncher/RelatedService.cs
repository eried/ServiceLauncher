using System;

namespace ServiceLauncher
{
    /// <summary>
    ///     Modo de inicio personalizado
    /// </summary>
    public enum CustomStartMode
    {
        StartStop,
        StartOnly,
        SystemAutomatic,
        SystemAutomaticDelayed,
        SystemManual,
        SystemDisabled,
        Unknown
    }

    public class RelatedService
    {
        /// <summary>
        ///     Servicio relacionado
        /// </summary>
        /// <param name="id">Identificador del servicio en el sistema</param>
        /// <param name="name">Nombre para mostrar</param>
        /// <param name="mode">Modo de inicio</param>
        public RelatedService(String id, String name, CustomStartMode mode)
        {
            Id = id;
            Name = name;
            Mode = mode;
        }

        public RelatedService()
        {
        }

        /// <summary>
        ///     Identificador del proceso (nombre interno)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Nombre del proceso
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Modo de inicio
        /// </summary>
        public CustomStartMode Mode { get; set; }
    }
}