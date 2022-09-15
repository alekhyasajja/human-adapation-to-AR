using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class SPz : MonoBehaviour
{
    public string spz;
    public GameObject SPGOz;
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


    // Update is called once per frame
    void Update()
    {

        string messagespz = SPGOz.transform.position.z.ToString();


        spz = messagespz.Substring(0, 5);

        byte[] data = Encoding.UTF8.GetBytes(spz);
        client.Send(data, data.Length, remoteEndPoint);

        UnityEngine.Debug.Log(message);

    }
}

