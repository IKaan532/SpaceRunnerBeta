using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartCommand :MonoBehaviour, ICommand
{
    private PlayerController _playerController;

    
    public GameStartCommand(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void Execute()
    {
        _playerController.OnGameStart();  
    }
}

