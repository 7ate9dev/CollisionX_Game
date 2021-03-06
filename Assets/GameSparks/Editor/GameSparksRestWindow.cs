using UnityEditor;
using UnityEngine;
[InitializeOnLoad]
public class GameSparksRestWindow : EditorWindow
{
	string userName="";
	string password="";
	string shortCode="";
	string fileName = "Select File";
	string result="";

	// Add menu item named "My Window" to the Window menu
	[MenuItem("GameSparks/REST Api")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(GameSparksRestWindow));
	}
	
	void OnGUI()
	{
		GUILayout.Label ("Binary Content", EditorStyles.boldLabel);
		shortCode = EditorGUILayout.TextField ("ShortCode", shortCode);


		EditorGUILayout.BeginHorizontal();
			userName = EditorGUILayout.TextField ("User Name", userName);
		password = EditorGUILayout.PasswordField ("Password", password);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();

		if(GUILayout.Button("GET")){
			result = GameSparksRestApi.getDownloadable(GameSparksSettings.ApiKey, userName, password, shortCode);
		}

		if(GUILayout.Button("POST")){
			result = GameSparksRestApi.setDownloadable(GameSparksSettings.ApiKey, userName, password, shortCode, fileName);
		}

		if(GUILayout.Button(fileName)){
			fileName = EditorUtility.OpenFilePanel("Select file to upload", "", "");
		}


		EditorGUILayout.EndHorizontal();
		GUILayout.Label ("REST Output", EditorStyles.label);
		GUILayout.TextArea(result, EditorStyles.textField);
	}
}