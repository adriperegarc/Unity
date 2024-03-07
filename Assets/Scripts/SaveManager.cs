using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    private static string path = Application.persistentDataPath + "/save.dat";
    private static int[] record = {0,0,0,0,0};

    public static void SaveRecord(int pooints)
    {
        if (pooints > record[0])
        {
            record[1] = record[0];
            record[2] = record[1];
            record[3] = record[2];
            record[4] = record[3];
            record[0] = pooints;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            RecordData data = new RecordData(record);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else if(pooints > record[1] && pooints < record[0])
        {
            record[2] = record[1];
            record[3] = record[2];
            record[4] = record[3];
            record[1] = pooints;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            RecordData data = new RecordData(record);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else if (pooints > record[2] && pooints < record[1])
        {
            record[3] = record[2];
            record[4] = record[3];
            record[2] = pooints;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            RecordData data = new RecordData(record);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else if(pooints > record[3] && pooints < record[2])
        {
            record[4] = record[3];
            record[3] = pooints;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            RecordData data = new RecordData(record);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else if (pooints > record[4] && pooints < record[3])
        {
            record[4] = pooints;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            RecordData data = new RecordData(record);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static int[] LoadRecord()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RecordData data = formatter.Deserialize(stream) as RecordData;  // equivalent to (RecordData)formatter.Deserialize(stream);
            stream.Close();

            record = data.GetRecord();
        } else
        {
            record = null;
        }
        return record;
    }
}
