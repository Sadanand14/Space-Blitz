using UnityEngine;

public class Objectives : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    public GameObject arrowIndicator;
    public GameObject arrowIndicatorGO;
    public GameObject finishIndicator;
    public GameObject finishIndicatorGO;

    [SerializeField]
    float distance;

    // Use this for initialization
    void Start()
    {
        arrowIndicatorGO = Instantiate(arrowIndicator) as GameObject;
        arrowIndicatorGO.transform.parent = transform;
        finishIndicatorGO = Instantiate(finishIndicator) as GameObject;
        finishIndicatorGO.transform.parent = transform;

        distance = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
        Debug.Log(distance);
        Debug.Log("end point" + endPoint.transform.position);
        Debug.Log("start point" + startPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        PlaceIndicators();
    }

    void PlaceIndicators()
    {
        Vector3 screenpos = Camera.main.WorldToScreenPoint(endPoint.transform.position);

        Debug.Log("Screenpos: " + screenpos);
        // If onscreen
        if (screenpos.z > 0 && screenpos.x < Screen.width && screenpos.x > 0 && screenpos.y < Screen.height && screenpos.y > 0)
        {
            finishIndicatorGO.transform.localPosition = screenpos;
            Debug.Log("OnScreen: " + screenpos);
        }
        else
        {
            finishIndicatorGO.transform.localPosition = new Vector3(0.0f,0.0f,-1239f);
            PlaceOffscreen(screenpos);
        }
    }

    void PlaceOffscreen(Vector3 screenpos)
    {
        float x = screenpos.x;
        float y = screenpos.y;
        float offset = 10;

        if (screenpos.z < 0)
        {
            screenpos *= -1;
        }

        if (screenpos.x > Screen.width)
        {
            x = Screen.width - offset;
        }
        if (screenpos.x < 0)
        {
            x = offset;
        }

        if (screenpos.y > Screen.height)
        {
            y = Screen.height - offset;
        }
        if (screenpos.y < 0)
        {
            y = offset;
        }

        arrowIndicatorGO.transform.position = new Vector3(x, y, 0);

        //if (screenpos.z < 0)
        //{
        //    screenpos *= -1;
        //}

        
        //screenpos -= screenCenter;

        //float angle = Mathf.Atan2(screenpos.y, screenpos.x);
        //angle -= 90 * Mathf.Deg2Rad;

        //float cos = Mathf.Cos(angle);
        //float sin = Mathf.Sin(angle);

        //screenpos = screenCenter + new Vector3(sin * 150, cos * 150, 0);

        //float m = cos / sin;
        //Vector3 screenBounds = screenCenter * 0.9f;

        //if (cos > 0)
        //{
        //    screenpos = new Vector3(screenBounds.y / m, screenBounds.y, 0);
        //}
        //else
        //{
        //    screenpos = new Vector3(-screenBounds.y / m, -screenBounds.y, 0);
        //}

        //if (screenpos.x > screenBounds.x)
        //{
        //    screenpos = new Vector3(screenBounds.x, screenBounds.x * m, 0);
        //}

        //screenpos += screenCenter;

        //if (arrowIndicatorGO != null)
        //{
        //    
        //}

        //arrowIndicatorGO.transform.localPosition = screenpos;
        //arrowIndicatorGO.transform.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}