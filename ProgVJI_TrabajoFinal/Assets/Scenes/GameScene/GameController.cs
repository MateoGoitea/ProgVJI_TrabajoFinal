using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject _basePlayer;
    private GameObject _baseEnemy;

    // Start is called before the first frame update
    void Start()
    {
        _basePlayer = GameObject.FindGameObjectWithTag("BasePlayer");
        
    }

    // Update is called once per frame
    void Update()
    {   //constantemente busca por un enemy base, cuando ya no quedan ninguno la funcion devuelve true 
        _baseEnemy = GameObject.FindGameObjectWithTag("BaseEnemy");
        
        if (_basePlayer == null) SceneManager.LoadScene("GameOver");

        if (BasesEnemysDestroy()) SceneManager.LoadScene("Victory");
    }

    private bool BasesEnemysDestroy()
    {
        if (_baseEnemy != null){
            return false; //si aun queda alguna base
        }else{
            return true;
        }
        /*foreach (var enemy in _baseEnemy)
        {
            if (_baseEnemy != null) return false;//si aun queda alguna base
        }
        return true;//si todas fueros destruidas*/
    }
}
