using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update

    public bool _startGame;

    public Transform _paginas;
   
    public void GamePlayer()
    {
        _startGame = true;
    }
}
