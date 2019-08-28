using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Tetris
{
    static class Leaderboard
    {
        static Leaderboard()
        {
            Deserialize();
        }

        private readonly static string FileLocation = "../../leaderboard.lbd";

        public static Dictionary<string, int> LeaderStored { get; set; }


        private static Dictionary<string, int> leaderStored = new Dictionary<string, int>();
        private static void Serialize()
        {
            File.WriteAllText(FileLocation, JsonConvert.SerializeObject(LeaderStored));
        }

        private static void Deserialize()
        {
            LeaderStored = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(FileLocation));
        }
    }
}
