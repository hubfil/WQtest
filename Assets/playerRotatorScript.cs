using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotatorScript : MonoBehaviour
{

    public bool isLeft;
    public float rotateAmount;
    public GameObject playerObj;
    public Quaternion startRotation;
    public float duration;


    private void Start()
    {
        playerObj = gameObject.transform.parent.gameObject;
        startRotation = playerObj.transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            if (isLeft)
                playerObj.transform.Rotate(0, 0, - rotateAmount );
            if (!isLeft)
                playerObj.transform.Rotate(0, 0, rotateAmount);
            StartCoroutine(returnRotation());
        }
    }
    IEnumerator returnRotation()
    {
        yield return new WaitForSeconds(duration);
        playerObj.transform.rotation = startRotation;

    }
}
