using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NeuroNet.Core.Neuronets;
using NeuroNet.Core.Common;

namespace NeuroNet.Core.Serialization
{
    /// <summary>
    /// This class was created for serialization neural networks with additional information
    /// </summary>
    [Serializable]
    public class NeuronetWithInformation
    {
        public Neuronet Neuronet;

        public Size ImageSize;

        public TimeSpan TrainingTime;

        public IDictionary<string, string> AdditionalInformation;

        public void AddTextAttribute(string key, string value)
        {
            if (AdditionalInformation == null)
                AdditionalInformation = new Dictionary<string, string>();

            AdditionalInformation[key] = value;
        }

        /// <summary>
        /// Binary deserialization from file stream
        /// </summary>
        /// <param name="path"></param>
        /// <returns>File path</returns>
        public static NeuronetWithInformation Load(string path)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var bFormatter = new BinaryFormatter();

                var neuronetWithInfo = (NeuronetWithInformation) bFormatter.Deserialize(stream);

                GC.Collect();

                return neuronetWithInfo;
            }
        }

        /// <summary>
        /// Binary serizlization to file stream
        /// </summary>
        /// <param name="path">File path</param>
        public void Save(string path)
        {
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                var bFormatter = new BinaryFormatter();

                bFormatter.Serialize(stream, this);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}x{1} {2} (training time: {3:hh\\:mm\\:ss})",
                ImageSize.Width, ImageSize.Height, Neuronet, TrainingTime);
        }
    }
}