using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour, IObserver
{
    public GameObject StartPanel;
    public GameObject EndPanel;

    void OnEnable()
    {
        GameEvents.AddObserver(this);  
    }

    void OnDisable()
    {
        GameEvents.RemoveObserver(this);  
    }

    public void OnGameStart()
    {
        StartPanel.SetActive(false);
    }
    
    public void StartButtonDown()
    {
        GameEvents.TriggerGameStart();
        StartPanel.SetActive(false); 
    }

    public void OnGameEnd()
    {
        StartCoroutine(OpenEndPanelCoroutine());
    }

    private IEnumerator OpenEndPanelCoroutine()
    {
        yield return new WaitForSeconds(1);
        EndPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}