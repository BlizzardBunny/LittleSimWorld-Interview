using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;

    [Header("Sprites to Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    public TextMeshProUGUI price;

    private int currentOption = 0;
    private List<int> inventory;

    private void Start()
    {
        if (bodyPart.tag == "Head")
        {
            currentOption = OutfitTracker.GetHair();
            inventory = OutfitTracker.GetHairInventory();
        }
        else if (bodyPart.tag == "Body")
        {
            currentOption = OutfitTracker.GetOutfit();
            inventory = OutfitTracker.GetClothesInventory();
        }
        bodyPart.sprite = options[currentOption];
    }

    public void NextOption()
    {
        currentOption++;
        Debug.Log(currentOption);
        if (currentOption >= options.Count)
        {
            currentOption = 0;
        }
        bodyPart.sprite = options[currentOption];
        if(inventory.Contains(currentOption))
        {
            price.text = "0";
        }
        else
        {
            price.text = OutfitTracker.GetPrices()[currentOption].ToString();
        }
        
    }

    public void PreviousOption()
    {
        currentOption--;
        Debug.Log(currentOption);
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }
        bodyPart.sprite = options[currentOption];
        if (inventory.Contains(currentOption))
        {
            price.text = "0";
        }
        else
        {
            price.text = OutfitTracker.GetPrices()[currentOption].ToString();
        }
    }

    public void SetOutfit()
    {
        OutfitTracker.SetOutfit(currentOption);
    }

    public void SetHair()
    {
        OutfitTracker.SetHair(currentOption);
    }
}
