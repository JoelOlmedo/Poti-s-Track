using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
	public Conductor conductor;

	// We keep the start and end positionX to perform interpolation.
	public float startY;
	public float endY;
	public float removeLineY;
	public float beat;

	public Color hitColor;
	public Color missColor;
	private SpriteRenderer spriteRenderer;

	public void Initialize(Conductor conductor, float startY, float endY, float removeLineY, float posX, float beat)
	{
		this.conductor = conductor;
		this.startY = startY;
		this.endY = endY;
		this.beat = beat;
		this.removeLineY = removeLineY;

		// Set to initial position.
		transform.position = new Vector2(startY, posX);

		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		transform.position = new Vector2(transform.position.x, startY + (endY - startY) * (1f - (beat - conductor.songposition / conductor.secondsPerBeat) / conductor.BeatsShownOnScreen));

		// Remove itself when out of the screen (remove line).
		if (transform.position.y < removeLineY)
		{
			Destroy(gameObject);
		}
	}

	// Change the color to indicate whether its a "HIT" or a "MISS".
	public void ChangeColor(bool hit)
	{
		if (hit)
		{
			spriteRenderer.color = hitColor;
		}
		else
		{
			spriteRenderer.color = missColor;
		}
	}
}
