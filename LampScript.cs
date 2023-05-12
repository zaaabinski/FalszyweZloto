using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LampScript : MonoBehaviour
{
    private ResScript RS;
    [SerializeField] GameObject lampGO;
    bool lampHeld = false;
    [SerializeField] AudioSource lampSound;
    [SerializeField] AudioSource oilSOund;
    [SerializeField] TextMeshProUGUI lampFuel;
    [SerializeField] Animator anim;
    [SerializeField] GameObject textObj;
    public GhostMove GM;

    private void Start()
    {
        RS = GameObject.Find("Res").GetComponent<ResScript>();
    }
    private void FixedUpdate()
    {
        lampFuel.text = RS.LampLight.ToString();
        if (RS.LampLight > 0 && Input.GetKey(KeyCode.E) && !lampHeld && RS.canUse)
        {
            StartCoroutine(LampUp());

        }
    }

    IEnumerator LampUp()
    {
        RS.speed = 0;
        anim.SetTrigger("LampUp");
        textObj.SetActive(false);
        lampSound.Play();
        lampHeld = true;
        RS.LampLight--;
        lampGO.SetActive(true);
        yield return new WaitForSeconds(1);
        textObj.SetActive(false);
        RS.speed = 6.5f;
        RS.canUse = false;
        lampHeld = false;
        lampGO.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Paliwo"))
        {
            RS.LampLight += 1;
            oilSOund.Play();
            Destroy(collision.gameObject);
        }    
    }
}
