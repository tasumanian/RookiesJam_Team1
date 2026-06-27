using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AriaMove : MonoBehaviour
{
    [SerializeField]
    List<GameObject> mapList;

    [SerializeField]
    Animator ani;

    GameObject nowAria;
    bool isSecondPhase;

    public bool IsSecondPhase
    {
        set { isSecondPhase = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    IEnumerator ChangeAnimation(int index)
    {
        ani.SetTrigger("BrackOut");
        yield return new WaitForSeconds(1.5f);
        
        Destroy(nowAria);

        nowAria = Instantiate(mapList[index],gameObject.transform);
        nowAria.GetComponent<IventChecker>().IventLoad(isSecondPhase);

        yield return new WaitForSeconds(0.5f);
        ani.SetTrigger("RightChange");

    }
    public void ChangeAria(int index)
    {
        StartCoroutine(ChangeAnimation(index));
    }
}
