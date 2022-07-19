using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseNamespace;
namespace FileHelperNamespace
{
    public class FileHelper
    {
        public static void WriteToJson(Database database)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("database.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, database);
                }
            }
        }

        public static Database ReadFromJson()
        {
            Database resultDatabase = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("database.json"))
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
