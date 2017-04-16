﻿using UnityEngine;
using System.Collections.Generic;
using Tacticsoft;
using Tacticsoft.Examples;
using System.IO;
using DetailTableCellNS;
using UnityEngine.UI;

namespace FileTableViewControllerNS
{
    //An example implementation of a class that communicates with a TableView
    public class FileTableViewController : MonoBehaviour, ITableViewDataSource
    {
		public GameObject jeep;
        public DetailTableCell m_cellPrefab;
        public TableView m_tableView;
		public GameObject btnPlay;

		public FileInfo[] fileinfo;

		public AudioSource audioSource;


        int m_numRows;
        private int m_numInstancesCreated = 0;

		private string musicPath;

		private float scrollingVelocity = 0;
		private float playGazeActivationThreshold = 1.0f;//2 seconds
		private float playGazeActivationTime = 0.0f;
		private bool playIsGazing = false;

		private int selectedCellIndex = 0;

        private Dictionary<int, float> m_customRowHeights;

        //Register as the TableView's delegate (required) and data source (optional)
        //to receive the calls
        void Start() {
            m_customRowHeights = new Dictionary<int, float>();
            m_tableView.dataSource = this;

			musicPath = Directory.GetCurrentDirectory ();
			if (Application.platform == RuntimePlatform.Android)
				musicPath += "sdcard/media";
			else if (Application.platform == RuntimePlatform.OSXEditor)
				musicPath += "";

			DirectoryInfo dir = new DirectoryInfo(musicPath);
			fileinfo = dir.GetFiles("*.mp3");

			m_numRows = fileinfo.Length;

			audioSource = audioSource.GetComponent<AudioSource> ();
        }

		void Awake(){
		}

		void Update(){
			m_tableView.scrollY -= Time.deltaTime * scrollingVelocity;

			if (playIsGazing) {
				playGazeActivationTime += Time.deltaTime;
				float r = 1.0f - (playGazeActivationTime/playGazeActivationThreshold);
				float g = r;
				float b = r;
				btnPlay.GetComponent<Image>().color = new Color(r, 1.0f, b, 1.0f);
				if(playGazeActivationTime > playGazeActivationThreshold){
					play ();//run the activation method for the play button
					playGazeActivationTime = 0.0f;
				}
			}
			else{
				playGazeActivationTime = 0.0f;
			}

			//DetailTableCell temp = m_tableView.GetCellAtRow (0) as DetailTableCell;
			//temp.GetComponent<Image> ().color = new Color(0.5f, 0.5f, 1.0f, 0.75f);
			//Debug.Log (m_tableView.visibleRowRange.from );
			
			selectedCellIndex = (int)( m_numRows * (m_tableView.scrollY / m_tableView.scrollableHeight));
			selectedCellIndex = Mathf.Clamp (selectedCellIndex, 0, m_numRows-1);

			for (int i=0;i<m_numRows;i++){
				DetailTableCell temp = m_tableView.GetCellAtRow(i) as DetailTableCell;
				if (temp != null){
					temp.GetComponent<Image>().color = Color.white;
					if (temp.rowNumber == selectedCellIndex)
						temp.GetComponent<Image>().color = new Color(0.5f, 0.5f, 1.0f, 0.5f);
				}
			}
		}

        #region ITableViewDataSource

        //Will be called by the TableView to know how many rows are in this table
        public int GetNumberOfRowsForTableView(TableView tableView) {
            return m_numRows;
        }

        //Will be called by the TableView to know what is the height of each row
        public float GetHeightForRowInTableView(TableView tableView, int row) {
            return GetHeightOfRow(row);
        }

        //Will be called by the TableView when a cell needs to be created for display
        public TableViewCell GetCellForRowInTableView(TableView tableView, int row) {
            DetailTableCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as DetailTableCell;
            if (cell == null) {
                cell = (DetailTableCell)GameObject.Instantiate(m_cellPrefab);
                cell.name = "DynamicHeightCellInstance_" + (++m_numInstancesCreated).ToString();
                cell.onCellHeightChanged.AddListener(OnCellHeightChanged);
            }
            cell.rowNumber = row;
            cell.height = GetHeightOfRow(row);
			cell.m_rowNumberText.text = fileinfo [row].Name;
            return cell;
        }

        #endregion

        private float GetHeightOfRow(int row) {
			return 30.0f;
        }

        private void OnCellHeightChanged(int row, float newHeight) {
            if (GetHeightOfRow(row) == newHeight) {
                return;
            }
            //Debug.Log(string.Format("Cell {0} height changed to {1}", row, newHeight));
            m_customRowHeights[row] = newHeight;
            m_tableView.NotifyCellDimensionsChanged(row);
        }

		public void scrollUp(){
			//Debug.Log ("Scroll up");
			scrollingVelocity = 100.0f;
		}

		public void scrollDown(){
			//Debug.Log ("Scroll down");
			scrollingVelocity = -100.0f;
		}

		public void scrollStop(){
			//Debug.Log ("Scroll Stop");
			scrollingVelocity = 0.0f;
		}

		public void playStartGazing(){
			playIsGazing = true;
		}

		public void playStopGazing(){
			playIsGazing = false;
			btnPlay.GetComponent<Image>().color = new Color(1.0f,1.0f, 1.0f, 1.0f);
		}

		public void play(){
			//the actual play button activation method
			string fullpath = "file://" + fileinfo [selectedCellIndex].FullName;
			Debug.Log ("Play, " + fullpath);
			WWW clip = new WWW (fullpath);
			Debug.Log (clip.bytes);
			audioSource.clip = clip.GetAudioClip (false, true);
			audioSource.Play ();
			//Animation Anime = jeep.GetComponent<Animation> ();
			//Anime.Play ("Take 001");
			//Debug.Log (Anime.Play ());
		}

    }
}
