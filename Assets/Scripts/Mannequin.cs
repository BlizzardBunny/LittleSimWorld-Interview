using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mannequin : Interactable
{
    public GameObject panel;

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        if(!panel.activeSelf)
        {
            panel.gameObject.SetActive(true);
        }  
        else
        {
            panel.gameObject.SetActive(false);
        }
    }
}
