using System.Linq;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceProcess;

namespace ServiceLauncher
{
    public class RelatedServicesManager
    {
        List<RelatedService> _services;

        public RelatedServicesManager()
        {
            _services = new List<RelatedService>();
        }

        internal Boolean Add(RelatedService r)
        {
            if (!Exists(r.Id))
            {
                _services.Add(r);
                return true;
            }
            
            return false;
        }

        internal Boolean Add(String id, String name, CustomStartMode mode)
        {
            return Add(new RelatedService(id, name, mode));
        }

        internal void AddRelatedServices(String text)
        {
            Add(GetRelatedServices(text));
        }

        internal List<ServiceController> GetRelatedServices(string text)
        {
            var output = new List<ServiceController>();

            text = text.ToLower().Trim();

            if(text.Length > 0)
                output.AddRange(ServiceController.GetServices().Where(s => s.DisplayName.ToLower().Contains(text) || s.ServiceName.ToLower().Contains(text)));

            return output;
        }

        internal void Add(List<ServiceController> list)
        {
            foreach (var s in list)
                Add(s);
        }

        private Boolean Add(ServiceController s)
        {
            return Add(s.ServiceName);
        }

        internal Boolean Add(String id, String name)
        {
            return Add(new RelatedService(id, name, GetServiceStartMode(id)));
        }

        internal Boolean Add(String id)
        {
            return Add(new RelatedService(id, GetServiceName(id), GetServiceStartMode(id)));
        }

        private string GetServiceName(string id)
        {
            try
            {
                return (String)Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\services\" + id).GetValue("DisplayName");
            }
            catch
            {
                // No existe el servicio
            }

            return "";
        }

        internal Boolean Exists(String id)
        {
            return _services.Any(r => r.Id.CompareTo(id) == 0);
        }

        internal Boolean Remove(String id)
        {
            foreach (RelatedService r in _services)
                if (r.Id.CompareTo(id) == 0)
                {
                    _services.Remove(r);
                    return true;
                }

            return false;
        }

        internal List<RelatedService> Services
        {
            get
            {
                return _services;
            }

            set
            {
                _services.Clear();

                // Evitar duplicados
                foreach (RelatedService s in value)
                    Add(s);
            }
        }

        /// <summary>
        /// Aplica y prepara la configuración de cada servicio
        /// </summary>
        /// <returns>Verdadero si la configuración de aplicó, o Falso si ocurrió un error</returns>
        internal Boolean UpdateSystemConfiguration()
        {
            try
            {
                foreach (var r in _services)
                {
                    var s = new ServiceController(r.Id);

                    if (IsServiceValid(s))
                        SetServiceStartMode(r);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Comprueba si un ServiceController tiene un servicio válido relacionado
        /// </summary>
        /// <param name="s">Controlador de servicio a comprobar</param>
        /// <returns>Validez del servicio</returns>
        private static bool IsServiceValid(ServiceController s)
        {
            try
            {
                if (s.ServiceName.Length > 0)
                    return true;
            }
            catch
            {  }

            return false;
        }

        /// <summary>
        /// Obtiene el modo actual configurado en el registro del sistema de inicio de un servicio
        /// </summary>
        /// <param name="id">Identificador del servicio</param>
        /// <returns>El modo de inicio</returns>
        private static CustomStartMode GetServiceStartMode(String id)
        {
            try
            {
                switch (Convert.ToInt16(Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\services\" + id).GetValue("Start")))
                {
                    case 2:
                        return Convert.ToInt16(Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\services\" +
                            id).GetValue("DelayedAutostart", 0)) == 0 ? CustomStartMode.SystemAutomatic :
                            CustomStartMode.SystemAutomaticDelayed;
                    case 3:
                        return CustomStartMode.SystemManual;
                    case 4:
                        return CustomStartMode.SystemDisabled;
                }
            }
            catch
            {
                // No existe el servicio
            }

            return CustomStartMode.Unknown;
        }

        /// <summary>
        /// Cambia el modo de inicio de un servicio en el registro del sistema
        /// </summary>
        /// <param name="r">Objeto que incluye el modo de inicio actualizado</param>
        private void SetServiceStartMode(RelatedService r)
        {
            SetServiceStartMode(r.Id, r.Mode);
        }

        /// <summary>
        /// Cambia el modo de inicio de un servicio en el registro del sistema
        /// </summary>
        /// <param name="id">Identificador del servicio</param>
        /// <param name="mode">Nuevo modo a configurar</param>
        private static void SetServiceStartMode(String id, CustomStartMode mode)
        {
            try
            {
                Int16 modeValue = -1;
                Boolean specialDelayed = false;

                switch (mode)
                {
                    case CustomStartMode.StartOnly:
                    case CustomStartMode.StartStop:
                    case CustomStartMode.SystemManual:
                        modeValue = 3;
                        break;

                    case CustomStartMode.SystemAutomatic:
                        modeValue = 2;
                        break;

                    case CustomStartMode.SystemAutomaticDelayed:
                        modeValue = 2;
                        specialDelayed = true;
                        break;

                    case CustomStartMode.SystemDisabled:
                        modeValue = 4;
                        break;
                }

                if (modeValue != -1)
                {
                    Registry.LocalMachine.CreateSubKey(@"System\CurrentControlSet\services\" + id).SetValue("Start",
                        modeValue, RegistryValueKind.DWord);

                    Registry.LocalMachine.CreateSubKey(@"System\CurrentControlSet\services\" + id).SetValue("DelayedAutostart",
                        specialDelayed ? 1 : 0, RegistryValueKind.DWord);
                }
                else
                    throw new Exception("Wrong service startup mode");
            }
            catch
            {
                // No existe el servicio o no puede modificarse
                throw new Exception("Can't change service startup mode");
            }
        }

        /// <summary>
        /// Realiza las acciones de inicio de servicios según la configuración
        /// </summary>
        /// <param name="backgroundWorkerStart">Para registrar el progreso</param>
        internal void SystemStart(BackgroundWorker backgroundWorkerStart)
        {
            if (_services.Count <= 0) return;

            var processes = 0;
            double step = 100 / _services.Count;

            foreach (RelatedService r in _services)
            {
                var s = new ServiceController(r.Id);

                if (!IsServiceValid(s)) continue;

                if (r.Mode == CustomStartMode.StartStop || r.Mode == CustomStartMode.StartOnly)
                    if (s.Status != ServiceControllerStatus.Running)
                    {
                        backgroundWorkerStart.ReportProgress((int)Math.Ceiling((processes++ * step)));

                        s.Start();
                        s.WaitForStatus(ServiceControllerStatus.Running);
                    }
            }
        }

        /// <summary>
        /// Realiza las acciones de detención de servicios según la configuración
        /// </summary>
        /// <param name="backgroundWorkerStop">Para registrar el progreso</param>
        internal void SystemStop(BackgroundWorker backgroundWorkerStop)
        {
            if (_services.Count <= 0) return;

            int processes = 0;
            double step = 100 / _services.Count;

            foreach (var r in _services)
            {
                var s = new ServiceController(r.Id);

                if (!IsServiceValid(s)) continue;

                if (r.Mode == CustomStartMode.StartStop)
                    if (s.Status != ServiceControllerStatus.Stopped)
                    {
                        backgroundWorkerStop.ReportProgress((int)Math.Ceiling((processes++ * step)));

                        s.Stop();
                        s.WaitForStatus(ServiceControllerStatus.Stopped);
                    }
            }
        }
    }
}
