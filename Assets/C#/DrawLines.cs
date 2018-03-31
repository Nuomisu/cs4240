using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour {

	// Choose the Unlit/Color shader in the Material Settings
	// You can change that color, to change the color of the connecting lines
	public Material lineMat;
	public Vector3 startPoint, endPoint;

	// Connects startPoint to endPoint
	public void DrawConnectingLines() {
		GL.Begin(GL.LINES);
		lineMat.SetPass(0);
		GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
		GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
		GL.Vertex3(endPoint.x, endPoint.y, endPoint.z);
		GL.End();
	}

	// To show the lines in the game window whne it is running
	void OnPostRender() {
		if (startPoint!=null && endPoint!=null) DrawConnectingLines();
	}

	// To show the lines in the editor
	void OnDrawGizmos() {
		if (startPoint!=null && endPoint!=null) DrawConnectingLines();
	}
}
