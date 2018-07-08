using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mono.Data.Sqlite;
namespace Tetris{

	public class PlayerInfo :IComparable<PlayerInfo>
	{
		public PlayerInfo(string name,string pwd,int score){this.name=name;this.pwd=pwd;this.score=score;}
		public string name;
		public string pwd;
		public int score;
		public int CompareTo(PlayerInfo obj)
		 {
			 if(score>obj.score)return -1;
			 else if(score==obj.score)return 0;

			 return 1;
		 }
	}
public class DataBaseManager : MonoBehaviour {

	DbAccess db;
	public void Init()
	{
			ConnectToDatabase();
	}
	public void UnInit()
	{
		DisConnect();
	}

	

	void ConnectToDatabase()
	{
		
		
		
		Debug.Log(" Success to connect!!!!!");
	}

	void DisConnect()
	{
		Debug.Log(" Success to DisConnect!!!!!");
	}
	
	public List<PlayerInfo> GetAllMsg()
	{
		DbAccess db = new DbAccess(DbAccess.DbName);
		List<PlayerInfo> info=new List<PlayerInfo>();

		SqliteDataReader sqReader = db.SelectWhere(tableName,new string[]{"name","pwd","score"},new string[]{"score"},new string[]{">"},new string[]{(-1).ToString()});
		if (!sqReader.HasRows){db.CloseSqlConnection();return info;}
	
		while (sqReader.Read())
    	{

     	 	 string name=sqReader.GetString(sqReader.GetOrdinal("name"));
			 string pwd=sqReader.GetString(sqReader.GetOrdinal("pwd"));
			 int score=(int)(sqReader.GetValue(sqReader.GetOrdinal("score")));
			// int score=int.Parse( sqReader.GetString(sqReader.GetOrdinal("score")));
			 info.Add(new PlayerInfo(name,pwd,score));
    	} 
		


		info.Sort();
		db.CloseSqlConnection();
		return info;
	}
	private string tableName{get{return DbAccess.TableName;}}
	public void Insert(string username,string password)
	{
		DbAccess db = new DbAccess(DbAccess.DbName);
		db.InsertInto(tableName,new string[]{"'"+username+"'","'"+password+"'",0.ToString()});
		db.CloseSqlConnection();
	}

	public void UpdateMessage(string name ,int score)
	{
		DbAccess db = new DbAccess(DbAccess.DbName);
		db.UpdateInto(tableName,new string[]{"score"},new string[]{score.ToString()}, "name", "'"+name+"'" );
		db.CloseSqlConnection();
	}

	public bool FindUser(string name)
	{
		DbAccess db = new DbAccess(DbAccess.DbName);
		SqliteDataReader sqReader = db.SelectWhere(tableName,new string[]{"name"},new string[]{"name"},new string[]{"="},new string[]{name});
		
		
		if (sqReader.HasRows){db.CloseSqlConnection(); return true;}
		else {db.CloseSqlConnection();return false;}
		//while (sqReader.Read())
    	//{
     	// 	Debug.Log(sqReader.GetString(sqReader.GetOrdinal("name")) + sqReader.GetString(sqReader.GetOrdinal("email")));
    	//} 
		//return false;
	}
	public int FindScore(string name)
	{
			DbAccess db = new DbAccess(DbAccess.DbName);
		SqliteDataReader sqReader = db.SelectWhere(tableName,new string[]{"score"},new string[]{"name"},new string[]{"="},new string[]{name});
		
		if (!sqReader.HasRows){db.CloseSqlConnection();return 0;}
		int score=0;

		while (sqReader.Read())
    	{
     	 	  score=(int)(sqReader.GetValue(sqReader.GetOrdinal("score")));
    	} 
		db.CloseSqlConnection();
		return score;
	}

	public string FindPassword(string name)
	{
			DbAccess db = new DbAccess(DbAccess.DbName);
		SqliteDataReader sqReader = db.SelectWhere(tableName,new string[]{"pwd"},new string[]{"name"},new string[]{"="},new string[]{name});
		
		if (!sqReader.HasRows){db.CloseSqlConnection();return "";}
		string pwd="";
		while (sqReader.Read())
    	{
     	 	 pwd=sqReader.GetString(sqReader.GetOrdinal("pwd"));
    	} 
		db.CloseSqlConnection();
		return pwd;
	}

}
}