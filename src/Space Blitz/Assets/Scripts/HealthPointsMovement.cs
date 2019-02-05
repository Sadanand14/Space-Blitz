using UnityEngine;

public class HealthPointsMovement : MonoBehaviour
{
    private float healthLength = 418;
    private float maxPosition = -418.0f;
    public GameManager shipHealth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void HealthMovement()
    {
        this.transform.localPosition = new Vector3(maxPosition + healthLength * (shipHealth.currentHealthPoints / shipHealth.currenMaxHealthPoints), 0f, 0f);
    }
}