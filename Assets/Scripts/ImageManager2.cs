using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager2 : MonoBehaviour
{
    public GameObject[] imagesArray;

    public RuntimeAnimatorController animCtoL;
    public RuntimeAnimatorController animLtoR;
    public RuntimeAnimatorController animRtoC;

    private int counter;
    private bool isAnimating;

    public void Next()
    {
        if (!isAnimating)
        {
            foreach (var img in imagesArray)
            {
                img.GetComponent<Animator>().enabled = true;
            }

            StartCoroutine(Animate(0.5f));
        }
    }

    public void GetApp()
    {
        // Any URL can be here
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.souq.app&hl=en");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Application.OpenURL("https://goo.gl/JB2aXL");
        }
    }

    private IEnumerator Animate(float delay)
    {
        isAnimating = true;
        yield return new WaitForSeconds(delay);

        if (counter == 0)
        {
            imagesArray[0].GetComponent<Animator>().runtimeAnimatorController = animLtoR;
            imagesArray[0].GetComponent<Animator>().enabled = false;
            imagesArray[1].GetComponent<Animator>().runtimeAnimatorController = animRtoC;
            imagesArray[1].GetComponent<Animator>().enabled = false;
            imagesArray[2].GetComponent<Animator>().runtimeAnimatorController = animCtoL;
            imagesArray[2].GetComponent<Animator>().enabled = false;

            ++counter;
        }
        else if (counter == 1)
        {
            imagesArray[0].GetComponent<Animator>().runtimeAnimatorController = animRtoC;
            imagesArray[0].GetComponent<Animator>().enabled = false;
            imagesArray[1].GetComponent<Animator>().runtimeAnimatorController = animCtoL;
            imagesArray[1].GetComponent<Animator>().enabled = false;
            imagesArray[2].GetComponent<Animator>().runtimeAnimatorController = animLtoR;
            imagesArray[2].GetComponent<Animator>().enabled = false;

            ++counter;
        }
        else if (counter == 2)
        {
            imagesArray[0].GetComponent<Animator>().runtimeAnimatorController = animCtoL;
            imagesArray[0].GetComponent<Animator>().enabled = false;
            imagesArray[1].GetComponent<Animator>().runtimeAnimatorController = animLtoR;
            imagesArray[1].GetComponent<Animator>().enabled = false;
            imagesArray[2].GetComponent<Animator>().runtimeAnimatorController = animRtoC;
            imagesArray[2].GetComponent<Animator>().enabled = false;

            counter = 0;
        }

        Debug.Log(counter);

        isAnimating = false;
    }
}
