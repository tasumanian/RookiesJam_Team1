using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AriaMove : MonoBehaviour
{
    [SerializeField]
    List<GameObject> MapList;

    [SerializeField]
    List<Button> ButtonList;

    [SerializeField]
    Animation ani;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    IEnumerator WaitAnimation()
    {
        //
        yield return new WaitForSeconds(1f);

    }
    public void ChangeAria(int index)
    {
        StartCoroutine(WaitAnimation());
    }
}
