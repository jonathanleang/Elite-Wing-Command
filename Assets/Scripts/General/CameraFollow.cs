using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] string cameraFollowObjectName = "Player Aircraft";
	[SerializeField] float cameraHeight = 35f;
	[SerializeField] float cameraFollowSpeed = 1f;
	GameObject playerAircraft;
	Vector3 wantedPosition;
	bool haveFound = false;
	const float moveMultiplier = 2f;

	void Start()
	{
		if (playerAircraft != null)
		{
			haveFound = true;
			wantedPosition = playerAircraft.transform.position;
			wantedPosition.y = cameraHeight;
			transform.position = wantedPosition;
		}
	}

	void LateUpdate()
	{
		playerAircraft = GameObject.Find(cameraFollowObjectName);

		if (playerAircraft != null)
		{
			if (haveFound)
			{
				wantedPosition = playerAircraft.transform.position;
				wantedPosition.y = cameraHeight;
				transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * cameraFollowSpeed);
			}
			else
			{
				wantedPosition = playerAircraft.transform.position;
				wantedPosition.y = cameraHeight;
				transform.position = wantedPosition;
				haveFound = true;
			}
		}
		else
			haveFound = false;
	}
}
