using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
    public class ButtonController : MonoBehaviour
    {

        #region Public Properties

        #endregion

        #region Private Properties

        #endregion

        #region Public Variables

        #endregion

        #region Private Variables

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

        }


        void Update()
        {

        }

        public void GotoRehearsal()
        {
            SceneManager.LoadScene("RehearsalScene");
        }

        public void GotoRehearsalStarter()
        {
            SceneManager.LoadScene("RehearsalStarterScene");
        }

        public void GotoPlayback()
        {
            SceneManager.LoadScene("PlaybackScene");
        }

        #endregion
    }
}

