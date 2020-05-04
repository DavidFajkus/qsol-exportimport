using Microsoft.Deployment.Compression.Cab;
using System;
using System.Collections.Generic;
using System.IO;

namespace qsol.exportimport.Helpers
{
    public class MSCFExtractor
    {
        private readonly string ExtractorDirectory = "MSCFExtractor";
        private readonly string ExtractorDirectoryData = "Data";
        private readonly string ExtractorFile = "TMP.cab";
        private string ExtractorDataPath;
        private string ExtractorPath;

        public MSCFExtractor()
        {
            ExtractorPath = $"{Path.GetTempPath()}{ExtractorDirectory}\\";
            ExtractorDataPath = $"{ExtractorPath}{ExtractorDirectoryData}\\";
            
            if (!Directory.Exists(ExtractorDataPath))
            {
                try
                {
                    Directory.CreateDirectory(ExtractorDataPath);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Directory not create.");
                    throw e;
                }
            }            
        }        

        public List<byte[]> UnpackFile(byte[] data)
        {
            List<byte[]> list = new List<byte[]>();

            if (data == null)
            {
                list.Add(data);
                return list;
            }

            if (data.LongLength < 4)
            {
                list.Add(data);
                return list;
            }
            //MSCF
            if (!(data[0] == 77 && data[1] == 83 && data[2] == 67 && data[3] == 70))
            {
                list.Add(data);
                return list;
            }

            var fileName = $"{ExtractorPath}{ExtractorFile}";
            File.WriteAllBytes(fileName, data);
            CabInfo cab = new CabInfo(fileName);
            try
            {
                cab.Unpack(ExtractorDataPath);
                DirectoryInfo d = new DirectoryInfo(ExtractorDataPath);
                var files = d.GetFiles("*.*");
                foreach (var file in files)
                {
                    list.Add(File.ReadAllBytes($@"{ExtractorDataPath}\{file.Name}"));
                    File.Delete($@"{ExtractorDataPath}\{file.Name}");
                }

                File.Delete(fileName);
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }
    }
}
