using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotator : MonoBehaviour
{
    public float rotationSpeedMin = .1f;
    public float rotationSpeedMax = 1f;
    private float rotationSpeed;
    AudioSource thisAudio;
    private float previousRotation;
    Vector3 startingRotation;
    float rotationTime;

    // Start is called before the first frame update
    void Start()

    {
        // set the random starting rotation
        startingRotation = new Vector3(0, Random.Range(0, 360), 0);
        transform.eulerAngles = startingRotation;
        //set the rotation speed
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        rotationTime = Random.Range(rotationSpeedMin, rotationSpeedMax);
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            thisAudio = GetComponent<AudioSource>();
        }

        InvokeRepeating("rotateSound", 0f, rotationTime);
    }

    // Update is called once per frame
    void Update()
    {/*
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

        
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            if (transform.eulerAngles.y == 0f previousRotation)
            {
                thisAudio.Play();
                Vector3 currentScale = transform.localScale;
                transform.GetChild(0).transform.DOPunchScale(currentScale * 1.1f, 0.5f,0,1f);
            }

        }

            previousRotation = transform.eulerAngles.y;
       */ 
    }
    void rotateSound()
    {
        Vector3 targetRotation = new Vector3(0, 360f, 0);
        Tween spin = transform.DOLocalRotate(targetRotation, rotationTime, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCirc);
        Vector3 currentScale = transform.localScale;
        transform.GetChild(0).transform.DOPunchScale(currentScale * 1.1f, 0.5f, 0, 1f).SetDelay(rotationTime / 2f).OnPlay(playRotateSound);
        Debug.Log("spin");
    }
    void playRotateSound()
    {
        thisAudio.Play();
    }
}
