using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Transform _weaponPosition;
    private List<ICommand> _commands;

    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
        _weaponPosition = GetComponentInChildren<Transform>();
        _commands = new List<ICommand>();
    }

    // Update is called once per frame
    void Update()
    {
        //limpieza de la lista para evitar la acomulacion de los comandos
        _commands.Clear();

        //agregacion de comandos dentro de la lista
        _commands.Add(new HorizontalCommand(_playerMovement));
        _commands.Add(new VerticalCommand(_playerMovement));
        _commands.Add(new ShootCommand(_weaponPosition));

        //recorrer la lista y ejecutar sus metodos
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
}
