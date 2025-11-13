using UnityEngine;

public class WalletManagerSingleton : MonoBehaviour
{
    // 🔹 Singleton Instance
    public static WalletManagerSingleton Instance { get; private set; }

    // 🔹 Biến lưu địa chỉ ví (có thể truy cập ở mọi nơi)
    public string walletAddress;

    private void Awake()
    {
        // Đảm bảo chỉ có 1 instance duy nhất
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Không bị destroy khi đổi scene
        DontDestroyOnLoad(gameObject);
    }

    // ✅ Hàm để gán ví (nếu cần gán runtime)
    public void SetWalletAddress(string address)
    {
        walletAddress = address;
        Debug.Log($"💼 Wallet set to: {walletAddress}");
    }

    // ✅ Hàm để lấy ví (nếu cần dùng ở script khác)
    public string GetWalletAddress()
    {
        return walletAddress;
    }
}
