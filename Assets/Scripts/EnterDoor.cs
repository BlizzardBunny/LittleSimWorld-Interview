using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Collider2D wallsCollider;
    [SerializeField] Collider2D insideCollider;
    [SerializeField] Collider2D exitCollider;

    public bool hasEntered;
    private void Start()
    {        
        insideCollider.enabled = false;
        hasEntered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasEntered)
        {
            camera.cullingMask = (1 << LayerMask.NameToLayer("Inside")) | (1 << LayerMask.NameToLayer("Default"));
            wallsCollider.enabled = false;
            insideCollider.enabled = true;
            exitCollider.enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;
    }
}
