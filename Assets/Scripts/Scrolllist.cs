using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scrolllist : MonoBehaviour {


	public GameObject ScrollEntry;
	public GameObject ScrollContain;
	public int yourPosition;
	public GameObject LoadingText;
	public bool loading = true;



	public void getScrollEntrys()
	{
		//Destroy Objects that exists, because of a possible Call bevore
		foreach (Transform childTransform in ScrollContain.transform) Destroy(childTransform.gameObject);

		int j = 1;
		for (int i=0; i< DBManager.besttimes.Length-1; i++) {
			GameObject ScorePanel;
			ScorePanel = Instantiate (ScrollEntry) as GameObject;
            ScorePanel.transform.SetParent(ScrollContain.transform);
			ScorePanel.transform.localScale = ScrollContain.transform.localScale;

			Transform ThisScorePosition = ScorePanel.transform.Find ("ScorePosition");
			Text ScorePosition = ThisScorePosition.GetComponent<Text> ();
            Transform ThisScoreName = ScorePanel.transform.Find("ScoreText");
            Text ScoreName = ThisScoreName.GetComponent<Text>();
            //
            Transform ThisScorePoints = ScorePanel.transform.Find("ScorePoints");
            Text ScorePoints = ThisScorePoints.GetComponent<Text>();

            ScorePosition.text = j+". ";
			string helpString = "";

			helpString = helpString+ DBManager.besttimes[i]+" ";
			i++;

			ScoreName.text = helpString;

			
			ScorePoints.text = DBManager.besttimes[i] + "s";

			j++;

		}

	}
}
