using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace pegGame
{
    /*Serialization manager class which implements save and load the game*/
    [System.Serializable]
    public static class Serialization
    {
        public static void SaveBoard (string fileName ,object gameData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string folderPath = Application.persistentDataPath + "/saves";
            string path = Application.persistentDataPath + "/saves/" + fileName + ".peg";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            FileStream file = File.Create(path);
            formatter.Serialize(file, gameData);
            file.Close();
        }
        public static object LoadBoard (string path)
        {
            if(File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open);
                try
                {
                    object save = formatter.Deserialize(file);
                    file.Close();
                    return save;
                }
                catch
                {
                    Debug.LogError("File could not loaded ");
                    file.Close();
                    return null;
                }
            }
            else
            {
                Debug.LogError("File could not found in " + path);
                return null;
            }
        }
    }
}
