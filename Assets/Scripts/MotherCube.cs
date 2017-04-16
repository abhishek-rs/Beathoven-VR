using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCube : MonoBehaviour {

	public GameObject cubePrefab;
    public float Multiplier;
    public int bin;
   // public AudioSource AS;
    Object[] myMusic;
    public bool Clockwise = true;
    public float smoothTime = 0.5F;
    private float yVelocity = 0.0F;
    //public Color color;

    void Awake(){
    
    }
    
    void Start()
    {
      
    }

    void Update()
    {
        int num = 128;
        float[] spectrum = new float[num];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        float value = spectrum[bin] * Multiplier;
    //    float value1 = spectrum[1] * Multiplier;
    //    float value2 = spectrum[2] * Multiplier;
        //float value = spectrum[bin] * Multiplier;


        //Debug.Log(value + "," + value1 + "," + value2 + "," + Multiplier);

        Vector3 newScale = this.transform.localScale;

        float newScale1 = Mathf.SmoothDamp(1, value, ref yVelocity, smoothTime);
       // float newScale2 = Mathf.SmoothDamp(1, value, ref yVelocity, smoothTime);
       // float newScale3 = Mathf.SmoothDamp(1, value, ref yVelocity, smoothTime);
        newScale.y = newScale1;
      //  newScale.x = newScale2;
      //  newScale.z = newScale3;

        if(ApplicationModel.songs[ApplicationModel.currentSong, 0] == 1.00){
            this.GetComponent<Renderer>().material.color = Color.Lerp( new Color( 1.0f, 0.549f, 0.0f, 1.0f), Color.yellow, Mathf.PingPong(Time.time, 1));
        }
        else{
            this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));
        }




     /*   if (value > 50)
            this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
        else if (value > 10 && value < 50)
            this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));
        else
            this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, Mathf.PingPong(Time.time, 1));
*/

        this.transform.localScale = newScale;
    //    this.transform.Rotate(new Vector3(value / 100, value1 / 100, value2 / 100));
        /*	float newY = ( * Multiplier) + 10;
            newScale.y = Mathf.Lerp(0.0f, newY, 0.5f);
            this.transform.localScale = newScale;*/
    }
}
