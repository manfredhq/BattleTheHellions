using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingSystem
{
    public static void SaveHeroes(List<GameObject> heroes)
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            ALivings hero = heroes[i].GetComponent<ALivings>();
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/heroe" + i+".bif";
            Debug.Log(path);
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            HeroesData data = new HeroesData(hero);

            formatter.Serialize(stream, data);
            stream.Close();
        }

    }

    public static List<HeroesData> LoadHeroes()
    {
        List<HeroesData> dataToReturn = new List<HeroesData>();
        int i = 0;

        string path = Application.persistentDataPath + "/heroe" +i+".bif";

        while (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            HeroesData data = formatter.Deserialize(stream) as HeroesData;
            stream.Close();

            dataToReturn.Add(data);
            i++;
            path = Application.persistentDataPath + "/heroe" + i + ".bif";
        }
        return dataToReturn;
    }
}
