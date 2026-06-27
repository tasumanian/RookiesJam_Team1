using UnityEngine;
using System.Collections.Generic;
public class IventChecker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ivents;

    [SerializeField]
    List<GameObject> hiddenIvents;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void IventLoad(bool phase)
    {

        foreach (GameObject obj in ivents)
        {
            obj.SetActive(true);

            Ivent ivent = obj.GetComponent<Ivent>();
            
            int score = PlayerPrefs.GetInt("A" + ivent.Identifier, 0);
            if (score == 1) //探索済みなら
            {
                obj.SetActive(false);
            }
        }
        if (!phase)
            return;

        foreach (GameObject obj in hiddenIvents)
        {
            obj.SetActive(true);

            Ivent ivent = obj.GetComponent<Ivent>();

            int score = PlayerPrefs.GetInt("A" + ivent.Identifier, 0);
            if (score == 1) //探索済みなら
            {
                obj.SetActive(false);
            }
        }
    }
    
}
