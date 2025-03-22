using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCommand :MonoBehaviour, ICommand
{
    private GameManager _gameManager;

    public GameEndCommand(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Execute()
    {
        _gameManager.GameEnded();  
    }
}


