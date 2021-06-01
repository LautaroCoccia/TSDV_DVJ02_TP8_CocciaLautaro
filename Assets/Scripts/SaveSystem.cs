using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{

    static string path = Application.dataPath + "/Highscore.dat";

    public static void CreateHighscoreFile()
    {
        if(!File.Exists(path))
        {
            Debug.Log("Holaaaaa");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, 0);
        }
    }
    public static void SaveHighscore(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;
        if(File.Exists(path))
        {
            stream = new FileStream(path, FileMode.OpenOrCreate);
            int auxToReturn = (int)formatter.Deserialize(stream);
            stream.Close();
            if (auxToReturn<score)
            {
                stream = new FileStream(path, FileMode.OpenOrCreate);
                formatter.Serialize(stream, score);
                stream.Close();

            }
        }
    }
    public static int LoadHighscoreFile()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            int auxToReturn = (int)formatter.Deserialize(stream);
            stream.Close();
            return auxToReturn;
        }
        else
            return 0;
    }
}
