using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
    private GameObject _bullet;
    private List<GameObject> _bulletList;
    private int _poolSize; //pa el tamano inicial de la lista de balas

    public static PlayerBulletPool Instance { get; private set;  }//pa que la clase sea accesible desde otros scripts

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);//pa que sobreviva al cambio de escenas
        }else
        {
            Destroy(gameObject);//cosa de que se destruya si es que ya existe otra instancia que no sea esta
            return;
        }

    }

    private void Start()
    {
        _bullet = Resources.Load<GameObject>("Prefabs/Player/Bullets/PlayerBullet"); //pa cargar la bala desde la carpeta resources

        _bulletList = new List<GameObject>();

        _poolSize = 15;

        AddBulletsToPool(_poolSize);
    }

    private void AddBulletsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject _newBullet = Instantiate(_bullet);

            _newBullet.SetActive(false); //desactivar inicialmente

            _bulletList.Add(_newBullet); //a�adir las balas a la lista
            _newBullet.transform.parent = transform;

            _newBullet.transform.parent = transform;

        }
    }

    public GameObject GetBullet(Vector3 newPosition, Quaternion newRotation)
    {
        foreach (GameObject bullet in _bulletList) //busca una bala inactiva de la lista
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = newPosition;//pa que la posicion de la bala sea igual a la recibida como parametro

                bullet.transform.rotation = newRotation;

                bullet.SetActive(true);
                return bullet;
            }
        }

        //si no hay balas disponibles entonces las a�ade
        GameObject newBullet = Instantiate(_bullet, newPosition,newRotation);

        newBullet.SetActive(true);
        _bulletList.Add(newBullet);
        newBullet.transform.parent = transform;
        

        return newBullet;
    }

    public void ReturnBullet(GameObject bullet) //metodo para debolver la bala al pool
    {
        bullet.SetActive(false);
    }

}
