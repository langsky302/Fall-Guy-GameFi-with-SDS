using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using GamePolygon;

[Serializable]
public class CharacterPostData
{
    public int Dummy;
    public int PunkGirl;
    public int Nerd;
    public int PunkBoy;
    public int Thief;
    public int Ninja;
}

[Serializable]
public class PlayerPostData
{
    public string wallet;
    public int level;
    public int gold;
    public CharacterPostData character;
}

public class SomniaDataPoster : MonoBehaviour
{
    // 🔹 Singleton instance
    public static SomniaDataPoster Instance { get; private set; }

    private const string postUrl = "https://somnia-data-stream-for-game-data-backend.onrender.com/api/publish";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PostPlayerData(string wallet)
    {
        StartCoroutine(PostData(wallet));
    }

    private IEnumerator PostData(string wallet)
    {
        int level = PlayerPrefs.GetInt("Level", 0);
        int gold = CoinManager.Instance.Coins;

        CharacterPostData character = new CharacterPostData
        {
            Dummy = PlayerPrefs.GetInt("DUMMY", 0),
            PunkGirl = PlayerPrefs.GetInt("PUNKGIRL", 0),
            Nerd = PlayerPrefs.GetInt("NERD", 0),
            PunkBoy = PlayerPrefs.GetInt("PUNKBOY", 0),
            Thief = PlayerPrefs.GetInt("THIEF", 0),
            Ninja = PlayerPrefs.GetInt("NINJA", 0)
        };

        PlayerPostData postData = new PlayerPostData
        {
            wallet = wallet,
            level = level,
            gold = gold,
            character = character
        };

        string json = JsonUtility.ToJson(postData);
        Debug.Log($"📤 Sending JSON:\n{json}");

        using (UnityWebRequest request = new UnityWebRequest(postUrl, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"✅ POST Success: {request.downloadHandler.text}");
            }
            else
            {
                Debug.LogError($"❌ POST Error: {request.responseCode} - {request.error}\n{request.downloadHandler.text}");
            }
        }
    }
}
