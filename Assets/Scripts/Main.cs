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
                //As far as I can tell, this doens't yet make a tile. I'm not sure how to make it show up.
                Tile tile = Tile.Create(word);
                tile.GetComponent<RectTransform>().position = new Vector3(500, 500, 0);
                //the next line of code makes the word of the button show up in the console
               
                print(word);
            }
            horizontalOffset++;
        }
    }


}




          

        