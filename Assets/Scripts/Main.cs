using System;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;
using Random = UnityEngine.Random;

using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Collections;

public class Main : MonoBehaviour
{
    private MongoClient client;
    private MongoServer server;
    private MongoDatabase db;
    private MongoCollection<BsonDocument> allWords;
    private MongoCollection<BsonDocument> allContextPacks;
    private MongoCollection<BsonDocument> allWordPacks;
    public ArrayList alltiles = new ArrayList(500);

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
            alltiles.Add(wordValue);
        }
        Readable.Speak("Welcome to Story Builder!");
    }

    void OnGUI()
    {
        int horizontalOffset = 0;
        int verticalOffset = 0;

        for (var i = 0; i < alltiles.Count; i++)
        {
            if (Screen.width <= (horizontalOffset * 90) + 140)
            {
                verticalOffset++;
                horizontalOffset = 0;
            }
            GUI.Box(new Rect(70 + (horizontalOffset * 90), Screen.height / 3 + (verticalOffset * 40), 85, 30), alltiles[i].ToString());
            horizontalOffset++;
        }
    }
}




          

        