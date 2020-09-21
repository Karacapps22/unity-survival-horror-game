﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CellExitDoor : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    //public GameObject TheDoor;
    //public AudioSource CreakSound;
    public GameObject FadeOut;
    public GameObject ExtraCross;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);

        }
        if (Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 2)
            {
                ActionText.GetComponent<Text>().text = "Open door";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                FadeOut.SetActive(true);
                StartCoroutine(FadeToExit());
                //TheDoor.GetComponent<Animation>().Play("FirstDoorOpenn");
                //CreakSound.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator FadeToExit()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(4);
    }

}
