using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject _playerConteiner;
    private float _timeSpaw;

    private void Start()
    {
        _playerConteiner = Resources.Load<GameObject>("Prefabs/Player/PlayerContainer");
        _timeSpaw = 3f;
    }

    private IEnumerator PauseSpawn()
    { 
        yield return new WaitForSeconds(_timeSpaw);
    }

    public void SpawnearPlayer(bool playerAlive)//sera utilizado por el player collision control para determinar si el player murio
    {
        if (!playerAlive)
        {
            StartCoroutine(PauseSpawn());
            GameObject newPlayer = Instantiate(_playerConteiner);
            playerAlive = true;//falatia probar si esq no explota xd
        }
    }
}
