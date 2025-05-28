using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScriptlvl2 : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;
    public ObjectScriptlvl2 objectScript;
    public TimerScript2lvl timerScript;


    public void OnDrop(PointerEventData eventData)
    {

        if ((eventData.pointerDrag != null) && Input.GetMouseButtonUp(0)
            && Input.GetMouseButton(2) == false)
        {


            if (eventData.pointerDrag.tag.Equals(tag))
            {

                placeZRotation =
                eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;

                carZRotation = GetComponent<RectTransform>().transform.eulerAngles.z;

                difZRotation = Mathf.Abs(placeZRotation - carZRotation);
                Debug.Log("Dif Z Rotation: " + difZRotation);

                placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
                carSize = GetComponent<RectTransform>().localScale;
                xSizeDif = Mathf.Abs(placeSize.x - carSize.x);
                ySizeDif = Mathf.Abs(placeSize.y - carSize.y);
                Debug.Log("Dif X Size: " + xSizeDif + " Dif Y Size: " + ySizeDif);

                if ((difZRotation <= 10 || (difZRotation >= 350 && difZRotation <= 360)) &&
                    (xSizeDif <= 0.3 && ySizeDif <= 0.3))
                {
                    Debug.Log("Right Place");
                    objectScript.rightPlace = true;
                    timerScript.CheckVictoryCondition();


                    // Iecentrē pozīciju
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        GetComponent<RectTransform>().anchoredPosition;

                    // Pielāgo rotāciju
                    eventData.pointerDrag.GetComponent<RectTransform>().localRotation =
                        GetComponent<RectTransform>().localRotation;

                    // Pielāgo izmēru
                    eventData.pointerDrag.GetComponent<RectTransform>().localScale =
                        GetComponent<RectTransform>().localScale;

                    switch (eventData.pointerDrag.tag)
                    {
                        case "Velo":
                            objectScript.isVeloGPlaced = true;
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[2]);
                            break;

                        case "touring":
                            objectScript.isTouringPlaced = true;
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[4]);
                            break;

                        case "Custom":
                            objectScript.isCustomPlaced = true;
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "CarPol":
                            objectScript.isCarPolPlaced = true;
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[5]);
                            break;
                        case "humavee":
                            objectScript.isHumaveePlaced = true;
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[6]);
                            break;
                        case "CarTopless":
                            objectScript.isCarToplessPlaced = true;
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[7]);
                            break;
                        case "Motobike":
                            objectScript.isMotobikePlaced = true;
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[8]);
                            break;

                        default:
                            Debug.LogError("Unknown tag!");
                            break;
                    }
                }

            }
            else
            {
                objectScript.rightPlace = false;

                objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);

                switch (eventData.pointerDrag.tag)
                {
                    case "Velo":
                        objectScript.VeloG.GetComponent<RectTransform>().localPosition
                            = objectScript.VelogPos;
                        break;

                    case "touring":
                        objectScript.touring.GetComponent<RectTransform>().localPosition
                            = objectScript.TouringPos;
                        break;

                    case "Custom":
                        objectScript.Custom.GetComponent<RectTransform>().localPosition
                             = objectScript.CustomPos;
                        break;
                    case "CarPol":
                        objectScript.CarPol.GetComponent<RectTransform>().localPosition
                             = objectScript.CarPolPos;
                        break;
                    case "humavee":
                        objectScript.humavee.GetComponent<RectTransform>().localPosition
                             = objectScript.HumaveePos;
                        break;
                    case "CarTopless":
                        objectScript.carTopless.GetComponent<RectTransform>().localPosition
                             = objectScript.CarToplessPos;
                        break;
                    case "Motobike":
                        objectScript.Motobike.GetComponent<RectTransform>().localPosition
                             = objectScript.MotobikePos;
                        break;
                    

                    default:
                        Debug.LogError("Unknown tag!");
                        break;
                }
                timerScript.CheckVictoryCondition();

            }
        }
    }
}