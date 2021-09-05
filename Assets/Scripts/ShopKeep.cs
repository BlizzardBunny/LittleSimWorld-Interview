using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopKeep : Interactable
{
    public GameObject panel;
    private GameObject player;

    private void Start()
    {
        panel.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {
        if(!panel.activeSelf)
        {
            panel.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Shop");
        }        
    }
}
