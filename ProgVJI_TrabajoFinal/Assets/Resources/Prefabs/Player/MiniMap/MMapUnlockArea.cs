using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMapUnlockArea : MonoBehaviour //namas muetra negro cuando se borra la textura :v
{
    private Texture2D _fogTexture;//pa la textura que tiene el GameObj (PMiniMapFog)
    private Color[] _fogColors;//pa los pixeles que tiene la textura

    private float _unlockRadius; //radio de desbloqueo del mini map    
    private Transform _player; //referencia al player

    private void Start()
    {
        //obtener la textura que posee el render
        Renderer renderTexture = GetComponent<Renderer>();
        _fogTexture = renderTexture.material.mainTexture as Texture2D;

        //copia de la textura para no canbiar la original
        _fogTexture = Instantiate(_fogTexture);
        renderTexture.material.mainTexture = _fogTexture;

        //obtener los pixeles de la textura
        _fogColors = _fogTexture.GetPixels();

        _unlockRadius = 5f;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    public void Update()
    {
        if (_player == null) _player = GameObject.FindGameObjectWithTag("Player").transform;

        RevealArea();  
    }

    private void RevealArea()
    {
        //convertir la pos del player a coordenadas de la textura
        Vector3 playerPos = _player.position;
        Vector2 textureCoord = WorldToTextureCoord(playerPos);

        int radius = Mathf.RoundToInt(_unlockRadius * _fogTexture.width / 100f);//redondea un float a su entero mas alto

        RevealPixels(textureCoord, radius);

    }

    private void RevealPixels(Vector2 center, int radio)
    {
        for (int y = -radio; y <= radio; y++)
        {
            for (int x = -radio; x <= radio; x++)
            {
                int px = Mathf.RoundToInt(center.x + x);
                int py = Mathf.RoundToInt(center.y + y);

                if (IsPixelInBounds(px,py) && IsPixelRadiusReveal(center, radio, px, py))
                {
                    SetPixelUnlock(px, py);
                }
            }
        }
        ApplyChangesTexture();
    }

    private bool IsPixelInBounds(int x, int y) //encargado de verificar que el pixel se encuentre dentro de los limites de la textura
    {
        return x >= 0 && x < _fogTexture.width && y >= 0 && y < _fogTexture.height;
    }

    private bool IsPixelRadiusReveal(Vector2 center, int radius, int x, int y)// verifica si los pixeles estan dentro del unlockRadius 
    {
        float distance = Vector2.Distance(center, new Vector2(x,y));

        return distance <= radius;
    }

    private void  SetPixelUnlock(int x, int y) // para transparentar los pixeles de la textura 
    {
        int index = y * _fogTexture.width + x;
        _fogColors[index] = new Color(0,0,0,0); //transparente
    }

    private void ApplyChangesTexture() //setea los cambios a la textura
    {
        _fogTexture.SetPixels(_fogColors);
        _fogTexture.Apply();
    }

    private Vector2 WorldToTextureCoord(Vector3 worldPos)
    {
        //obtener la posicion y la escala del GameObj que tiene la textura
        Vector3 fogPos = transform.position;
        Vector3 fogScale = transform.localScale;

        //transformar la pos del mundo a coordeadas de la textura
        float x = ((worldPos.x - fogPos.x) / fogScale.x + 0.5f) * _fogTexture.width;
        float y = ((worldPos.y - fogPos.y) / fogScale.y + 0.5f) * _fogTexture.height;

        return new Vector2( x , y );
    }
}
