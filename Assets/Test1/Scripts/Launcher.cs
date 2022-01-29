using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
	[SerializeField] Text connectionstatus;
	[SerializeField] InputField username;
	public static Launcher Instance;
	[SerializeField] InputField roomNameInputField;
	[SerializeField] Text errorText;
	[SerializeField] Text roomNameText;
	[SerializeField] Transform roomListContent;
	[SerializeField] GameObject roomListItemPrefab;
	[SerializeField] Transform playerListContent;
	[SerializeField] GameObject PlayerListItemPrefab;
	[SerializeField] GameObject startGameButton;

	void Awake()
	{
		Instance = this;
	}
	public void usernameChanged()
	{
		PhotonNetwork.NickName=username.text;
		PlayerPrefs.SetString("username",username.text);
	}
	void Start()
	{
		if(PlayerPrefs.HasKey("username"))
		{
			username.text=PlayerPrefs.GetString("username");
			PhotonNetwork.NickName=PlayerPrefs.GetString("username");
		}
		else{
			username.text="Player "+Random.Range(0,10000).ToString("0000");
			usernameChanged();
		}
		if(!PhotonNetwork.IsConnected)
		{
			Debug.Log("Connecting to Master");
			connectionstatus.text="Connecting to Server Please Wait....";
			PhotonNetwork.ConnectUsingSettings();
		}
	}
	public void joinlobby()
	{
		MenuManager.Instance.OpenMenu("loadingmenu");
		PhotonNetwork.JoinLobby();
	}
	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Master");
		connectionstatus.text="Connected to Server";
		PhotonNetwork.AutomaticallySyncScene = true;
	}
	public override void OnJoinedLobby()
	{
		MenuManager.Instance.OpenMenu("titlemenu");
		connectionstatus.text="Join Lobby Successful...";
		Debug.Log("Joined Lobby");
	}
	public void CreateRoom()
	{
		if(string.IsNullOrEmpty(roomNameInputField.text))
		{
			return;
		}
		PhotonNetwork.CreateRoom(roomNameInputField.text);
		MenuManager.Instance.OpenMenu("loadingmenu");
	}
	public override void OnJoinedRoom()
	{
		MenuManager.Instance.OpenMenu("roommenu");
		connectionstatus.text="Join Room Successful...";
		roomNameText.text = PhotonNetwork.CurrentRoom.Name;

		Player[] players = PhotonNetwork.PlayerList;

		foreach(Transform child in playerListContent)
		{
			Destroy(child.gameObject);
		}

		for(int i = 0; i < players.Count(); i++)
		{
			Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
		}

		startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}
	public override void OnCreateRoomFailed(short returnCode, string message)
	{
		errorText.text = "Room Creation Failed: " + message;
		Debug.LogError("Room Creation Failed: " + message);
		connectionstatus.text="Room Creation Failed...";
		MenuManager.Instance.OpenMenu("errormenu");
	}
	public override void OnLeftRoom()
	{
		connectionstatus.text="Left Room Successfully...";
		MenuManager.Instance.OpenMenu("titlemenu");
	}
	public override void OnLeftLobby()
	{
		connectionstatus.text="Left Lobby Successfully...";
		MenuManager.Instance.OpenMenu("mainmenu");
	}
	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
		MenuManager.Instance.OpenMenu("loadingmenu");
	}
	public override void OnMasterClientSwitched(Player newMasterClient)
	{
		startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}
	public void StartGame()
	{
		PhotonNetwork.LoadLevel(1);
	}
	public void backlobby()
	{
		StartCoroutine(leavelobby());
	}
	public void JoinRoom(RoomInfo info)
	{
		PhotonNetwork.JoinRoom(info.Name);
		MenuManager.Instance.OpenMenu("loadingmenu");
	}
	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		foreach(Transform trans in roomListContent)
		{
			Destroy(trans.gameObject);
		}

		for(int i = 0; i < roomList.Count; i++)
		{
			if(roomList[i].RemovedFromList)
				continue;
			Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
			
		}
	}
	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		connectionstatus.text=newPlayer.NickName+" Entered the room...";
		Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
	}
	IEnumerator leavelobby()
	{
		MenuManager.Instance.OpenMenu("loadingmenu");
		PhotonNetwork.LeaveLobby();
		while(PhotonNetwork.InLobby)
		    yield return null;
		MenuManager.Instance.OpenMenu("mainmenu");
	}
	public void quitgame()
	{
		Debug.Log("Quitting Game...");
		Application.Quit();
	}
}
