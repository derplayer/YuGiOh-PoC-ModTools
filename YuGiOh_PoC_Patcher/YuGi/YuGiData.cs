using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public YuGiDataEntry FindFileByName(string name)
        {
            var res = Files.FirstOrDefault(datFile => datFile.FileName.Contains(name));
            return res;
        }

        public byte[] GetDataFromEntry(YuGiDataEntry entry)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(FileName, FileMode.Open)))
            {
                reader.BaseStream.Seek(entry.Offset, SeekOrigin.Begin);
                byte[] data = new byte[entry.Size];
                reader.Read(data, 0, data.Length);

                return data;
            }
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
