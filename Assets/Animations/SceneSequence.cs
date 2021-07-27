using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject animationCamera1;
    public GameObject animationCamera2;
    public GameObject animationCamera3;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(theSequence());
    }

    IEnumerator theSequence()
    {
        animationCamera1.SetActive(true);
        mainCamera.SetActive(false);
        yield return new WaitForSeconds(5);
        animationCamera2.SetActive(true);
        animationCamera1.SetActive(false);
        yield return new WaitForSeconds(5);
        animationCamera3.SetActive(true);
        animationCamera2.SetActive(false);
        yield return new WaitForSeconds(5);
        mainCamera.SetActive(true);
        animationCamera3.SetActive(false);
    }

}
