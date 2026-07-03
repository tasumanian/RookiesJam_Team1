using UnityEngine;
using System.Collections.Generic;
public class IventChecker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ivents;
    //この部屋のイベントのリスと

    [SerializeField]
    private string roomName;
    public string RoomName
    {
        get { return roomName; }
    }

    public void IventLoad(List<Phase> Passedphase,BackPack backPack,Dialog dialog, SoundManager soundManager)
    {
        if (ivents.Count < 1)
            return;

        foreach (GameObject obj in ivents)
        {
            obj.SetActive(false);

            PickUpIventer iventer = obj.GetComponent<PickUpIventer>();
            int score = PlayerPrefs.GetInt("A" + iventer.Ivent.Identifier, 0);
            //スコアにイベントの終了状況を取得

            if (score == 1) //探索済みなら表示しない
                continue;

            if (iventer.Ivent.Terms != null) //条件がある場合
            {
                if (Passedphase.Contains(iventer.Ivent.Terms))
                { //条件を満たしている時のみ表示

                    iventer.BackPack = backPack;
                    iventer.Dialog = dialog;
                    iventer.SoundManager = soundManager;
                    obj.SetActive(true);
                }
            }
            else
            {
                //条件がない場合は表示
                iventer.BackPack = backPack;
                iventer.Dialog = dialog;
                iventer.SoundManager = soundManager;
                obj.SetActive(true);
            }
        }
    }
}
