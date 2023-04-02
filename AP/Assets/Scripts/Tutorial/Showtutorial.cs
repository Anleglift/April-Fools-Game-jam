using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showtutorial : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject player;
    public GameObject PlayerRB;
    public bool CanShow = true;
    public AudioSource PopUp;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && CanShow)
        {
            PopUp.Play();
            PlayerRB.GetComponent<Rigidbody>().isKinematic = true;
            Tutorial.SetActive(true);
            Invoke("NoShow", 7.5f);
            CanShow = false;
        }
    }
    private void NoShow()
    {
        PlayerRB.GetComponent<Rigidbody>().isKinematic = false;

        Tutorial.SetActive(false);
    }
    // Update is called once per frame
}
