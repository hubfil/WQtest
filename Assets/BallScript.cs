using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

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
        StartBall();
    }

    public void StartBall()
    {
        Debug.Log(gameObject.name + " запущен");
        rb.isKinematic = true;
        rb.velocity = (startForceV3 * startForce);
        rb.isKinematic = false;

    }

    public void FixedUpdate()
    {
        UdjustSpeed();
    }

    private void Update()
    {
        //защита от застреваний
        timeToReturn += Time.deltaTime;
        if (timeToReturn > timeToReturnMax)
            rb.useGravity = true;
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
        }
        if (collision.transform.tag == "player")
        {
            timeToReturn = 0;
            rb.useGravity = false;
        }


        }

    }
