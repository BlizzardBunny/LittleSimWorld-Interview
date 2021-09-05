
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private Animator headAnim, bodyAnim;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        headAnim = GameObject.FindGameObjectWithTag("Head").GetComponent<Animator>();
        bodyAnim = GameObject.FindGameObjectWithTag("Body").GetComponent<Animator>();
        headAnim.SetInteger("Hair", OutfitTracker.GetHair());
        bodyAnim.SetInteger("Clothes", OutfitTracker.GetOutfit());
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
