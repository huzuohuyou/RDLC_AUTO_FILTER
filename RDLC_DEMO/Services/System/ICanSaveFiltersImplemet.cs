using InhospitalIndicators.Service.Entitys;
using InhospitalIndicators.Service.Services.System.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InhospitalIndicators.Service.Services.System
{

    public class ICanSaveFiltersImplemet : ICanSaveFilters
    {
        public void SaveFilter(List<FilterEntity> list,string fileName)
        {
            string FileFullName = $@"{AppDomain.CurrentDomain.BaseDirectory}App_Data\Filters\{fileName}";

            using (FileStream fileStream = File.Create(FileFullName))
            {
                byte[] bytes = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(list));
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }
        }
    }
}
