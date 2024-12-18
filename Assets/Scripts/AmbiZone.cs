using UnityEngine;
using UnityEngine.Audio;

public class AmbiZone : MonoBehaviour
{
    AudioSource ambiWind;

    public bool isPlaying = false;
    void Start()
    {
        ambiWind = GetComponent<AudioSource>();
        isPlaying = true;
        ambiWind.loop = true;
        ambiWind.Play();
    }

    public void Awake()
    {

    }

    void Update()
    {
        //if (isPlaying) return;
        //isPlaying = true;
        //ambiWind.loop = true;
        //ambiWind.Play();
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player" && !isPlaying)
    //    {
    //        if (isPlaying) return;
    //        isPlaying = true;
    //        ambiWind.loop = true;
    //        ambiWind.Play();
    //    }
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        ambiWind.loop = false;
    //        ambiWind.Stop();
    //    }
    //}

}
