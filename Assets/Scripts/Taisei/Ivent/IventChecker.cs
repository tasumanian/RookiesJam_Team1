using UnityEngine;
using System.Collections.Generic;
public class IventChecker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ivents;

    [SerializeField]
    List<GameObject> hiddenIvents;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void IventLoad(bool phase,BackPack backPack,Dialog dialog)
    {
        if(ivents.Count > 0) {
            foreach (GameObject obj in ivents)
            {
                obj.SetActive(true);

                PickUpIventer iventer = obj.GetComponent<PickUpIventer>();
                iventer.BackPack = backPack;
                iventer.Dialog = dialog;
                int score = PlayerPrefs.GetInt("A" + iventer.Ivent.Identifier, 0);
                if (score == 1) //探索済みなら
                {
                    obj.SetActive(false);
                }
            }
        }
        if (!phase)
        {
            foreach (GameObject obj in hiddenIvents)
            {
                obj.SetActive(false);
            }
            return;
        }
        if(hiddenIvents.Count > 0) {
            foreach (GameObject obj in hiddenIvents)
            {
                obj.SetActive(true);

                PickUpIventer iventer = obj.GetComponent<PickUpIventer>();
                iventer.BackPack = backPack;
                iventer.Dialog = dialog;
                int score = PlayerPrefs.GetInt("A" + iventer.Ivent.Identifier, 0);
                if (score == 1) //探索済みなら
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
