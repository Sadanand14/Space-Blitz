using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    private RaycastHit hit;
    private Ray shotEnd;
    private Camera myCamera;
    private Vector3 origin, end;
    private Transform transfrm;
    private GameObject gameObj;
    private Text countdown;

    public GameObject projectilePrefab;

    // Use this for initialization
    void Start()
    {
        myCamera = FindObjectOfType<Camera>();
        transfrm = GetComponent<Transform>();
        countdown = GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown.text == "GO!")
        {
            if (Input.GetMouseButtonDown(0))
            {
                origin = new Vector3(transfrm.parent.transform.position.x, transfrm.parent.transform.position.y, transfrm.parent.transform.position.z + 10);
                shotEnd = myCamera.ScreenPointToRay(Input.mousePosition);

                end = myCamera.transform.position;
                end = myCamera.GetComponent<Transform>().TransformPoint(end);

                gameObj = Instantiate(projectilePrefab, origin, Quaternion.identity);
                gameObj.transform.LookAt(shotEnd.GetPoint(700f));
                gameObj.GetComponent<Rigidbody>().velocity = gameObj.transform.forward * (5000f);
            }
        }        
    }
}
