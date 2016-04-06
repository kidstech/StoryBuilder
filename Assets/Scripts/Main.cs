using System;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;
using Random = UnityEngine.Random;

using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    private MongoClient client;
    private MongoServer server;
    private MongoDatabase db;
    private MongoCollection<Word> allWords;
    private MongoCollection<ContextPack> allContextPacks;
    private MongoCollection<WordPack> allWordPacks;

    protected void Start()
    {
        client = new MongoClient(new MongoUrl("mongodb://Unity:Unity@ds049624.mlab.com:49624/wordriver"));
        server = client.GetServer();
        server.Connect();
        db = server.GetDatabase("wordriver");
        allContextPacks = db.GetCollection<ContextPack>("contextpacks");
        allWords = db.GetCollection<Word>("words");
        allWordPacks = db.GetCollection<WordPack>("wordpacks");

        //string usable = allWords.FindAll().ToJson();
        //UnityEngine.Debug.Log(usable);
        Readable.Speak("Welcome to Story Builder!");
    }

    //void OnGUI()
    //{
    //    GUIStyle style = new GUIStyle();
    //    style.fontSize = 20;

    //    //foreach (Word tile in allWords)
    //    //{

    //    //}
    //    //{

    //    IMongoQuery query = "";
    //    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 60), allWords.FindOne(query).name.ToString(), style);
    //    //}
    //}

        //    int horizontalOffset = 0;
        //    int verticalOffset = 0;
        //    foreach (string user in Users)
        //    {
        //        if(Screen.width <= (horizontalOffset * 210) + 280)
        //        {
        //            verticalOffset++;
        //            horizontalOffset = 0;
        //        }
        //        if (GUI.Button(new Rect(70 + (horizontalOffset * 210), Screen.height / 2 + (verticalOffset * 70), 200, 60), user))
        //        {
        //            currentUser = user;
        //            Application.LoadLevel("main");
        //        }
        //        horizontalOffset++;
        //    }
        //}

    }