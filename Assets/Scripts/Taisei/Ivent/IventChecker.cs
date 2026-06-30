using UnityEngine;
using System.Collections.Generic;
public class IventChecker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ivents;

    
    public void IventLoad(List<Phase> Passedphase,BackPack backPack,Dialog dialog, SoundManager soundManager)
    {
        if(ivents.Count > 0) {
            foreach (GameObject obj in ivents)
            {
                obj.SetActive(false);

                PickUpIventer iventer = obj.GetComponent<PickUpIventer>();
                int score = PlayerPrefs.GetInt("A" + iventer.Ivent.Identifier, 0);
                if (score == 1) //探索済みなら
                {
                    continue;
                }
                if(iventer.Ivent.Terms != null) //条件がある場合
                {
                    if (Passedphase.Contains(iventer.Ivent.Terms))
                    { //条件を満たしている時
                        iventer.BackPack = backPack;
                        iventer.Dialog = dialog;
                        iventer.SoundManager = soundManager;
                        obj.SetActive(true);
                    }
                    continue;
                }

                iventer.BackPack = backPack;
                iventer.Dialog = dialog;
                iventer.SoundManager = soundManager;
                obj.SetActive(true);
            }
        }
    }
}
