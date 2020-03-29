using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Infra.Log;
using BusquedaVehiculos.Interfaces.Providers;
using BusquedaVehiculos.Interfaces.SignalR;
using BusquedaVehiculos.Providers.SignalR;
using BusquedaVehiculos.Web.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BusquedaVehiculos.Web.Infra
{
    public static class BusquedaJobManager
    {
        #region Atributos privados
        private static ConcurrentDictionary<String, BusquedaJob> RunningJobs = new ConcurrentDictionary<String, BusquedaJob>();
        private static IHubContext Hub { get; set; }
        #endregion

        #region Constructor estático
        static BusquedaJobManager()
        {
            Hub = GlobalHost.ConnectionManager.GetHubContext<BusquedaProgressHub>();
        }
        #endregion

        #region Interfaz pública
        public static BusquedaJob CreateJob(BusquedaRequestDTO request, IProviderManagerSignalR providerManager)
        {
            var job = new BusquedaJob(request, providerManager);
            RunningJobs.TryAdd(job.Id, job);
            return job;
        }

        public static void StartJob(String jobId)
        {
            BusquedaJob job;
            if (RunningJobs.TryGetValue(jobId, out job))
            {
                BroadcastJobStatus(job);
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        job.Run();
                    }
                    catch (Exception e)
                    {
                        //AppLog.LogMessage("BusquedaJobManager_StartJob_exception", BusquedaVehiculos.Infra.Serialization.Serializer.Serialize(e));
                        //AppLog.LogMessage("BusquedaJobManager_StartJob_exception", e.Message);
                        //BroadcastError(job, e);
                    }
                    finally
                    {
                        job.Complete();
                        BusquedaJob jout;
                        RunningJobs.TryRemove(job.Id, out jout);
                    }
                },
                TaskCreationOptions.LongRunning);
            }
        }
        #endregion

        #region Helpers
        private static void BroadcastJobStatus(BusquedaJob job)
        {
            job.ProgressChanged += HandleJobProgressChanged;
            job.Completed += HandleJobCompleted;
        }

        private static void BroadcastError(BusquedaJob job, Exception e)
        {
            Hub.Clients.Group(job.Id).error(e);
        }

        private static void HandleJobCompleted(Object sender, IProgressEventArgs e)
        {
            var job = (BusquedaJob)sender;
            Hub.Clients.Group(job.Id).jobCompleted(job.Id);
            job.ProgressChanged -= HandleJobProgressChanged;
            job.Completed -= HandleJobCompleted;
        }

        private static void HandleJobProgressChanged(Object sender, IProgressEventArgs e)
        {
            var job = (BusquedaJob)sender;
            Hub.Clients.Group(job.Id).ProgressChanged(e.Message, e.Progress);
        }
        #endregion
    }
}