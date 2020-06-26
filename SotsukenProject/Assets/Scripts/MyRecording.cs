using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MyRecording : MonoBehaviour
{
    static AudioClip myclip;
    static AudioSource audioSource;
    string micName = "null"; //マイクデバイスの名前
    const int samplingFrequency = 44100; //サンプリング周波数
    const int maxTime_s = 1200; //最大録音時間[s]

    // public Action OnRecordStart;
    // public Action OnRecordEnd;


    void Start()
    {
        //マイクデバイスを探す
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            micName = device;
        }
    }

    public void StartButton()
    {

        // deviceName: "null" -> デフォルトのマイクを指定

        //パラメーターがTではないため記録できない
        //EasySaveなら可能
        //myclip = ScriptableObject.CreateInstance<AudioClip>();

        myclip = Microphone.Start(deviceName: micName, loop: false, lengthSec: maxTime_s, frequency: samplingFrequency);

        // if (OnRecordStart != null)
        // {
        //     OnRecordStart();
        // }

        // OnRecordStart += WriteRecordFile;
        Debug.Log("Audio recording start");

    }

    public void EndButton()
    {
        if (Microphone.IsRecording(deviceName: micName) == true)
        {

            Microphone.End(deviceName: micName);

            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = myclip;
            ES2.Save<AudioClip>(audioSource.clip, "MyAudioClip");


            SafeCreateDirectory("Assets/Resources");
            var path = string.Format("Assets/Resources/RecordMotion_{0}{1:yyyy_MM_dd_HH_mm_ss}.asset", myclip.name, DateTime.Now);
            var uniqueAssetPath = AssetDatabase.GenerateUniqueAssetPath(path);
            AssetDatabase.CreateAsset(myclip, uniqueAssetPath);
            AssetDatabase.SaveAssets();
            Debug.Log(AssetDatabase.GetAssetPath(myclip));



            //AudioClip recordingClip = AudioClip.Create("recordingClip", samplingFrequency * 2, 1, samplingFrequency, true);
            //recordingClip = myclip;

            // OnRecordEnd();
            // OnRecordEnd -= WriteRecordFile;


            //WriteRecordFileで音が出なくなる
            //WriteRecordFile();
            Debug.Log("Audio recording stoped");
            Debug.Log(Application.persistentDataPath);
        }
        else
        {
            Debug.Log("not recording");
        }
    }

    public void PlayButton()
    {
        Debug.Log("Audio play");
        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = myclip;
        //audioSource.Play();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = ES2.Load<AudioClip>("MyAudioClip");
        audioSource.Play();
        Debug.Log(Application.persistentDataPath);


        Debug.Log(audioSource.clip.name);
    }

    protected void WriteRecordFile()
    {

        SafeCreateDirectory("Assets/Resources");
        //.asset消してみた

        var path = string.Format("Assets/Resources/{0}{1:yyyy_MM_dd_HH_mm_ss}", myclip.name, System.DateTime.Now);
        //var path = string.Format("Assets/Resources/RecordSounds_{0}{1:yyyy_MM_dd_HH_mm_ss}", myclip.name, System.DateTime.Now);
        var uniqueAssetPath = AssetDatabase.GenerateUniqueAssetPath(path);

        AssetDatabase.CreateAsset(myclip, uniqueAssetPath);
        // AssetDatabase.Refresh();

    }

    public static DirectoryInfo SafeCreateDirectory(string path)
    {
        return Directory.Exists(path) ? null : Directory.CreateDirectory(path);
    }

}
