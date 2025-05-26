using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public GameObject garbageTruck;
    public GameObject schoolBuss;
    public GameObject medic;
    public GameObject cement;
    public GameObject e46;
    public GameObject e61;
    public GameObject b2;
    public GameObject Policija;
    public GameObject Eskavators;
    public GameObject Traktors1;
    public GameObject Traktors5;
    public GameObject Ugunsdzeseji;
    public bool isGarbagePlaced;
    public bool isMedicPlaced;
    public bool isSchoolBuss;
    public bool isCement;
    public bool isE46;
    public bool isE61;
    public bool isB2;
    public bool isPolicija;
    public bool isEskavators;
    public bool isTraktors1;
    public bool isTraktors5;
    public bool isUgunsdzeseji;

    


    [HideInInspector]
    public Vector2 gTruckPos;
    [HideInInspector]
    public Vector2 sBussPos;
    [HideInInspector]
    public Vector2 medicPos;
    [HideInInspector]
    public Vector2 cementPos;
    [HideInInspector]
    public Vector2 e46Pos;
    [HideInInspector]
    public Vector2 e61Pos;
    [HideInInspector]
    public Vector2 b2Pos;
    [HideInInspector]
    public Vector2 PolicijaPos;
    [HideInInspector]
    public Vector2 EskavatorsPos;
    [HideInInspector]
    public Vector2 Traktors1Pos;
    [HideInInspector]
    public Vector2 Traktors5Pos;
    [HideInInspector]
    public Vector2 UgunsdzesejiPos;

    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [HideInInspector]
    public bool rightPlace =false;
    public GameObject lastDragged = null;
    void Start()
    {
        gTruckPos = garbageTruck.GetComponent<RectTransform>().localPosition;
        sBussPos = schoolBuss.GetComponent<RectTransform>().localPosition;
        medicPos = medic.GetComponent<RectTransform>().localPosition;
        cementPos = cement.GetComponent<RectTransform>().localPosition;
        e46Pos = e46.GetComponent<RectTransform>().localPosition;
        e61Pos = e61.GetComponent<RectTransform>().localPosition;
        b2Pos = b2.GetComponent<RectTransform>().localPosition;
        PolicijaPos = Policija.GetComponent<RectTransform>().localPosition;
        EskavatorsPos = Eskavators.GetComponent<RectTransform>().localPosition;
        Traktors1Pos = Traktors1.GetComponent<RectTransform>().localPosition;
        Traktors5Pos = Traktors5.GetComponent<RectTransform>().localPosition;
        UgunsdzesejiPos = Ugunsdzeseji.GetComponent<RectTransform>().localPosition;
    }
}
