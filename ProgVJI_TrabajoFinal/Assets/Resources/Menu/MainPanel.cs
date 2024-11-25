using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    //options
    [SerializeField]private Slider _volumeVFX;
    [SerializeField]private Slider _volumeMaster;
    [SerializeField]private Toggle _mute;

    //paneles
    [SerializeField]private GameObject _mainPanel;
    [SerializeField]private GameObject _optionsPanel;

    //audio
    private AudioMixer _mixer;
    private float _lastVolume;
    
    void Start(){
        _mixer = Resources.Load<AudioMixer>("Sounds/AudioMixer");
    }

    private void Awake(){
        _volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        _volumeVFX.onValueChanged.AddListener(ChangeVolumeFX);
    }

    public void PlayGame(string level){
        SceneManager.LoadScene(level);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void OpenPanel(GameObject panel){
        //desactiva todos los paneles y activa el que recibe
        _mainPanel.SetActive(false);
        _optionsPanel.SetActive(false);

        panel.SetActive(true);
    }

    public void ChangeVolumeMaster(float vol){
        //recibe el valor del volumen y se lo aplica al mixer
        _mixer.SetFloat("VolMaster",vol);
    }

    public void ChangeVolumeFX(float vol){
        //recibe el valor del volumen y se lo aplica al mixer
        _mixer.SetFloat("VolFX",vol);
    }

    public void SetMute(){
        //se guarda el ultimo volumen configurado y se verifica si el toggle esta activado o no
        if (_mute.isOn){
            _mixer.GetFloat("VolMaster",out _lastVolume);
            _mixer.SetFloat("VolMaster",-80);
        }else{
            _mixer.SetFloat("VolMaster",_lastVolume);
        }
    }
}
