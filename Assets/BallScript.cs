using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public bool isStarted = false;

    public Vector3 startPosition;
    public Vector3 startForceV3;
    public float startForce;
    public float desiredSpeed;
    public Rigidbody rb;
    [Header("защита от застреваний")]
    public float timeToReturn;
    public float timeToReturnMax;



    void Start()
    {
        startPosition = transform.position;
    }

    public void StartBall()
    {
        Debug.Log(gameObject.name + " запущен");
        rb.isKinematic = true;
        rb.velocity = (startForceV3 * startForce);
        rb.isKinematic = false;
        SoundManager.PlaySound("boom4").SetVolume(0.8f);
        isStarted = true;
    }

    public void FixedUpdate()
    {
        if (isStarted)
        UdjustSpeed();
    }

    private void Update()
    {
        if (isStarted)
        {
            //защита от застреваний
            timeToReturn += Time.deltaTime;
            if (timeToReturn > timeToReturnMax)
            {
                rb.useGravity = true;
            }

        }
    }

    public void UdjustSpeed()
    {
        //если слишком быстро или медленно летит
        float adjustCoef;
        adjustCoef =  desiredSpeed / rb.velocity.magnitude;
        rb.velocity = rb.velocity * adjustCoef;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "brick")
        {
            Destroy(collision.gameObject, 0.1f);
            SoundManager.PlaySound("boom2").SetVolume(0.5f);
            SoundManager.PlaySoundWithDelay("boom1", 0.1f);
        }
        else if (collision.transform.tag == "player")
        {
            SoundManager.PlaySound("boom3").SetVolume(0.8f);

            timeToReturn = 0;
            rb.useGravity = false;
        }
        else
        {
            SoundManager.PlaySound("boom7").SetVolume(0.1f);

        }

    }

    }
