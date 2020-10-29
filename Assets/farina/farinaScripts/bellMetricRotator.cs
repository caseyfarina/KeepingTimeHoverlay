using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class bellMetricRotator : MonoBehaviour
{
   // public float orbitalDistance = 1f;
    public float animationDistance = .2f;
    public int[] pattern = new int[] { 1, 1, 1, 1, 1 };
    private int counter = 0;
    public float tempoBPM = 80f;
    public float subdivision = 1f;
    public float soundDelay = 2f;
    public float xRotationOffset = 0f;


    
    
    AudioSource thisAudio;
  
    Vector3 startingRotation;
    float rotationTime;

    GameObject child;
    // Start is called before the first frame update

    void Start()
    {
        //randomly flip direction
        if(Random.Range(0,100) < 50)
        {
            animationDistance = animationDistance * -1;
        }


        //cache the Child gameobject
      // child = transform.GetChild(0).gameObject;
        //move that Child to the orbital distance
       // child.transform.localPosition = new Vector3(0, 0, orbitalDistance);

        //calculate rotation time
        rotationTime = (60f / tempoBPM) * subdivision  /*+ Random.RandomRange(0f,5) */;
        Debug.Log(rotationTime);


        // set the random starting rotation
        startingRotation = new Vector3(0, Random.Range(0, 360), 0);
        transform.eulerAngles = startingRotation;
        //set the rotation speed
      
        //get the audioSource
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            thisAudio = GetComponent<AudioSource>();
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
            Vector3 targetRotation = new Vector3(xRotationOffset, 360f * animationDistance, 0);
            Tween spin = transform.DOLocalRotate(targetRotation, rotationTime * .9f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCirc);
            Vector3 currentScale = transform.localScale;
            transform.transform.DOPunchScale(Vector3.zero, rotationTime / 2f, 0, 1f).SetDelay((rotationTime * .9f) / soundDelay).OnPlay(playRotateSound);
            //Debug.Log("spin " + rotationTime);
        }
    }
    void playRotateSound()
    {
        thisAudio.Play();
    }
}
