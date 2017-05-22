using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi
{
    /// <summary>
    /// [WIP] YuGi .dat file
    /// </summary>
    public class YuGiData
    {
        public string FileName { get; set; }
        public List<YuGiDataEntry> Files { get; set; } = new List<YuGiDataEntry>();


        public YuGiData(string fileName)
        {
            FileName = fileName;
        }


        public bool LoadFileList()
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(FileName, FileMode.Open)))
            {
                string header = Encoding.ASCII.GetString(reader.ReadBytes(8));
                if (header != "KCEJYUGI") return false;

                int fileCount = reader.ReadInt32();
                for (int i = 0; i < fileCount; i++)
                {
                    byte[] fileEntryBytes = new byte[268];
                    reader.Read(fileEntryBytes, 0, fileEntryBytes.Length);
                    Files.Add(new YuGiDataEntry(fileEntryBytes));
                }
            }
            return true;
        }

    }
}
