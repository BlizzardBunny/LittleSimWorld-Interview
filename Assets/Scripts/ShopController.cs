using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject notEnough;
    public Button finishButton;
    public TextMeshProUGUI coins, total, hair, clothes;
    private int hPrice, cPrice, tPrice;
    // Start is called before the first frame update
    void Start()
    {
        coins.text = OutfitTracker.GetCash().ToString();
        notEnough.gameObject.SetActive(false);
        OutfitTracker.SetHair(OutfitTracker.GetHair());
        OutfitTracker.SetOutfit(OutfitTracker.GetOutfit());
    }

    // Update is called once per frame
    void Update()
    {
        hPrice = int.Parse(hair.text);
        cPrice = int.Parse(clothes.text);
        tPrice = hPrice + cPrice;
        total.text = tPrice.ToString();

        if(int.Parse(coins.text) < tPrice)
        {
            finishButton.interactable = false;
            notEnough.SetActive(true);
        }
        else
        {
            finishButton.interactable = true;
            notEnough.SetActive(false);
        }
    }

    public void Buy()
    {
        OutfitTracker.SetCash(tPrice);
    }

    public void Exit()
    {
        SceneManager.LoadScene("World");
    }
}
