using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameMoveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartScene()
    {
        SaveData.Initialize();
        SceneManager.LoadScene("MainScene");
    }
    public void ContinueScene()
    {

        SceneManager.LoadScene("MainScene");
    }
}
