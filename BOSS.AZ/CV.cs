using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVnamespace
{
    public class WorkTimes
    {
        public string CompanyName { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime EndWorkTime { get; set; }

    }
    public class CV
    {
        public string Speciality { get; set; }
        public string GraduatedUniversity { get; set; }
        public double UnivercityScore { get; set; }
        public List<string> Skills { get; set; } = new List<string>();
        public List<string> ForeignLanguages { get; set; }= new List<string>();
        public List<WorkTimes> WorkedCompanies { get; set; } = new List<WorkTimes>();
        public bool HaveHonorsDegree { get; set; }
        public string GitHubProfileLink { get; set; }
        public string LİNKEDİNProfileLink { get; set; }
    }
}
