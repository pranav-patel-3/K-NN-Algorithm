// See https://aka.ms/new-console-template for more information
using K_nearest_demo;

Console.WriteLine("Hello, let's begin, shree ganeshay namah :)..");
 


//static void Main(string[] args)
//{  RAM , Storage , Camera pixle , price
    List<Mobile> mobileMasterData = new List<Mobile> {
                new Mobile { Configuration = new double[] { 2, 20, 2, 20000 }, Brand = "Nokia" },
                new Mobile { Configuration = new double[] { 4, 40, 4, 40000 }, Brand = "Redmi" },
                new Mobile { Configuration = new double[] { 6, 60, 6, 60000 }, Brand = "Samsung" },
                new Mobile { Configuration = new double[] { 8, 80, 8,  80000}, Brand = "Apple" }
            };

    KNearestNeighbors knn = new KNearestNeighbors(k: 3);
    knn.Train(mobileMasterData);

    double[] queryFeatures = new double[] { 7, 70, 7, 70001 };
    string predictedClass = knn.Predict(queryFeatures);

    Console.WriteLine($"Predicted brand: {predictedClass}");
    Console.ReadLine();
//}