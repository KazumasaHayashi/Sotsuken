using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
//using UnityEngine.UI;
//sing UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
    public class AudioPlaybacker : MonoBehaviour
    {

        #region Public Properties

        #endregion

        #region Private Properties

        #endregion

        #region Public Variables
        [SerializeField]
        public GameObject gameObject;
        #endregion

        #region Private Variables
        [SerializeField]
        private KeyCode _PlaybackSoundStartKey = KeyCode.S;

        private AudioSource recorder;
        #endregion

        #region Photon Messages

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods	

        void Awake()
        {

        }

        void Start()
        {
            recorder = gameObject.GetComponent<AudioSource>();
        }


        void Update()
        {
            if (Input.GetKeyDown(_PlaybackSoundStartKey))
            {
                recorder.Play();
            }
        }

        #endregion
    }
}