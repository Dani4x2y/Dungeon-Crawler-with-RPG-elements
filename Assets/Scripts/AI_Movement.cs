using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    Animator animatorComponent;
    public float speed = 0.2f;

    Vector3 lastPosition;
    float walkingDuration;
    public float walkingTimer;
    float waitingDuration;
    public float waitingTimer;

    int direction;
    public bool isMoving;

    void Start()
    {
        animatorComponent = GetComponent<Animator>();

        walkingDuration = Random.Range(3, 6);
        waitingDuration = Random.Range(5, 7);

        waitingTimer = waitingDuration;
        walkingTimer = walkingDuration;

        SetRandomDirection();
    }

    void Update()
    {
        if (isMoving)
        {
            walkingTimer -= Time.deltaTime;

            switch (direction)
            {
                case 0:
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += transform.forward * speed * Time.deltaTime;
                    break;
                case 1:
                    transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    transform.position += transform.forward * speed * Time.deltaTime;
                    break;
                case 2:
                    transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                    transform.position += transform.forward * speed * Time.deltaTime;
                    break;
                case 3:
                    transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                    transform.position += transform.forward * speed * Time.deltaTime;
                    break;
            }

            if (walkingTimer <= 0)
            {
                lastPosition = transform.position;
                isMoving = false;
                transform.position = lastPosition;
                waitingTimer = waitingDuration;
            }
        }
        else
        {
            waitingTimer -= Time.deltaTime;

            if (waitingTimer <= 0)
            {
                SetRandomDirection();
            }
        }
    }

    void SetRandomDirection()
    {
        direction = Random.Range(0, 4);
        isMoving = true;
        walkingTimer = walkingDuration;
    }
}
