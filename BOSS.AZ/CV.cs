using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVnamespace
{
    public class CV
    {
        public string Speciality { get; set; }
        public string GraduatedSchool { get; set; }
        public string UnivercityScore { get; set; }
        public List<string> Skills { get; set; } = new List<string>();
        public DateTime StartWorkTime{ get; set; }
        public DateTime EndWorkTime { get; set; }
        public List<string> ForeignLanguages { get; set; }= new List<string>();
        public bool HaveHonorsDegree { get; set; }
        public string GitHubProfileLink { get; set; }
        public string LİNKEDİNProfileLink { get; set; }
    }
}
