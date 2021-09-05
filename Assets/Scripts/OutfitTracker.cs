using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OutfitTracker
{
    private static int headIndex = 1;
    private static int bodyIndex = 1;

    private static Vector2 playerLocation = new Vector2(0.51f,-0.51f);

    public static void SetHair(int counter)
    {
        headIndex = counter;
    }

    public static int GetHair()
    {
        return headIndex;
    }

    public static void SetOutfit(int counter)
    {
        bodyIndex = counter;
    }
    
    public static int GetOutfit()
    {
        return bodyIndex;
    }

    public static void SetPlayerLocation(Vector2 location)
    {
        playerLocation = location;
    }

    public static Vector2 GetPlayerLocation()
    {
        return playerLocation;
    }
}
