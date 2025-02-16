// using UnityEngine;
// using TMPro;

// public class CoinManager : MonoBehaviour
// {
//     public static CoinManager instance;
//     private int coins;
//     [SerializeField] private TMP_Text coinsDisplay;

//     private void Awake()
//     {
//         if (!instance)
//         {
//             instance = this;
//         }
//     }

//     private void OnGUI()
//     {
//         coinsDisplay.text = coins.ToString();
//     }

//     public void ChangeCoins(int amount)
//     {
//         coins += amount;
//     }
// }





// using UnityEngine;
// using TMPro;

// public class CoinManager : MonoBehaviour
// {
//     public static CoinManager instance;
//     private int coins;
//     [SerializeField] private TMP_Text coinsDisplay;

//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//             return;
//         }

//         LoadCoins();
//         UpdateCoinUI();
//     }

//     private void UpdateCoinUI()
//     {
//         if (coinsDisplay != null)
//         {
//             coinsDisplay.text = coins.ToString();
//         }
//     }

//     public void ChangeCoins(int amount)
//     {
//         coins += amount;
//         SaveCoins();
//         UpdateCoinUI();
//     }

//     private void SaveCoins()
//     {
//         PlayerPrefs.SetInt("Coins", coins);
//         PlayerPrefs.Save();
//     }

//     private void LoadCoins()
//     {
//         coins = PlayerPrefs.GetInt("Coins", 0);
//     }
// }

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coins;
    private TMP_Text coinsDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins(); // Ensures coins persist across all levels
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Invoke("FindCoinTextUI", 0.5f); // Delayed call to ensure UI loads properly
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Invoke("FindCoinTextUI", 0.5f); // Ensures UI is found after switching levels
    }

    private void FindCoinTextUI()
    {
        coinsDisplay = GameObject.FindGameObjectWithTag("Coins")?.GetComponent<TMP_Text>();
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinsDisplay != null)
        {
            coinsDisplay.text = coins.ToString();
        }
        else
        {
            Debug.LogWarning("Coin UI text not found in scene!");
        }
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
        SaveCoins();
        UpdateCoinUI();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
    }
}




