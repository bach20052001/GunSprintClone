using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    int numberOfCoins = 0;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        this.RegisterListener(GameEvent.OnBulletCollideEnemy, OnBulletCollideEnemyHandler);
    }

    public void OnBulletCollideEnemyHandler(object obj)
    {
        numberOfCoins += 100;
        coinText.text = numberOfCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
