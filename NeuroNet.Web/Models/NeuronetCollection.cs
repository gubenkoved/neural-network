using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NeuroNet.Core.Neuronets;
using NeuroNet.Core.Serialization;
using System.Configuration;

namespace NeuroNet.Web.Models
{
    public class NeuronetCollection
    {
        public static bool IsLoading;
        public static IDictionary<Guid, NeuronetWithInformation> Neuronets = new Dictionary<Guid, NeuronetWithInformation>();

        public static Task Load()
        {
            string neuronetsPath = ConfigurationManager.AppSettings["NeuronetsLocation"];

            return Load(neuronetsPath);
        }

        public static Task Load(string directory)
        {
            IsLoading = true;

            var dirInfo = new DirectoryInfo(directory);

            List<Task> loadTasks = new List<Task>();

            foreach (var neuronetFile in dirInfo.GetFiles())
            {
                string netPath = neuronetFile.FullName;

                loadTasks.Add(Task.Factory.StartNew(() =>
                {
                    Neuronets[Guid.NewGuid()] = NeuronetWithInformation.Load(netPath);
                }, TaskCreationOptions.LongRunning));
            }

            return Task.WhenAll(loadTasks.ToArray())
                .ContinueWith(t => IsLoading = false);
        }
    }
}