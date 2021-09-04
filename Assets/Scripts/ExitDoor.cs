using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Collider2D wallsCollider;
    [SerializeField] Collider2D insideCollider;
    [SerializeField] Collider2D enterCollider;

    private int origCullingMask;
    public bool hasEntered;

    private void Start()
    {
        origCullingMask = camera.cullingMask;
        gameObject.GetComponent<Collider2D>().enabled = false;
        hasEntered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasEntered)
        {
            hasEntered = true;
            camera.cullingMask = origCullingMask;
            wallsCollider.enabled = true;
            insideCollider.enabled = false;
            enterCollider.enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;            
        }            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;
    }
}
