using UnityEngine;

public class Bookmove : MonoBehaviour
{
    public GameObject BookScreen;

    public void OpenBook()
    {
        BookScreen.SetActive(true);
    }

    public void ClosePC()
    {
        BookScreen.SetActive(false);
    }
}