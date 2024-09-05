using UnityEngine;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class OpenLinkedInProfile : MonoBehaviour, IPointerClickHandler
{
    public string linkedInProfileURL = "https://www.linkedin.com/in/MykytaKolohryvko";

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenLink();
    }

    public void OpenLink()
    {
        Application.OpenURL(linkedInProfileURL);
    }
}
