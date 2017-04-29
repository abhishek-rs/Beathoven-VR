using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net.Sockets;
using System;

public class MainMenuScript : MonoBehaviour {

	internal Boolean socketReady = false;

	TcpClient mySocket;
 
    NetworkStream theStream;
 
    StreamWriter theWriter;
 
    StreamReader theReader;
 
    String Host = "10.100.21.137";
 
    Int32 Port = 5204;



	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);

		if (!socketReady)
 
        {  
 
             setupSocket();
 			writeSocket(ApplicationModel.currentSong.ToString() + ApplicationModel.currentSong.ToString());
             
        }

        else writeSocket(ApplicationModel.currentSong.ToString() + ApplicationModel.currentSong.ToString());


        closeSocket();
	}

	public void setupSocket()
 
    {
 
        try
 
        {
 
            mySocket = new TcpClient(Host, Port);
 
            theStream = mySocket.GetStream();
 
            theWriter = new StreamWriter(theStream);
 
            theReader = new StreamReader(theStream);
 
            socketReady = true;
 
        }
 
 
 
        catch (Exception e)
 
        {
 
            Debug.Log("Socket error: " + e);
 
        }
 
    }


     public void writeSocket(string theLine)
 
    {
 
        if (!socketReady)
 
            return;
 
        String foo = theLine + "\r\n";
 
        theWriter.Write(foo);
 
        theWriter.Flush();
 
    }



        public void closeSocket()
 
    {
 
        if (!socketReady)
 
            return;
 
        theWriter.Close();
 
        theReader.Close();
 
        mySocket.Close();
 
        socketReady = false;
 
    }
 
        


}
