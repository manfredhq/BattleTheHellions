using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingSystem
{

    public static void Save(List<GameObject> heroes, List<ARelics> relics)
    {
        CleanDirectory();
        SaveHeroes(heroes);
        SaveRelics(relics);
    }

    private static void CleanDirectory()
    {
        var hi = Directory.GetFiles(Application.persistentDataPath);

        for (int i = 0; i < hi.Length; i++)
        {
            File.Delete(hi[i]);
        }
    }

    public static void SaveHeroes(List<GameObject> heroes)
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            
            ALivings hero = heroes[i].GetComponent<ALivings>();
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/heroe" + i+".bif";
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            HeroesData data = new HeroesData(hero);
            Debug.Log(path);
            formatter.Serialize(stream, data);
            stream.Close();
        }

    }

    public static void SaveRelics(List<ARelics> relics)
    {
        for (int i = 0; i < relics.Count; i++)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/relic" + i + ".bif";
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            RelicStorage data = new RelicStorage(relics[i].id);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static List<int> LoadRelics()
    {
        List<int> dataToReturn = new List<int>();

        int i = 0;
        string path = Application.persistentDataPath + "/relic" + i + ".bif";

        while (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RelicStorage data = formatter.Deserialize(stream) as RelicStorage;
            stream.Close();

            dataToReturn.Add(data.id);
            i++;
            path = Application.persistentDataPath + "/relic" + i + ".bif";
        }
        return dataToReturn;
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
