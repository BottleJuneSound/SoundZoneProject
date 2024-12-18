using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioResource ambiWind;
    public AudioResource ambiWater;

    public AudioSource[] audioSourceArray;

    public bool audioArray00 = false;
    public bool audioArray01 = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AmbiWindSFX()
    {
        if(audioArray00) return;
        audioArray00 = true;
        audioSourceArray[0].resource = ambiWind;
        audioSourceArray[0].loop = true;
        audioSourceArray[0].Play();
    }

    public void AmbiWaterSFX()
    {
        if (audioArray01) return;
        audioArray01 = true;
        audioSourceArray[1].resource = ambiWater;
        audioSourceArray[1].loop = true;
        audioSourceArray[1].Play();
    }


}
