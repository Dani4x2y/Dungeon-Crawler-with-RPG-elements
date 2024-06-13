using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; set; }

    // Player Health 
    public float currentHealth;
    public float maxHealth;

    // Player Calories
    public float currentCalories;
    public float maxCalories;

    float distanceTravelled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;

    // Player Exp
    public float currentExp;
    public float maxExp;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentCalories = maxCalories;
    }

    public void setHealth(float newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
    }

    public void setCalories(float newCalories)
    {
        currentCalories = Mathf.Clamp(newCalories, 0, maxCalories);
    }

    void Update()
    {
        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        if (distanceTravelled >= 5)
        {
            distanceTravelled = 0;
            currentCalories -= 1;
        }

        //Testing the health bar
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentHealth -= 10;
        }        
    }
}
