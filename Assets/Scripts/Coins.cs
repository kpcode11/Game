// using UnityEngine;

// public class Coin : MonoBehaviour
// {
//     [SerializeField] private int value;
//     private bool hasTriggerd;
//     private CoinManager coinManager;

//     private void Start()
//     {
//         coinManager = CoinManager.instance;
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Player") && !hasTriggerd)
//         {
//             hasTriggerd = true;
//             coinManager.ChangeCoins(value);
//             Destroy(gameObject);
//         }
//     }
// }
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = CoinManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            if (coinManager != null)
            {
                coinManager.ChangeCoins(value);
            }
            Destroy(gameObject);
        }
    }
}
