using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject _playerContainer; 
    private GameObject _playerDead; // para el que se encuentre en escena

    private bool _playerAlive; // pa controlar si el player esta presente
    private bool _isSpawning; // si no le ponia generaba muchos players :v

    private float _timeSpawn;

    private void Start()
    {
        // pa cargar el prefab del player
        _playerContainer = Resources.Load<GameObject>("Prefabs/Player/PlayerContainer");
        if (_playerContainer == null)
        {
            Debug.LogError("revisar direccion del prefab del player container");
        }

        _timeSpawn = 3f;
        _playerAlive = true;
        _isSpawning = false;
    }

    private void Update()
    {
        FindPlayer();

        // Si el player murio iniciar el respawn
        if (!_playerAlive && !_isSpawning)
        {
            StartCoroutine(SpawnPlayerRoutine());
        }
    }

    private IEnumerator SpawnPlayerRoutine()
    {
        _isSpawning = true; // Marcar que que inicia el respawn

        yield return new WaitForSeconds(_timeSpawn);

        if (_playerContainer != null)
        {
            Instantiate(_playerContainer); 
            _playerAlive = true; // Marcar al player como vivo
        }
        else
        {
            Debug.LogError("No se pudo instanciar porque el prefab es null.");
        }

        _isSpawning = false; // marcar como finalizada la corrutina
    }

    private void FindPlayer()
    {
        _playerDead = GameObject.FindGameObjectWithTag("Player");

        // marcar como morido si no se encuentra al player
        _playerAlive = _playerDead != null;
    }
}
