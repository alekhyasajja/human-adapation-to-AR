using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeap.Core.StarterKit;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MagicLeap
{
    /// <summary>
    /// Class outputs to input UI.Text the most up to date gestures
    /// and confidence values for each of the hands.
    /// </summary>
    public class HandTrackingExample : MonoBehaviour
    {

        Vector3 pos;
        string message;

        private static int localport;

        private string IP;
        public int port;

        IPEndPoint remoteEndPoint;
        UdpClient client;

        // Start is called before the first frame update
        void Start()
        {
            IP = "127.0.0.1"; //lab com ip 156.26.45.21 ; jsky is 154.9.128.66
                              //port = 5100;

            remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
            client = new UdpClient();
        }
        [SerializeField, Tooltip("Text to display gesture status to.")]
        private Text _statusText = null;

        /// <summary>
        /// Validates fields.
        /// </summary>
        void Awake()
        {
            if (_statusText == null)
            {
                UnityEngine.Debug.LogError("Error: HandTrackingExample._statusText is not set, disabling script.");
                enabled = false;
                return;
            }
        }

        /// <summary>
        ///  Polls the Gestures API for up to date confidence values.
        /// </summary>
        void Update()
        {
            string message = MLHandTracking.Right.KeyPose.ToString();  //pos.x.ToString("f3") + " , " + pos.y.ToString("f3") + " , " + pos.z.ToString("f3");

            byte[] data = Encoding.ASCII.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);

            UnityEngine.Debug.Log(message);


#if PLATFORM_LUMIN
            _statusText.text += string.Format(
                "<color=#dbfb76><b>{0}</b></color>\n<color=#dbfb76>{1}</color>: {2}\n{3}% {4}\n\n<color=#dbfb76>{5}</color>: {6}\n{7}% {8}",
                LocalizeManager.GetString("HandsData"),
                LocalizeManager.GetString("Left"),
                MLHandTracking.Left.KeyPose.ToString(),
                (MLHandTracking.Left.HandKeyPoseConfidence * 100.0f).ToString("n0"),
                LocalizeManager.GetString("Confidence"),
                LocalizeManager.GetString("Right"),
                MLHandTracking.Right.KeyPose.ToString(),
                (MLHandTracking.Right.HandKeyPoseConfidence * 100.0f).ToString("n0"),
                LocalizeManager.GetString("Confidence"));
#endif
        }
    }
}


