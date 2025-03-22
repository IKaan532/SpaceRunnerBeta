using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IObserver
{
    public PlayerController PlayerController;
    public UIManager UIManager;
    public AlienSpawner AlienSpawner;
    public GameObject StartSound;
    public GameObject GameSound;
  

    private GameObject _startSoundReference;
    private GameObject _gameSoundReference;

    private ICommand _gameStartCommand;
    private ICommand _gameEndCommand;

    void Start()
    {
        _startSoundReference = Instantiate(StartSound);
        GameEvents.AddObserver(this);  

        _gameStartCommand = new GameStartCommand(PlayerController);  
        _gameEndCommand = new GameEndCommand(this);
    }

    private void OnDestroy()
    {
        GameEvents.RemoveObserver(this);  
    }

    public void OnGameStart()
    {
        _gameStartCommand.Execute();  
        Destroy(_startSoundReference);
        _gameSoundReference = Instantiate(GameSound);  
    }

    public void OnGameEnd()
    {
        _gameEndCommand.Execute();  
        Destroy(_gameSoundReference);  
    }
    
    public void GameEnded()
    {
        UIManager.OnGameEnd();
        AlienSpawner.gameObject.SetActive(false);  
    }
    public void MapCreator()
    {

    }
}
