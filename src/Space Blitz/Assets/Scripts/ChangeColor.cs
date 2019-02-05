using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{

    public GameObject content;
    private Image hpImage;
    public GameManager shipHealth;
    // Use this for initialization
    void Start()
    {
        hpImage = content.GetComponent<Image>();
        StartCoroutine(Judge());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Judge()
    {
        while (true)
        {
            if (shipHealth.currentHealthPoints / shipHealth.currenMaxHealthPoints > 0.3f)
            {
                hpImage.color = Color.white;
            }
            else if (shipHealth.currentHealthPoints / shipHealth.currenMaxHealthPoints <= 0.3f)
            {
                hpImage.color = new Color32(201, 43, 43, 255);
                yield return new WaitForSeconds(1.0f);
                hpImage.color = Color.white;
                yield return new WaitForSeconds(1.0f);
            }
            yield return null;
        }

    }
}