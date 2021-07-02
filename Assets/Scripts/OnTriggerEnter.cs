using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnter : MonoBehaviour
{
    public GameObject gameObject;

    public void TriggerEnter()
    {
        Debug.Log("Bonjour");
        StartCoroutine(ShowAndHide(gameObject, 0.1f)); // 1 second
    }
    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
}
