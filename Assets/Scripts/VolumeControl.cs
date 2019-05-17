using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour {

    public AudioMixer mixer; 

    public void ChangeVolume(float sliderValue) {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
