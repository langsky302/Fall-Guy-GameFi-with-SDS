using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GamePolygon;

// Data model cho JSON
[Serializable]
public class CharacterData
{
    public int Dummy;
    public int PunkGirl;
    public int Nerd;
    public int PunkBoy;
    public int Thief;
    public int Ninja;
}

[Serializable]
public class PlayerData
{
    public string wallet;
    public int level;
    public int gold;
    public CharacterData characterData;
}

[Serializable]
public class ApiResponse
{
    public int totalPlayers;
    public List<PlayerData> players;
}

public class SomniaDataFetcher : MonoBehaviour
{
    private const string apiUrl = "https://somnia-data-stream-for-game-data-backend.onrender.com/api/data";

    // 👉 Hàm public để gọi với địa chỉ ví cụ thể
    public void FetchPlayerData(string walletAddress)
    {
        StartCoroutine(GetData(walletAddress));
    }

    private IEnumerator GetData(string walletAddress)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                try
                {
                    // Parse JSON
                    ApiResponse response = JsonUtility.FromJson<ApiResponse>(request.downloadHandler.text);

                    // Lọc theo ví
                    List<PlayerData> filtered = response.players.FindAll(p =>
                        string.Equals(p.wallet, walletAddress, StringComparison.OrdinalIgnoreCase));

                    if (filtered.Count > 0)
                    {
                        // Lấy bản ghi mới nhất (cuối danh sách)
                        PlayerData latest = filtered[filtered.Count - 1];

                        Debug.Log($"Wallet: {latest.wallet}");
                        Debug.Log($"Level: {latest.level}");
                        PlayerPrefs.SetInt("Level", latest.level);
                        Debug.Log($"Gold: {latest.gold}");
                        CoinManager.Instance.Coins = latest.gold;

                        Debug.Log("Character Data:");
                        Debug.Log($"Dummy: {latest.characterData.Dummy}");
                        PlayerPrefs.SetInt("DUMMY", latest.characterData.Dummy);
                        Debug.Log($"PunkGirl: {latest.characterData.PunkGirl}");
                        PlayerPrefs.SetInt("PUNKGIRL", latest.characterData.PunkGirl);
                        Debug.Log($"Nerd: {latest.characterData.Nerd}");
                        PlayerPrefs.SetInt("NERD", latest.characterData.Nerd);
                        Debug.Log($"PunkBoy: {latest.characterData.PunkBoy}");
                        PlayerPrefs.SetInt("PUNKBOY", latest.characterData.PunkBoy);
                        Debug.Log($"Thief: {latest.characterData.Thief}");
                        PlayerPrefs.SetInt("THIEF", latest.characterData.Thief);
                        Debug.Log($"Ninja: {latest.characterData.Ninja}");
                        PlayerPrefs.SetInt("NINJA", latest.characterData.Ninja);
                        PlayerPrefs.Save();
                    }
                    else
                    {
                        Debug.LogWarning($"No data found for wallet: {walletAddress}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error parsing JSON: {ex.Message}");
                }
            }
            else
            {
                Debug.LogError($"Request failed: {request.error}");
            }
        }
    }

    //// Test trong Unity bằng cách gọi trong Start()
    //private void Start()
    //{
    //    // 👉 Truyền ví bạn muốn test ở đây
    //    string testWallet = "0xA24d7ECD79B25CE6C66f1Db9e06b66Bd11632E00";
    //    FetchPlayerData(testWallet);
    //}
}
