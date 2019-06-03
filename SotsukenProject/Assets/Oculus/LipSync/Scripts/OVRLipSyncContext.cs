/************************************************************************************
Filename    :   OVRLipSyncContext.cs
Content     :   Interface to Oculus Lip-Sync engine
Created     :   August 6th, 2015
Copyright   :   Copyright 2015 Oculus VR, Inc. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.1 (the "License");
you may not use the Oculus VR Rift SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

http://www.oculusvr.com/licenses/LICENSE-3.1

Unless required by applicable law or agreed to in writing, the Oculus VR SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
************************************************************************************/
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

//-------------------------------------------------------------------------------------
// ***** OVRLipSyncContext
//
/// <summary>
/// OVRLipSyncContext interfaces into the Oculus phoneme recognizer.
/// This component should be added into the scene once for each Audio Source.
///
/// </summary>
public class OVRLipSyncContext : OVRLipSyncContextBase
{
    // * * * * * * * * * * * * *
    // Public members


    [Tooltip("Allow capturing of keyboard input to control operation.")]
    public bool enableKeyboardInput = false;
    [Tooltip("Register a mouse/touch callback to control loopback and gain (requires script restart).")]
    public bool enableTouchInput = false;
    [Tooltip("Play input audio back through audio output.")]
    public bool audioLoopback = false;
    [Tooltip("Key to toggle audio loopback.")]
    public KeyCode loopbackKey = KeyCode.L;
    [Tooltip("Show viseme scores in an OVRLipSyncDebugConsole display.")]
    public bool showVisemes = false;
    [Tooltip("Key to toggle viseme score display.")]
    public KeyCode debugVisemesKey = KeyCode.D;
    [Tooltip("Skip data from the Audio Source. Use if you intend to pass audio data in manually.")]
    public bool skipAudioSource = false;
    [Tooltip("Audio gain adjustment")]
    public float gain = 1.0f;

    private bool hasDebugConsole = false;


    // * * * * * * * * * * * * *
    // Private members

    /// <summary>
    /// Start this instance.
    /// Note: make sure to always have a Start function for classes that have editor scripts.
    /// </summary>
    void Start()
    {
        // Add a listener to the OVRTouchpad for touch events
        if (enableTouchInput)
        {
            OVRTouchpad.AddListener(LocalTouchEventCallback);
        }

        // Find console
        OVRLipSyncDebugConsole[] consoles = FindObjectsOfType<OVRLipSyncDebugConsole>();
        if (consoles.Length > 0)
        {
            hasDebugConsole = consoles[0];
        }
    }

