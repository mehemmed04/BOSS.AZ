using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseNamespace;
using UserNamespace;
namespace FileHelperNamespace
{
    public class FileHelper
    {
        public static void WriteToJson(Database database)
        {
            var serializer = new JsonSerializer();
            string CURRENT_PATH = Directory.GetCurrentDirectory();

            DirectoryInfo dir = new DirectoryInfo(CURRENT_PATH);
             CURRENT_PATH = dir.Parent.Parent.FullName;

            using (var sw = new StreamWriter(CURRENT_PATH + "/database.json"))
            {

                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    serializer.Serialize(jw, database,typeof(object));
                }
            }
        }

        public static Database ReadFromJson()
        {
            Database resultDatabase = null;
            var serializer = new JsonSerializer();
            string CURRENT_PATH = Directory.GetCurrentDirectory();

            DirectoryInfo dir = new DirectoryInfo(CURRENT_PATH);
             CURRENT_PATH = dir.Parent.Parent.FullName;

            using (var sr = new StreamReader(CURRENT_PATH + "/database.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    resultDatabase = serializer.Deserialize<Database>(jr);
                }
            }
            return resultDatabase;
        }

    }
}
