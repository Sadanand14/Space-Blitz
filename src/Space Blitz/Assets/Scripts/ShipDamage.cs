using UnityEngine;
using UnityEngine.UI;

public class ShipDamage : MonoBehaviour
{
    private MainManager manager;
    private HealthPoints hp;
    private ProjectileScript pS;

    public Text loseTxt;
    public GameObject blast;

    // Use this for initialization
    void Start()
    {
        hp = GetComponent<HealthPoints>();
        manager = FindObjectOfType<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.healthPoints <= 0)
        {
            gameObject.GetComponent<Transform>().parent.gameObject.SetActive(false);
            GameObject blastEffect = Instantiate(blast, gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(blastEffect, 2);
            loseTxt.text = "YOU LOSE";
            loseTxt.color = Color.red;
            manager.ShowPaused();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pS = other.GetComponent<ProjectileScript>();
        other.gameObject.SetActive(false);

        GameObject hitEffect = Instantiate(pS.hitBlastPrefab, other.gameObject.transform.position, Quaternion.identity) as GameObject;
        Destroy(hitEffect, 0.5f);

        float damage = pS.damage;
        hp.healthPoints -= damage;

        if (hp.healthPoints <= 0)
        {
            this.gameObject.GetComponent<Transform>().parent.gameObject.SetActive(false);
            GameObject blastEffect = Instantiate(blast, gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(blastEffect, 2);
        }
    }
}