    /// <summary>
    /// Handle keyboard input
    /// </summary>
    void HandleKeyboard()
    {
        // Turn loopback on/off
        if (Input.GetKeyDown(loopbackKey))
        {
            ToggleAudioLoopback();
        }
        else if (Input.GetKeyDown(debugVisemesKey))
        {
            showVisemes = !showVisemes;

            if (showVisemes)
            {
                if (hasDebugConsole)
                {
                    Debug.Log("DEBUG SHOW VISEMES: ENABLED");
                }
                else
                {
                    Debug.LogWarning("Warning: No OVRLipSyncDebugConsole in the scene!");
                    showVisemes = false;
                }
            }
            else
            {
                if (hasDebugConsole)
                {
                    OVRLipSyncDebugConsole.Clear();
                }
                Debug.Log("DEBUG SHOW VISEMES: DISABLED");
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gain -= 1.0f;
            if (gain < 1.0f) gain = 1.0f;

            string g = "LINEAR GAIN: ";
            g += gain;

            if (hasDebugConsole)
            {
                OVRLipSyncDebugConsole.Clear();
                OVRLipSyncDebugConsole.Log(g);
                OVRLipSyncDebugConsole.ClearTimeout(1.5f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gain += 1.0f;
            if (gain > 15.0f)
                gain = 15.0f;

            string g = "LINEAR GAIN: ";
            g += gain;

            if (hasDebugConsole)
            {
                OVRLipSyncDebugConsole.Clear();
                OVRLipSyncDebugConsole.Log(g);
                OVRLipSyncDebugConsole.ClearTimeout(1.5f);
            }
        }
    }

    /// <summary>
    /// Run processes that need to be updated in our game thread
    /// </summary>
    void Update()
    {
        if (enableKeyboardInput)
        {
            HandleKeyboard();
        }
        DebugShowVisemes();
    }


    /// <summary>
    /// Pass an audio sample to the lip sync module for computation
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="channels">Channels.</param>
    void ProcessAudioSamples(float[] data, int channels)
    {
        // Do not process if we are not initialized, or if there is no
        // audio source attached to game object
        if ((OVRLipSync.IsInitialized() != OVRLipSync.Result.Success) || audioSource == null)
            return;

        // Increase the gain of the input
        for (int i = 0; i < data.Length; ++i)
            data[i] = data[i] * gain;

        // Send data into Phoneme context for processing (if context is not 0)
        lock (this)
        {
            if (Context != 0)
            {

                OVRLipSync.Frame frame = this.Frame;
                OVRLipSync.ProcessFrameInterleaved(Context, data, frame);
            }
        }

        // Turn off output (so that we don't get feedback from mics too close to speakers)
        if (!audioLoopback)
        {
            for (int i = 0; i < data.Length; ++i)
                data[i] = data[i] * 0.0f;
        }
    }

    /// <summary>
    /// Raises the audio filter read event.
    /// </summary>
    /// <param name="data">Data.</param>
    /// <param name="channels">Channels.</param>
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!skipAudioSource)
        {
            ProcessAudioSamples(data, channels);
        }
    }

    /// <summary>
    /// Print the visemes to the game window
    /// </summary>
    void DebugShowVisemes()
    {
        if (hasDebugConsole)
        {
            string seq = "";
            if (showVisemes)
            {
                for (int i = 0; i < this.Frame.Visemes.Length; i++)
                {
                    seq += ((OVRLipSync.Viseme)i).ToString();
                    seq += ":";

                    int count = (int)(50.0f * this.Frame.Visemes[i]);
                    for (int c = 0; c < count; c++)
                        seq += "*";

                    seq += "\n";
                }
            }

            OVRLipSyncDebugConsole.Clear();

            if (seq != "")
            {
                OVRLipSyncDebugConsole.Log(seq);
            }
        }
    }

    void ToggleAudioLoopback()
    {
        audioLoopback = !audioLoopback;

        if (hasDebugConsole)
        {
            OVRLipSyncDebugConsole.Clear();
            OVRLipSyncDebugConsole.ClearTimeout(1.5f);

            if (audioLoopback)
                OVRLipSyncDebugConsole.Log("LOOPBACK MODE: ENABLED");
            else
                OVRLipSyncDebugConsole.Log("LOOPBACK MODE: DISABLED");
        }
    }

    // LocalTouchEventCallback
    void LocalTouchEventCallback(OVRTouchpad.TouchEvent touchEvent)
    {
        string g = "LINEAR GAIN: ";

        switch (touchEvent)
        {
            case (OVRTouchpad.TouchEvent.SingleTap):
                ToggleAudioLoopback();
                break;

            case (OVRTouchpad.TouchEvent.Up):
                gain += 1.0f;
                if (gain > 15.0f)
                    gain = 15.0f;

                g += gain;

                if (hasDebugConsole)
                {
                    OVRLipSyncDebugConsole.Clear();
                    OVRLipSyncDebugConsole.Log(g);
                    OVRLipSyncDebugConsole.ClearTimeout(1.5f);
                }

                break;

            case (OVRTouchpad.TouchEvent.Down):
                gain -= 1.0f;
                if (gain < 1.0f) gain = 1.0f;

                g += gain;

                if (hasDebugConsole)
                {
                    OVRLipSyncDebugConsole.Clear();
                    OVRLipSyncDebugConsole.Log(g);
                    OVRLipSyncDebugConsole.ClearTimeout(1.5f);
                }

                break;
        }
    }
}
