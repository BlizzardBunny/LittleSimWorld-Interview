using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolverScript : MonoBehaviour
{    
    private Animator headAnim, bodyAnim;
    // Start is called before the first frame update
    void Start()
    {
        headAnim = GameObject.FindGameObjectWithTag("Head").GetComponent<Animator>();
        bodyAnim = GameObject.FindGameObjectWithTag("Body").GetComponent<Animator>();
        headAnim.SetInteger("Hair", OutfitTracker.GetHair());
        bodyAnim.SetInteger("Clothes", OutfitTracker.GetOutfit());
        switch (OutfitTracker.GetHair())
        {
            case 0:
                headAnim.Play("Downward1");
                break;
            case 1:
                headAnim.Play("Downward0");
                break;
            case 2:
                headAnim.Play("Downward2");
                break;
            case 3:
                headAnim.Play("Downward3");
                break;
            case 4:
                headAnim.Play("Downward4");
                break;
            case 5:
                headAnim.Play("Downward5");
                break;
            case 6:
                headAnim.Play("Downward6");
                break;
        }
        switch (OutfitTracker.GetOutfit())
        {
            case 0:
                bodyAnim.Play("Downward1");
                break;
            case 1:
                bodyAnim.Play("Downward0");
                break;
            case 2:
                bodyAnim.Play("Downward2");
                break;
            case 3:
                bodyAnim.Play("Downward3");
                break;
            case 4:
                bodyAnim.Play("Downward4");
                break;
            case 5:
                bodyAnim.Play("Downward5");
                break;
            case 6:
                bodyAnim.Play("Downward6");
                break;
        }
    }
}
