using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class HandPos : MonoBehaviour
{
    public float onTime;
    public float offTime;
    public int numFlashes;
    
    public string IP = "127.0.0.1"; //156.26.45.21, 255.255.255.255, 127.0.0.1
    public int portLocal = 8789;
    public int portRemote = 8012;

    UdpClient client;
    IPEndPoint remoteEndPoint;

    // Message to be sent
    //public string strMessageSend = "";

    public GameObject handPosOne;
    public GameObject handPosTwo;
    public GameObject handPosThree;
    public GameObject handPosFour;
   

    private Renderer rendOne;
    private Renderer rendTwo;
    private Renderer rendThree;
    private Renderer rendFour;
   

    public GameObject textOne;
    public GameObject textTwo;
    public GameObject textThree;
    public GameObject textFour;
   
    private Text one;
    private Text two;
    private Text three;
    private Text four;
  
    int counterOne = 0;
    int counterTwo = 0;
    int counterThree = 0;
    int counterFour = 0;
   
    int total = 1;
    int i;
    int num;

    public void Start()
    {
        init();

        rendOne = handPosOne.gameObject.GetComponent<Renderer>();
        rendTwo = handPosTwo.gameObject.GetComponent<Renderer>();
        rendThree = handPosThree.gameObject.GetComponent<Renderer>();
        rendFour = handPosFour.gameObject.GetComponent<Renderer>();

        rendOne.enabled = false;
        rendTwo.enabled = false;
        rendThree.enabled = false;
        rendFour.enabled = false;
        
        one = textOne.gameObject.GetComponent<Text>();
        two = textTwo.gameObject.GetComponent<Text>();
        three = textThree.gameObject.GetComponent<Text>();
        four = textFour.gameObject.GetComponent<Text>();

        one.enabled = false;
        two.enabled = false;
        three.enabled = false;
        four.enabled = false;
        
        StartCoroutine("Wait");
    }

    private void init()
    {
        print("UDP Object init()");

        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), portRemote);

        client = new UdpClient(portLocal);

    }

    void Update()
    {
        //total = counterOne + counterTwo + counterThree + counterFour + counterFive + counterSix + counterSeven;

        /*
        if (total == numFlashes*8)
        {
            Application.Quit();
        }
        */
    }

    IEnumerator Wait()
    {
        yield return (new WaitForSeconds(5));
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        while (total <= numFlashes *5)
        {
            i = UnityEngine.Random.Range(1, 5);

            switch (i)
            {
                case 1: //Pos 1
                    if (counterOne < numFlashes)
                    {
                        counterOne = counterOne + 1;
                        Debug.Log("Pos One " + counterOne);
                        Debug.Log("Total = " + total);
                        total = total + 1;

                        //sendData("1");
                       num = 1;
                        string message = num.ToString();
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        client.Send(data, data.Length, remoteEndPoint);

                        rendOne.enabled = true;
                        one.enabled = true;
                        yield return (new WaitForSeconds(onTime));

                        //sendData("f");
                        data = Encoding.ASCII.GetBytes("f");
                        client.Send(data, data.Length, remoteEndPoint);

                        rendOne.enabled = false;
                        one.enabled = false;
                        yield return (new WaitForSeconds(offTime + UnityEngine.Random.Range(0.5f, 1.0f)));
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2: //Pos 2
                    if (counterTwo < numFlashes)
                    {
                        counterTwo = counterTwo + 1;
                        Debug.Log("Pos Two " + counterTwo);
                        Debug.Log("Total = " + total);
                        total = total + 1;

                        //sendData("2");
                        num = 2;
                        string message = num.ToString();
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        client.Send(data, data.Length, remoteEndPoint);

                        rendTwo.enabled = true;
                        two.enabled = true;
                        yield return (new WaitForSeconds(onTime));

                        //sendData("f");
                        data = Encoding.ASCII.GetBytes("f");
                        client.Send(data, data.Length, remoteEndPoint);

                        rendTwo.enabled = false;
                        two.enabled = false;
                        yield return (new WaitForSeconds(offTime + UnityEngine.Random.Range(0.5f, 1.0f)));
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 3: //Pos 3
                    if (counterThree < numFlashes)
                    {
                        counterThree = counterThree + 1;
                        Debug.Log("Pos Three " + counterThree);
                        Debug.Log("Total = " + total);
                        total = total + 1;

                        //sendData("3");
                        num = 3;
                        string message = num.ToString();
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        client.Send(data, data.Length, remoteEndPoint);
                        
                        rendThree.enabled = true;
                        three.enabled = true;
                        yield return (new WaitForSeconds(onTime));

                        //sendData("f");
                        data = Encoding.ASCII.GetBytes("f");
                        client.Send(data, data.Length, remoteEndPoint);

                        rendThree.enabled = false;
                        three.enabled = false;
                        yield return (new WaitForSeconds(offTime + UnityEngine.Random.Range(0.5f, 1.0f)));
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 4: //Pos 4
                    if (counterFour < numFlashes)
                    {
                        counterFour = counterFour + 1;
                        Debug.Log("Pos Four " + counterFour);
                        Debug.Log("Total = " + total);
                        total = total + 1;

                        //sendData("4");
                        num = 4;
                        string message = num.ToString();
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        client.Send(data, data.Length, remoteEndPoint);
                        
                        rendFour.enabled = true;
                        four.enabled = true;
                        yield return (new WaitForSeconds(onTime));

                        //sendData("f");
                        data = Encoding.ASCII.GetBytes("f");
                        client.Send(data, data.Length, remoteEndPoint);

                        rendFour.enabled = false;
                        four.enabled = false;
                        yield return (new WaitForSeconds(offTime + UnityEngine.Random.Range(0.5f, 1.0f)));
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }
    }

    /*
    string message = num.ToString();

    byte[] data = Encoding.UTF8.GetBytes(message);
    client.Send(data, data.Length, remoteEndPoint);
    */

   /* private void sendData(string message)
    {
        Debug.Log("Send " + message);
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);

        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }*/
    
}
