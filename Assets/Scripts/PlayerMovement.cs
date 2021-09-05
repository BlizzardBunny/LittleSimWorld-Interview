using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask obstacles;
    [SerializeField] List<GameObject> panels;

    private Vector2 direction;
    private Animator headAnim, bodyAnim;

    private void Start()
    {
        movePoint.parent = null;
        direction = Vector2.down;
        headAnim = GameObject.FindGameObjectWithTag("Head").GetComponent<Animator>();
        bodyAnim = GameObject.FindGameObjectWithTag("Body").GetComponent<Animator>();
        if (panels.Count > 0)
        {
            foreach (GameObject p in panels)
            {
                p.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.4f, obstacles))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.4f, obstacles))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            headAnim.SetBool("RightBool", false);
            bodyAnim.SetBool("RightBool", false);
            headAnim.SetBool("LeftBool", false);
            bodyAnim.SetBool("LeftBool", false);
            headAnim.SetBool("UpBool", false);
            bodyAnim.SetBool("UpBool", false);
            headAnim.SetBool("DownBool", false);     
            bodyAnim.SetBool("DownBool", false);
        }
        if (Input.GetAxisRaw("Horizontal") > 0f)//right
        {
            headAnim.SetBool("RightBool", true);
            bodyAnim.SetBool("RightBool", true);
            direction = Vector2.right;
            if(panels.Count > 0)
            {
                foreach(GameObject p in panels)
                {
                    p.gameObject.SetActive(false);
                }
            }            
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)//left
        {
            headAnim.SetBool("LeftBool", true);
            bodyAnim.SetBool("LeftBool", true);
            direction = Vector2.left;
            if (panels.Count > 0)
            {
                foreach (GameObject p in panels)
                {
                    p.gameObject.SetActive(false);
                }
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0f)//up
        {
            headAnim.SetBool("UpBool", true);
            bodyAnim.SetBool("UpBool", true);
            direction = Vector2.up;
            if (panels.Count > 0)
            {
                foreach (GameObject p in panels)
                {
                    p.gameObject.SetActive(false);
                }
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)//down
        {
            headAnim.SetBool("DownBool", true);
            bodyAnim.SetBool("DownBool", true);
            direction = Vector2.down;
            if (panels.Count > 0)
            {
                foreach (GameObject p in panels)
                {
                    p.gameObject.SetActive(false);
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Interact();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    private void Interact()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, 1f);
        if (hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
}
