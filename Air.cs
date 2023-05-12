using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class Air : MonoBehaviour
{
    private ResScript RS;
    bool breath = false;
    [SerializeField] Slider airSlider;
    
    private void Start()
    {
        RS = GameObject.Find("Res").GetComponent<ResScript>();


    }

    private void Update()
    {
        if (!breath)
        {
            StartCoroutine(RemoveAir());
        }
        if(RS.Air==15)
        {
            StartCoroutine(FullAir());
        }
        airSlider.value = RS.Air;
    }

    IEnumerator RemoveAir()
    {
        breath = true;
        RS.Air--;
        GameObject[] illusions;
        illusions = GameObject.FindGameObjectsWithTag("Illusion");
        foreach (GameObject go in illusions)
        {
            Color tmp = go.GetComponent<SpriteRenderer>().color;
            tmp.a += 0.066f;
            go.GetComponent<SpriteRenderer>().color = tmp;
        }

            yield return new WaitForSeconds(1);
        breath = false;
    }
    IEnumerator FullAir()
    {
        GameObject[] illusions;
        illusions = GameObject.FindGameObjectsWithTag("Illusion");
        foreach (GameObject go in illusions)
        {
            Color tmp = go.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            go.GetComponent<SpriteRenderer>().color = tmp;
        }
        yield return new WaitForSeconds(0.5f);
    }
    
}
