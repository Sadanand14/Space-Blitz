using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{

    [SerializeField] private float lightShipHealthPoints = 100.0f;
    [SerializeField] private float mediumShipHealthPoints = 150.0f;
    [SerializeField] private float heavyShipHealthPoints = 200.0f;
    public float maxHealthPoints;
    public float healthPoints;

    // Use this for initialization
    void Start()
    {
        if (this.tag == "Light")
        {
            healthPoints = lightShipHealthPoints;
            maxHealthPoints = lightShipHealthPoints;
        }
        else if (this.tag == "Medium")
        {
            healthPoints = mediumShipHealthPoints;
            maxHealthPoints = mediumShipHealthPoints;
        }
        else if (this.tag == "Heavy")
        {
            healthPoints = heavyShipHealthPoints;
            maxHealthPoints = heavyShipHealthPoints;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CurrentHealthPoints(float shipHealth)
    {
        healthPoints = Mathf.Clamp(shipHealth, 0f, maxHealthPoints);
    }

}