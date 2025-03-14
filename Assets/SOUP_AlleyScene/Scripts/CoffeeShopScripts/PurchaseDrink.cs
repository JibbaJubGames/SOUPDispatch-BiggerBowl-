using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseDrink : MonoBehaviour
{
    [SerializeField] public LeftRightChoices priceGrabber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttemptPurchaseDrink()
    {
        if (GameManager.moneyInWallet >= priceGrabber.ItemPrices[priceGrabber.CurrentSelectionNumber])
        {
            GameManager.moneyInWallet -= priceGrabber.ItemPrices[priceGrabber.CurrentSelectionNumber];
            if (GameManager.playerEnergy < 5)
            {
                GameManager.playerEnergy += priceGrabber.CoffeeEnergyBonus[priceGrabber.CurrentSelectionNumber];
                if (GameManager.playerEnergy > 5)
                {
                    GameManager.playerEnergy = 5;
                }
                Debug.Log($"Player now has {GameManager.playerEnergy} energy");
            }
            Debug.Log("Purchased drink. Money remaining: " + GameManager.moneyInWallet);
        }
        else Debug.Log("Insufficient Funds");
    }
}
