using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OutfitTracker
{
    private static bool hasPlayed = false;

    private static int cash = 200;
    private static int headIndex = 0;
    private static int bodyIndex = 0;

    private static List<int> hairInventory = new List<int>();
    private static List<int> clothesInventory = new List<int>();
    private static int[] prices = { 20, 10, 30, 40, 50, 60, 70 };

    public static void SetHair(int counter)
    {
        headIndex = counter;
        if(!hairInventory.Contains(counter))
        {
            hairInventory.Add(counter);
            Debug.Log("Added hair" + counter);
        }
    }

    public static int GetHair()
    {
        return headIndex;
    }

    public static void SetOutfit(int counter)
    {
        bodyIndex = counter;
        if (!clothesInventory.Contains(counter))
        {
            clothesInventory.Add(counter);
            Debug.Log("Added clothes" + counter);
        }
    }
    
    public static int GetOutfit()
    {
        return bodyIndex;
    }

    public static void SetCash(int expense)
    {
        cash -= expense;
    }

    public static int GetCash()
    {
        return cash;
    }

    public static int[] GetPrices()
    {
        return prices;
    }

    public static List<int> GetHairInventory()
    {
        return hairInventory;
    }

    public static List<int> GetClothesInventory()
    {
        return clothesInventory;
    }

    public static void SetHasPlayed(bool b)
    {
        hasPlayed = b;
    }

    public static bool GetHasPlayed()
    {
        return hasPlayed;
    }
}
