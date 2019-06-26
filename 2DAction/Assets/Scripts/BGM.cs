using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour {

    public AudioClip audioClipLayer1;
    public AudioClip audioClipLayer2;
    public AudioClip audioClipLayer3;
    public AudioClip audioClipLayer4;
    public AudioClip audioClipLayer5;
    public AudioClip audioClipLayer6;
    public AudioClip audioClipLayer7;

    private AudioSource audioSource0;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;
    private AudioSource audioSource4;
    private AudioSource audioSource5;
    private AudioSource audioSource6;

    public GameController gameController;
    public GameObject camera_transform;

    [SerializeField]
    private AudioMixerSnapshot NormalBGM;

    [SerializeField]
    private AudioMixerSnapshot LowPassBGM;

    [SerializeField]
    private AudioMixer audioMixer;

    bool play_music = true;

	void Start () {
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();

        audioSource0 = audioSources[0];  // kick + cymbal
        audioSource1 = audioSources[1];  // hihat
        audioSource2 = audioSources[2];  // snare
        audioSource3 = audioSources[3];  // bass
        audioSource4 = audioSources[4];  // chord
        audioSource5 = audioSources[5];  // melody
        audioSource6 = audioSources[6];  // submelody
    }
	
	void Update () {
        // BGMの初期化
        if (gameController.gameStart && play_music)
        {
            audioSource0.clip = audioClipLayer1;
            audioSource0.Play();

            audioSource1.clip = audioClipLayer2;
            audioSource1.Play();
            audioSource1.volume = 0.0f;

            audioSource2.clip = audioClipLayer3;
            audioSource2.Play();
            audioSource2.volume = 0.0f;

            audioSource3.clip = audioClipLayer4;
            audioSource3.Play();
            audioSource3.volume = 0.0f;

            audioSource4.clip = audioClipLayer5;
            audioSource4.Play();
            audioSource4.volume = 0.0f;

            audioSource5.clip = audioClipLayer6;
            audioSource5.Play();
            audioSource5.volume = 0.0f;

            audioSource6.clip = audioClipLayer7;
            audioSource6.Play();
            audioSource6.volume = 0.0f;

            play_music = false;
        }

        // BGMのレイヤーの処理
        Vector3 camera = camera_transform.transform.position;
        int min = 0;  // レイヤーの再生を開始する座標
        int max = 0;  // レイヤーの音量が最大(1.0)になる座標
        int musicRange = 44;  // レイヤーを重ねない範囲
        int fadeInRange = 90;  // レイヤーを重ねる範囲
        /*
         * (camera.x - min) / (max - min) : カメラのx座標を最大値1、最小値0で正規化する
         * Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min)) : 正規化した値によって0から1までの中間値をとる
         */
        if (camera.x >= 44.0f)
        {
            min = musicRange;
            max = min + fadeInRange;
            audioSource1.volume = Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min));
        }
        if (camera.x >= 44.0f * 2)
        {
            min = max + musicRange;
            max = min + fadeInRange;
            audioSource2.volume = Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min));
        }
        if (camera.x >= 44.0f * 3)
        {
            min = max + musicRange;
            max = min + fadeInRange;
            audioSource3.volume = Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min));
        }
        if (camera.x >= 44.0f * 4)
        {
            min = max + musicRange;
            max = min + fadeInRange;
            audioSource4.volume = Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min));
        }
        if (camera.x >= 44.0f * 5)
        {
            min = max + musicRange;
            max = min + fadeInRange;
            audioSource5.volume = Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min));
            audioSource6.volume = Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min));
        }
        if (camera.x >= 44.0f * 6)
        {
            min = max + musicRange;
            max = min + fadeInRange;
            audioSource6.volume = Mathf.Lerp(0f, 1f, (camera.x - min) / (max - min));
        }

        // BGMのローパスフィルターの処理
        if(camera.y <= -10.0f)
        {
            audioMixer.SetFloat("Cutoff freq", 734f);
            audioMixer.SetFloat("Resonance", 2f);
        }
        else
        {
            audioMixer.SetFloat("Cutoff freq", 22000f);
            audioMixer.SetFloat("Resonance", 1f);
        }
    }
}
