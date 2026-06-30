using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AriaMove : MonoBehaviour
{
    [SerializeField]
    List<GameObject> mapList;
    [SerializeField]
    Animator ani;
    [SerializeField]
    BackPack backpack;
    [SerializeField]
    Dialog dialog;
    [SerializeField]
    GameObject nowAria;
    [SerializeField]
    SoundManager soundManager;

    int nowIndex = 0;
    public List<Phase> passedPhase;

    IEnumerator ChangeAnimation(int index)
    {
        ani.SetTrigger("BrackOut");
        yield return new WaitForSeconds(1.5f);
        
        Destroy(nowAria);

        nowAria = Instantiate(mapList[index],gameObject.transform);
        nowAria.GetComponent<IventChecker>().IventLoad(passedPhase, backpack, dialog,soundManager);

        yield return new WaitForSeconds(0.5f);
        ani.SetTrigger("RightChange");

    }
    public void ChangeAria(int index)
    {
        if (index == -1)
        {
            StartCoroutine(ChangeAnimation(nowIndex));
        }
        else
        {
            StartCoroutine(ChangeAnimation(index));

            nowIndex = index;
        }
    }
}
