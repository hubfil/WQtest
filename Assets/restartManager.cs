using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartManager : MonoBehaviour
{
    public Vector3 ballStartPosition;
    public GameObject ballObj;

    private void Start()
    {
        ballObj = FindObjectOfType<BallScript>().gameObject;
        ballStartPosition = ballObj.transform.position;

    }

    public void RestartGo()
    {
        ballObj.transform.position = ballStartPosition;
        ballObj.GetComponent<BallScript>().StartBall();
        SoundManager.PlaySound("boom7").SetVolume(0.1f);
    }
}
