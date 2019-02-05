using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float shipVelocity;
    public float currentHealthPoints;
    public float currenMaxHealthPoints;
    public UIManager shipIndex;
    private SpaceshipController shipController;
    private HealthPoints healthPoints;

    [SerializeField] private Camera currentCamera;

    [SerializeField] private float lightShipDeceleration = 50.0f;
    [SerializeField] private float mediumShipDeceleration = 30.0f;
    [SerializeField] private float heavyShipDeceleration = 10.0f;

    [SerializeField] private float lightShipDemage = 30.0f;
    [SerializeField] private float mediumShipDemage = 20.0f;
    [SerializeField] private float heavyShipDemage = 10.0f;

    public SpaceshipController[] shipControllerList;
    public HealthPoints[] shipHealthPointsList;
    public HealthPointsMovement healthMovement;


    // Use this for initialization
    void Start()
    {

        shipController = shipControllerList[shipIndex.CurrentShipIndex].GetComponent<SpaceshipController>();
        healthPoints = shipHealthPointsList[shipIndex.CurrentShipIndex].GetComponent<HealthPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        shipVelocity = shipController.CurrentSpeed;

        currentHealthPoints = healthPoints.healthPoints;

        currenMaxHealthPoints = healthPoints.maxHealthPoints;
    }
    public void ShipDeceleration(Collider ship)
    {


        if (ship.tag == "Light")
        {
            shipVelocity -= lightShipDeceleration;
        }
        else if (ship.tag == "Medium")
        {
            shipVelocity -= mediumShipDeceleration;
        }
        else if (ship.tag == "Heavy")
        {
            shipVelocity -= heavyShipDeceleration;
        }
        ChangeShipVelocity();
    }
    void ChangeShipVelocity()
    {

        shipController.ChangeSpeed(shipVelocity);

    }

    public void ShipDemage(Collider ship)
    {
        if (ship.tag == "Light")
        {
            currentHealthPoints -= lightShipDemage;
        }
        else if (ship.tag == "Medium")
        {
            currentHealthPoints -= mediumShipDemage;
        }
        else if (ship.tag == "Heavy")
        {
            currentHealthPoints -= heavyShipDemage;
        }
        ChangeHealthPoints(currentHealthPoints);
    }

    void ChangeHealthPoints(float shipHealth)
    {
        healthPoints.CurrentHealthPoints(shipHealth);
        healthMovement.HealthMovement();
    }

    public void CameraShake()
    {
        iTween.ShakePosition(currentCamera.gameObject, iTween.Hash("y", 5.0f, "time", 0.5f, "delay", 0f));

    }

}