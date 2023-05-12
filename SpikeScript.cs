using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    private ResScript RS;
    [SerializeField] AudioSource breath;
    [SerializeField] GameObject showText;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameWin;
    private void Start()
    {
        RS = GameObject.Find("Res").GetComponent<ResScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }

        if(collision.gameObject.CompareTag("Illusion") && !RS.hasPickAxe)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }

       /* if (collision.gameObject.CompareTag("Illusion") && RS.hasPickAxe)
        {
            Debug.Log("Gone");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pick"))
        {
            RS.hasPickAxe = true;
            Destroy(collision.gameObject);
        }*/

        if(collision.gameObject.CompareTag("Air"))
        {
            RS.Air = 15;
            breath.Play();
        }
        if(collision.gameObject.CompareTag("UseLamp"))
        {
            RS.canUse = true;
            showText.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            gameWin.SetActive(true);
            Time.timeScale = 0f;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UseLamp"))
        {
            RS.canUse = false;
            showText.SetActive(false);
        }
    }
}
