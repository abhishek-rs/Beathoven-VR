using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;

public class Cube : MonoBehaviour {

	public GameObject cubePrefab;
	public float Multiplier;
	public int bin;
	public AudioSource AS;
	public bool Clockwise = true;
	public float smoothTime = 0.3F;
    private float yVelocity = 0.0F;
    public Color color;

    public string m_IPAdress = "130.233.85.63";
    public const int kPort = 1234;
 
    private static TcpClient singleton;
 
   
    private Socket m_Socket;

  /*  void Awake ()
    {
        Socket m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
 
        // System.Net.PHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
        // System.Net.IPAddress remoteIPAddress = ipHostInfo.AddressList[0];
        System.Net.IPAddress remoteIPAddress  = System.Net.IPAddress.Parse(m_IPAdress);
       
        System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, kPort);
 
        singleton = this;
        m_Socket.Connect(remoteEndPoint);
    }
   
    void OnApplicationQuit ()
    {
        m_Socket.Close();
        m_Socket = null;
    }
   
    static public void Send(string msgData)
    {
        if (singleton.m_Socket == null)
            return;
 
    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        byte[] sendData = encoding.GetBytes(msgData);
        byte[] prefix = new byte[1];
        prefix[0] = (byte)sendData.Length;
        singleton.m_Socket.Send(prefix);
        singleton.m_Socket.Send(sendData);
    
 
 
}*/



	// Use this for initialization
	void Start () {
   	this.GetComponent<Renderer>().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		int num = 128;
		//float[] spectrum = AS.GetSpectrumData(num, 0, FFTWindow.BlackmanHarris);
	//	transform.localEulerAngles = new Vector3(0,0,0);

	//	byte[] bytes = m_Socket.Receive(bytesReceived, bytesReceived.Length, 0);
	//	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
	//	string sendData = encoding.GetString(bytesReceived);

		float[] spectrum = new float[128];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
	/*	float value = spectrum[0] * Multiplier;
		float value1 = spectrum[1] * Multiplier;
		float value2 = spectrum[2] * Multiplier;
*/

		float value = spectrum[bin] * Multiplier;
		

		//Debug.Log(value + "," + value1 + "," + value2 + "," + Multiplier);

		Vector3 newScale = this.transform.localScale;
		 
		 float newScale1 = Mathf.SmoothDamp(5, value, ref yVelocity, smoothTime);
	//	 float newScale2 = Mathf.SmoothDamp(5, value, ref yVelocity, smoothTime);
	//	 float newScale3 = Mathf.SmoothDamp(5, value, ref yVelocity, smoothTime);
		 newScale.y = newScale1;
		 newScale.x = newScale1;
		 newScale.z = newScale1;

		/* if(value > 50)
		 	this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
		 else if(value > 10)
		 	this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));
		 else
		 	this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, Mathf.PingPong(Time.time, 1));
*/

		 this.transform.localScale = newScale;
		 this.transform.Rotate(new Vector3(value/100,value/100,value/100));
	/*	float newY = ( * Multiplier) + 10;
		newScale.y = Mathf.Lerp(0.0f, newY, 0.5f);
		this.transform.localScale = newScale;*/
	}
}
