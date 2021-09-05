using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollScript : MonoBehaviour
{
	public float scrollSpeed = 5f;
    public Transform movePoint;
    public TextMeshProUGUI playButton;
    private Vector2 startPoint;

    private void Start()
    {
        startPoint = transform.position;
        playButton = GameObject.FindGameObjectWithTag("NewGame").GetComponent<TextMeshProUGUI>();
        if (OutfitTracker.GetHasPlayed())
        {
            playButton.text = "CONTINUE";
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Time.deltaTime * scrollSpeed);
        if (transform.position == movePoint.position)
        {
            transform.position = startPoint;
        }
    }
}
