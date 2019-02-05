using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject fireEffect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.ShipDeceleration(collision.collider);
        gameManager.ShipDemage(collision.collider);
        gameManager.CameraShake();

        // Get the position of collision
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        GameObject currentFire = Instantiate(fireEffect, pos, Quaternion.identity);
        Destroy(currentFire, 4.0f);
    }
}