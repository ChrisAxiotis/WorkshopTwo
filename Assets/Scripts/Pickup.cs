using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventManager.TriggerEvent("addCoins", new Dictionary<string, object> { { "amount", 1 } });

            Destroy(gameObject);
        }
    }

}
