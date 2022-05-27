using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int highScore=0;
    public string playerName = "";
    public string currentPlayer = "";

    private void Awake()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
        LoadGame();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName = "";
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/Savefile.json", json);
    }

    public void LoadGame()
    {
        SaveData data = new SaveData();
        string path = Application.persistentDataPath+"/Savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            data.highScore = 0;
            data.playerName = "";
        }

        highScore = data.highScore;
        playerName = data.playerName;
    }
}
