using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLauncher
{
    /// <summary>
    /// Modo de inicio personalizado
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
        private String _id, _name;
        private CustomStartMode _mode;

        /// <summary>
        /// Servicio relacionado
        /// </summary>
        /// <param name="id">Identificador del servicio en el sistema</param>
        /// <param name="name">Nombre para mostrar</param>
        /// <param name="mode">Modo de inicio</param>
        public RelatedService(String id, String name, CustomStartMode mode)
        {
            _id = id;
            _name = name;
            _mode = mode;
        }

        public RelatedService()  {  }
        
        /// <summary>
        /// Identificador del proceso (nombre interno)
        /// </summary>
        public String Id 
        { 
            get 
            { 
                return _id; 
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Nombre del proceso
        /// </summary>
        public String Name
        {
            get 
            { 
                return _name; 
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Modo de inicio
        /// </summary>
        public CustomStartMode Mode 
        { 
            get 
            {
                return _mode; 
            }

            set
            {
                _mode = value;
            }
        }
    }
}
