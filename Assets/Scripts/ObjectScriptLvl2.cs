using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScriptlvl2 : MonoBehaviour
{
    public GameObject VeloG;
    public GameObject touring;
    public GameObject Custom;
    public GameObject CarPol;
    public GameObject humavee;
    public GameObject carTopless;
    public GameObject Motobike;


    
    public bool isVeloGPlaced;
    public bool isTouringPlaced;
    public bool isCustomPlaced;
    public bool isCarPolPlaced;
    public bool isHumaveePlaced;
    public bool isCarToplessPlaced;
    public bool isMotobikePlaced;


    [HideInInspector]
    public Vector2 VelogPos;
    [HideInInspector]
    public Vector2 TouringPos;
    [HideInInspector]
    public Vector2 CustomPos;
    [HideInInspector]
    public Vector2 CarPolPos;
    [HideInInspector]
    public Vector2 HumaveePos;
    [HideInInspector]
    public Vector2 CarToplessPos;
    [HideInInspector]
    public Vector2 MotobikePos;

    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [HideInInspector]
    public bool rightPlace =false;
    public GameObject lastDragged = null;
    void Start()
    {
        VelogPos = VeloG.GetComponent<RectTransform>().localPosition;
        TouringPos = touring.GetComponent<RectTransform>().localPosition;
        CustomPos = Custom.GetComponent<RectTransform>().localPosition;
        CarPolPos = CarPol.GetComponent<RectTransform>().localPosition;
        HumaveePos = humavee.GetComponent<RectTransform>().localPosition;
        CarToplessPos = carTopless.GetComponent<RectTransform>().localPosition;
        MotobikePos = Motobike.GetComponent<RectTransform>().localPosition;
    }
}
