using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KenongMetricRotator : MonoBehaviour
{
   // public float orbitalDistance = 1f;
    public float animationDistance = .2f;
    public Ease setEase = Ease.OutSine;
    public int[] pattern = new int[] { 1, 1, 1, 1, 1 };
    private int counter = 0;
    public float tempoBPM = 40f;

    public float soundDelay = 2f;
    public float punchScale = .1f;




    
    
    AudioSource thisAudio;
  
    Vector3 startingRotation;
    float rotationTime;

    GameObject child;
    // Start is called before the first frame update

    void Start()
    {
        int beatCounter = 0;

        foreach (int beat in pattern){
            pattern[beatCounter] = (int)Random.Range(0, 2);
            beatCounter++;
        }
        float sizeVolumeValue = Random.Range(.3f, 1f);
        //randomly flip direction
        if (Random.Range(0,100) < 50)
        {
            animationDistance = animationDistance * -1;
            transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(90, 0, 0);
           
            transform.GetChild(0).gameObject.transform.localScale = new Vector3(sizeVolumeValue, sizeVolumeValue, sizeVolumeValue);
            

        }


        //cache the Child gameobject
      // child = transform.GetChild(0).gameObject;
        //move that Child to the orbital distance
       // child.transform.localPosition = new Vector3(0, 0, orbitalDistance);

        //calculate rotation time
        rotationTime = (60f / tempoBPM) * Mathf.Abs(animationDistance)  /*+ Random.RandomRange(0f,5) */;
        Debug.Log(rotationTime);


        // set the random starting rotation
        startingRotation = new Vector3(0, Random.Range(0, 360), 0);
        transform.eulerAngles = startingRotation;
        //set the rotation speed
      
        //get the audioSource
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            thisAudio = GetComponent<AudioSource>();
            thisAudio.volume = sizeVolumeValue;
            thisAudio.pitch = 1f + Random.Range(-0.01f, 0.01f);
        }

        InvokeRepeating("rotateSound", 0f, rotationTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void rotateSound()
    {
        counter++;

        if (pattern[counter % pattern.Length] == 1)
        {
            Vector3 targetRotation = new Vector3(0, 360f * animationDistance, 0);
            Tween spin = transform.DOLocalRotate(targetRotation, rotationTime * .9f, RotateMode.LocalAxisAdd).SetEase(setEase).OnPlay(playRotateSound);
            Vector3 currentScale = transform.localScale;
           // transform.GetChild(0).gameObject.transform.DOPunchScale(new Vector3(punchScale,punchScale,punchScale), .1f, 0, 1f).);
            //Debug.Log("spin " + rotationTime);
        }
    }
    void playRotateSound()
    {
        thisAudio.PlayOneShot(thisAudio.clip);
        //thisAudio.Play();
    }
}
