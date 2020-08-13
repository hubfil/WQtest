using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficaltyManager : MonoBehaviour
{
    public static DifficaltyManager instance;
    void Start()
    {
        instance = this;
        playerScale = instance.playerObj.transform.localScale;
        ballScale = instance.ballObj.transform.localScale;

    }

    public GameObject playerObj, ballObj;
    public Vector3 playerScale, ballScale;
    public float speed;


    public static void dSet(int i)
    {
        instance.speed = (i + 0.6f) * 13;
        instance.ballObj.GetComponent<BallScript>().desiredSpeed = instance.speed;
        instance.ballObj.transform.localScale = instance.ballScale / (i/4f + 0.7f);
        instance.playerObj.transform.localScale = instance. playerScale / (i/5f + 0.2f);

    }

}
