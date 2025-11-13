# 🎮 Fall Guy GameFi with Somnia Data Stream (SDS)

A Web3 mini-game built with **Unity Engine**, integrating **NFTs**, **Thirdweb Unity SDK**, and **Somnia Data Stream (SDS)** to deliver a fast, secure, and cheat-resistant GameFi experience.

This game stores **ALL gameplay data on-chain** — including level, gold, character, and upgrades — while maintaining the **speed and smoothness of a traditional database** thanks to Somnia SDS's high-performance architecture.

---

## 🌟 Key Features

### 🧩 On-Chain Gameplay Data
All crucial player data is written **on-chain** via Somnia SDS:

- Player wallet  
- Level  
- Gold  
- Characters owned  
- Selected character  
- Session data (optional)

This ensures transparency, data integrity, and full Web3 composability.

---

### 🛡️ Anti-Cheat With Somnia Data Stream
Somnia SDS ensures:

- Real-time signed data publishing  
- Server-validated data writes  
- Stream-based actions that prevent spoofing  
- No client-side forgery of scores or currency  

Players cannot fabricate level or gold values — everything must pass through your backend → SDS → Somnia chain.

---

### ⚡ Database-Level Performance
Despite being on-chain, Somnia Data Stream is engineered to feel like a **traditional database**:

- Ultra-fast writes  
- Reliable fetch operations  
- Low latency  
- High throughput  

Perfect for fast-paced Web3 games like **Fall Guy GameFi**.

---

## 🎮 Gameplay

Players must:

- **Avoid falling obstacles**
- **Dodge traps** while descending
- **Collect stars** to earn *Gold*
- **Use gold to purchase Characters (NFTs)**

The deeper you survive and the more stars you collect — the higher your rewards.

---

## 🧙‍♂️ NFT System (Thirdweb + Unity)
The game uses **Thirdweb Unity SDK** to:

- Display NFT characters  
- Buy & unlock characters  
- Store ownership data on chain  
- Load NFT metadata directly into Unity  

NFTs provide:

- Visual customization  
- Power-ups (optional)  
- Rarity-based gameplay depth  

---

## 🧱 Architecture Overview

```
Unity Game
   ↓ (POST)
Backend Server (Node.js / Express)
   ↓ (publish)
Somnia Data Stream SDK
   ↓
Somnia Dream Chain (on-chain storage)
```

- Unity never writes directly to blockchain → prevents cheating  
- Backend validates, signs, and publishes all data  
- SDS stores and retrieves information instantly  

---

## 🛠️ Tech Stack

| Component | Technology |
|----------|------------|
| Game Engine | **Unity** |
| Web3 Integration | **Thirdweb Unity SDK** |
| On-chain Data | **Somnia Data Stream SDK** |
| Blockchain | **Somnia Dream Chain (Testnet)** |
| Backend | Node.js + Express |
| Networking | UnityWebRequest |

---

## 📁 Data Stored On-Chain

| Field | Description |
|-------|-------------|
| `wallet` | Player wallet address |
| `level` | Highest level achieved |
| `gold` | Total gold earned |
| `character` | Currently selected character |
| `charactersOwned` | NFT characters purchased |
| `sessionScore` | (Optional) last session score |

---

## 🎮 How It Works

### 1️⃣ Player starts the game  
Unity loads on-chain data → character → level → gold.

### 2️⃣ Player plays & collects stars  
Unity → backend → SDS → Somnia chain.

### 3️⃣ Player spends gold  
Thirdweb handles NFT purchases.

### 4️⃣ Anti-Cheat  
Backend validates all gameplay actions.

---

## 🔗 Backend API (Example)

### `POST /api/publish`
Publish gameplay updates:

```json
{
  "wallet": "0xABC123...",
  "level": 12,
  "gold": 230,
  "character": "Ninja"
}
```

### `GET /api/data/:wallet`
Fetch player data.

---

## 🚀 Why Somnia SDS?

- On-chain transparency  
- No centralized DB required  
- Real-time event streams  
- Web3-grade security  
- Unity + mobile friendly  
- High performance and low latency  

Somnia SDS combines the reliability of a backend database with the trustlessness of blockchain.

---

## ✨ Author

**@Langsky302**  
Fall Guy GameFi with SDS  
Built with ❤️ using Unity, Thirdweb, and Somnia Data Stream
