using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScript : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;
    public ObjectScript objectScript;

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
                        case "Garbage":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[2]);
                            break;

                        case "Medic":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[4]);
                            break;

                        case "School":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;

                        case "Cement":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[5]);
                            break;
                        case "e46":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[6]);
                            break;
                        case "e61":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[7]);
                            break;
                        case "b2":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[8]);
                            break;
                        case "Policija":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[9]);
                            break;
                        case "Eskavators":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[10]);
                            break;
                        case "Traktors":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[11]);
                            break;
                        case "Traktors5":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[12]);
                            break;
                        case "Ugunsdzeseji":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[13]);
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
                    case "Garbage":
                        objectScript.garbageTruck.GetComponent<RectTransform>().localPosition
                            = objectScript.gTruckPos;
                        break;

                    case "Medic":
                        objectScript.medic.GetComponent<RectTransform>().localPosition
                            = objectScript.medicPos;
                        break;

                    case "School":
                        objectScript.schoolBuss.GetComponent<RectTransform>().localPosition
                             = objectScript.sBussPos;
                        break;
                    case "Cement":
                        objectScript.cement.GetComponent<RectTransform>().localPosition
                             = objectScript.cementPos;
                        break;
                    case "e46":
                        objectScript.e46.GetComponent<RectTransform>().localPosition
                             = objectScript.e46Pos;
                        break;
                    case "e61":
                        objectScript.e61.GetComponent<RectTransform>().localPosition
                             = objectScript.e61Pos;
                        break;
                    case "b2":
                        objectScript.b2.GetComponent<RectTransform>().localPosition
                             = objectScript.b2Pos;
                        break;
                    case "Policija":
                        objectScript.Policija.GetComponent<RectTransform>().localPosition
                             = objectScript.PolicijaPos;
                        break;
                    case "Eskavators":
                        objectScript.Eskavators.GetComponent<RectTransform>().localPosition
                             = objectScript.EskavatorsPos;
                        break;
                    case "Traktors":
                        objectScript.Traktors1.GetComponent<RectTransform>().localPosition
                             = objectScript.Traktors1Pos;
                        break;
                    case "Traktors5":
                        objectScript.Traktors5.GetComponent<RectTransform>().localPosition
                             = objectScript.Traktors5Pos;
                        break;
                    case "Ugunsdzeseji":
                        objectScript.Ugunsdzeseji.GetComponent<RectTransform>().localPosition
                             = objectScript.UgunsdzesejiPos;
                        break;

                    default:
                        Debug.LogError("Unknown tag!");
                        break;
                }

            }
        }
    }
}