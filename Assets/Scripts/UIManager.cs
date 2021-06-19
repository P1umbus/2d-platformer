using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private GameObject _panelWin;

    public void Victory()
    {
        _panelWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void Defeat()
    {
        _panelLose.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
