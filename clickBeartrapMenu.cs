using UnityEngine;
using UnityEngine.EventSystems;

public class clickBeartrapMenu : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public GameObject granny;

	public GameObject beartrapOpen;

	public GameObject beartrapClose;

	public GameObject SoundHolder;

	public bool beartrapOK;

    public void Start()
    {
		granny.GetComponent<Animation>().CrossFade("Look");
    }
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.pointerCurrentRaycast.gameObject != null && !beartrapOK)
		{
			beartrapOK = true;
			beartrapClose.SetActive(true);
			((ButtonClicks)SoundHolder.GetComponent(typeof(ButtonClicks))).beartrap();
			beartrapOpen.SetActive(false);
		}
	}
}
