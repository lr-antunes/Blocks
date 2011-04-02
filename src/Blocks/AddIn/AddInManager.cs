using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;
using Rovidi.Blocks.Serialization;

namespace Rovidi.Blocks.AddIn
{
    public class AddInManager
    {
        public string AddInsPath { get; set; }
        public List<AddIn> LoadedAddIns { get; set; }



        // go to the local folder containing the addins (config?) and return a list of
        // objects representing them...
        public List<AddIn> GetLocalAddIns()
        {
            List<AddIn> LstAddIns = new List<AddIn>();

            if (!string.IsNullOrEmpty(AddInsPath) && Directory.Exists(AddInsPath))
            {
                DirectoryInfo folder = new DirectoryInfo(AddInsPath);

                foreach (var file in folder.GetFiles())
                {
                    using (TextReader reader = new StreamReader(file.FullName))
                    {
                        LstAddIns.Add(SerializationManager.XmlDeserialize<AddIn>(reader.ReadToEnd()));
                    }
                }
            }

            return LstAddIns;
        }


        //1. Get all the local addins in the addins folder...
        //2. Load each one into the manager...
        public void LoadAddIns()
        {
            if (this.GetLocalAddIns().Count > 0)
            {
                //TODO: Load the Addins...
            }
        }
    }
}
