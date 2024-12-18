using UnityEngine;

public class LoopZone : MonoBehaviour
{
    bool isPlaying = false;
    bool hasPlaying = false;
    float targetVol = 0;
    AudioSource loopSource;

    void Start()
    {
        loopSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (targetVol > 0f)
        {
            if(loopSource.volume == 1f) return;
            loopSource.volume += Time.deltaTime * 2;

            //Debug.Log(loopSource.volume);
        }
        else if (targetVol == 0f)
        {
            if (loopSource.volume == 0f) return;
            loopSource.loop = false;
            loopSource.volume -= Time.deltaTime * 2;
            isPlaying = false;
            hasPlaying = false;
            Debug.Log("���̵� �ƿ� " + loopSource.volume);

            if (loopSource.volume <= 0)
            {
                loopSource.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isPlaying)
        {
            if(hasPlaying) return;
            loopSource.volume = 0;
            targetVol = 1f;
            loopSource.loop = true;
            loopSource.Play();
            isPlaying = true;
            hasPlaying = true;

            if(loopSource.volume <= 1)
            {
                loopSource.loop = false;
                hasPlaying = false;
            }


            //loopSource.Play();

            //VolFadeIn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && isPlaying)
        {
            if (hasPlaying) return;
            if (targetVol == 0) return;

            //loopSource.volume = 1;
            loopSource.loop = true;
            Debug.Log("������ �۵���");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasPlaying) return;
        if (other.tag == "Player" && isPlaying)
        {
            loopSource.loop = false;
            targetVol = 0f;
            //loopSource.Play();

            //VolFadeOut();
            Debug.Log("����Ʈ Ÿ�� ���� "+ targetVol);
        }
    }

    //void VolFadeIn()
    //{
    //    if (!isPlaying)
    //    {
    //        if (hasPlaying) return;
    //        loopSource.Play();
    //        loopSource.loop = false;
    //        loopSource.volume += Time.deltaTime * 10;
    //        isPlaying = true;
    //        hasPlaying = true;
    //        //Debug.Log(loopSource.volume);
    //    }
    //}

    //void VolFadeOut()
    //{
    //    if (isPlaying)
    //    {
    //        if(!hasPlaying) return;
    //        loopSource.Play();
    //        loopSource.loop = false;
    //        loopSource.volume -= Time.deltaTime * 10;
    //        isPlaying = false;
    //        hasPlaying = false;
    //        //Debug.Log(loopSource.volume);

    //        if (loopSource.volume <= 0)
    //        {
    //            loopSource.Stop();
    //        }

    //    }
    //}

}
