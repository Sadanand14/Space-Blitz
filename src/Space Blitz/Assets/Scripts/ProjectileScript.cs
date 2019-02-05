using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    WaitForSeconds bulletDuration = new WaitForSeconds(5f);
    public float damage = 10f;
    public GameObject hitBlastPrefab;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3);
        //StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {

    }

   
    //private IEnumerator SelfDestruct()
    //{
    //    yield return bulletDuration;
    //    Debug.Log("Object Destroyed); 
    //    Destroy(gameObject);
    //}
}
