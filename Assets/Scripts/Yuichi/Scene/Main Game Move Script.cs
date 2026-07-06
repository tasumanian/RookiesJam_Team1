using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameMoveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartScene()
    {
        SaveData.Initialize();
        //セーブデータを初期化してからロードする

        SceneManager.LoadScene("MainScene");
    }
    public void ContinueScene()
    {

        SceneManager.LoadScene("MainScene");
    }
    public void GameEnd()
    {
        //ゲームプレイ終了

        Application.Quit();

        //エディター上で止める用
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
