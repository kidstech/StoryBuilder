﻿using System;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;
using Random = UnityEngine.Random;

using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


[System.Serializable]
public class Main : MonoBehaviour
{
    private static float BUTTON_WIDTH = 85;
    private static float BUTTON_HEIGHT = 30;
    private MongoClient client;
    private MongoServer server;
    private MongoDatabase db;
    private MongoCollection<BsonDocument> allWords;
    private MongoCollection<BsonDocument> allContextPacks;
    private MongoCollection<BsonDocument> allWordPacks;
    public List<String> words = new List<String>();

    protected void Start()
    {
        client = new MongoClient(new MongoUrl("mongodb://Unity:Unity@ds049624.mlab.com:49624/wordriver"));
        server = client.GetServer();
        server.Connect();
        db = server.GetDatabase("wordriver");
        allContextPacks = db.GetCollection<BsonDocument>("contextpacks");
        allWords = db.GetCollection<BsonDocument>("words");
        allWordPacks = db.GetCollection<BsonDocument>("wordpacks");
        
        foreach (BsonDocument item in allWords.FindAll())
        {
            BsonElement name = item.GetElement("name");
            string wordValue = name.Value.ToString();
            words.Add(wordValue);
        }
        Readable.Speak("Let's Build a Sentence!");
    }

    void OnGUI()
    {
        words.Sort();
        int horizontalOffset = 0;
        int verticalOffset = 0;

        for (var i = 0; i < words.Count; i++)
        {
            if (Screen.width <= (horizontalOffset * 70) + 220)
            {
                verticalOffset++;
                horizontalOffset = 0;
            }

            string word = words[i];
            if (GUI.Button(new Rect(10 + (horizontalOffset * Main.BUTTON_WIDTH), Screen.height / 3 + (verticalOffset * Main.BUTTON_HEIGHT), 85, 30), word))
            {
                Tile tile = Tile.Create(word);

                //this line makes the tile show up
                tile.transform.parent = gameObject.transform;
                
                tile.GetComponent<RectTransform>().localPosition = new Vector3(366, 274, 0);

            }
            horizontalOffset++;
        }
    }


}




          

        