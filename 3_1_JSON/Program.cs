using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace _3_1_JSON
{


    class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return Artist + " " + Title + " " + Length.ToString() + " seconds long";
        }
        public MusicTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MusicTrack track = new MusicTrack("Robert Miles", "My Way", 150);

            string json = JsonConvert.SerializeObject(track);

            Console.Write("JSON: ");
            Console.WriteLine(json);

            MusicTrack trackRead = JsonConvert.DeserializeObject<MusicTrack>(json);

            Console.Write("Read back: ");
            Console.WriteLine(trackRead);

            List<MusicTrack> album = new List<MusicTrack>();

            string[] trackNames = new[] { "my way", "Your way", "wrong way", "no way" };

            int snurre = 1;

            foreach (string trackName in trackNames)
            {
                MusicTrack newTrack = new MusicTrack("Robban Mile", trackName, 150*snurre++);
                album.Add(newTrack);
            }

            string jsonArray = JsonConvert.SerializeObject(album);
            Console.Write("JSON: ");
            Console.WriteLine(jsonArray);

            List<MusicTrack> albumRead = JsonConvert.DeserializeObject<List<MusicTrack>>(jsonArray);
            Console.WriteLine("");
            Console.WriteLine("");

            foreach ( MusicTrack readTrack in albumRead)
            {
                Console.WriteLine(readTrack);
            }


            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}

