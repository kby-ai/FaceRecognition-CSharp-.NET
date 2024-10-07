using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition
{
    public class Person
    {
        public string Name { get; set; }
        public byte[] FaceJpg { get; set; }
        public byte[] Templates { get; set; }

        public Person(string name, byte[] faceJpg, byte[] templates)
        {
            Name = name;
            FaceJpg = faceJpg;
            Templates = templates;
        }

        // Convert from a map (e.g., Dictionary<string, object>)
        public static Person FromDictionary(Dictionary<string, object> data)
        {
            return new Person(
                (string)data["name"],
                (byte[])data["faceJpg"],
                (byte[])data["templates"]
            );
        }

        // Convert to a map (Dictionary)
        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
        {
            { "name", Name },
            { "faceJpg", FaceJpg },
            { "templates", Templates }
        };
        }
    }

}
