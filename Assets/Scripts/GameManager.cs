using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public int score;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI healthTmp;

    private void Awake()
    {
        instance = this;

        EventManager.StartListening("addCoins", OnAddCoins);
        EventManager.StartListening("onHealthChange", OnHealthChange);
    }

    void OnAddCoins(Dictionary<string, object> message)
    {
        score += (int)message["amount"];
        scoreTMP.text = $"Score: {score}";
    }

    public void OnHealthChange(Dictionary<string, object> message)
    {
        healthTmp.text = $"Health {(int)message["amount"]}";
    }

}
