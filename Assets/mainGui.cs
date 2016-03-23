using System;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mongo : MonoBehaviour
{
    public class Order
    {
        public enum STATE : byte
        {
            NEW = 0,
            CANCELLED = 1,
            COMPLETE = 2
        }
        public ObjectId Id { get; set; }
        public string account { get; set; }
        public string sku { get; set; }
        public STATE state { get; set; }
        public DateTime created { get; set; }
        public string token { get; set; }
    }
    private MongoClient client;
    private MongoServer server;
    private MongoDatabase db;
    private MongoCollection<Order> words;

    private int counter = 0;
    private bool work = true;
    protected void Start()
    {
        client = new MongoClient(new MongoUrl("mongodb://bensimondet:Camp.46.mo@ds049624.mlab.com:49624/wordriver"));
        server = client.GetServer();
        server.Connect();
        db = server.GetDatabase("wordriver");
        words = db.GetCollection<Order>("words");

        for (var i = 0; i < 100; i++)
        {
            InsertRandomDocument();
        }
    }

    protected void OnGUI()
    {
        GUI.Label(new Rect(40, 40, 200, 20), "Inserts: " + counter);
        if (GUI.Button(new Rect(40, 70, 200, 20), "Stop"))
            work = false;
    }
    private void InsertRandomDocument()
    {
        Debug.Log("Tried inserting document");
        //var order = new Order
        //{
        //    account = Utils.RandomString(6),
        //    sku = Utils.RandomString(6),
        //    state = (Order.STATE)Random.Range(0, 3),
        //    created = DateTime.Now,
        //    token = Utils.RandomString(50)
        //};

        //UnityThreadHelper.TaskDistributor.Dispatch(() =>
        //{
        //    orders.Insert(order);
        //    System.Threading.Thread.Sleep(10);
        //    if (System.Threading.Interlocked.Increment(ref counter) < 100000 && work)
        //        UnityThreadHelper.Dispatcher.Dispatch(InsertRandomDocument);
        //});
    }
}