using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{

    public GameObject[] imagesArray;

    public RuntimeAnimatorController animCtoL;
    public RuntimeAnimatorController animLtoR;
    public RuntimeAnimatorController animRtoC;

    public RectTransform centerTransform;
    public RectTransform leftTransform;
    public RectTransform rightTransform;

    //private int currentImage;

    /*private void Start()
    {

    }*/

    public void Next()
    {
        foreach (var img in imagesArray)
        {
            if (img.GetComponent<RectTransform>() == centerTransform)
            {
                img.GetComponent<Animator>().enabled = true;
                StartCoroutine(Animate(1f));
                //img.GetComponent<Animator>().enabled = false;
                //img.GetComponent<Animator>().runtimeAnimatorController = animLtoR;

                //img.GetComponent<Animator>().enabled = false;
                //img.GetComponent<Animator>().enabled = true;
                //Debug.Log(imagesArray[0].transform.position.ToString());
            }

            if (img.GetComponent<RectTransform>() == leftTransform)
            {
                img.GetComponent<Animator>().enabled = true;
                StartCoroutine(Animate(1f));
                //img.GetComponent<Animator>().enabled = false;
                //img.GetComponent<Animator>().runtimeAnimatorController = animRtoC;

                //img.GetComponent<Animator>().enabled = false;
                //img.GetComponent<Animator>().enabled = true;
                //Debug.Log(imagesArray[0].transform.position.ToString());
            }

            if (img.GetComponent<RectTransform>() == rightTransform)
            {
                img.GetComponent<Animator>().enabled = true;
                StartCoroutine(Animate(1f));
                //img.GetComponent<Animator>().enabled = false;
                //img.GetComponent<Animator>().runtimeAnimatorController = animCtoL;

                //img.GetComponent<Animator>().enabled = false;
                //img.GetComponent<Animator>().enabled = true;
                //Debug.Log(imagesArray[0].transform.position.ToString());
            }
        }

        /*imagesArray[currentImage].SetActive(false);
       currentImage++;
       if (currentImage > 2)
       {
           currentImage = 0;
       }
       imagesArray[currentImage].SetActive(true);*/
    }

    public void GetApp()
    {
        // Any URL can be here
        Application.OpenURL("https://www.google.com");
    }

    private IEnumerator Animate(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (var img in imagesArray)
        {
            if (img.GetComponent<RectTransform>() == centerTransform)
            {
                img.GetComponent<Animator>().enabled = false;
                img.GetComponent<Animator>().runtimeAnimatorController = animLtoR;
                //img.GetComponent<Animator>().runtimeAnimatorController = animCtoL;
            }

            if (img.GetComponent<RectTransform>() == leftTransform)
            {
                img.GetComponent<Animator>().enabled = false;
                img.GetComponent<Animator>().runtimeAnimatorController = animRtoC;
                //img.GetComponent<Animator>().runtimeAnimatorController = animLtoR;
            }

            if (img.GetComponent<RectTransform>() == rightTransform)
            {
                img.GetComponent<Animator>().enabled = false;
                img.GetComponent<Animator>().runtimeAnimatorController = animCtoL;
                //img.GetComponent<Animator>().runtimeAnimatorController = animRtoC;
            }
        }
    }
}
