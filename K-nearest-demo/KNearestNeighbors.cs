

namespace K_nearest_demo
{
     public class KNearestNeighbors
    {
        private int k;
        private List<Mobile> instances;

        public KNearestNeighbors(int k)
        {
            this.k = k;
            instances = new List<Mobile>();
        }

        public void Train(List<Mobile> trainingData)
        {
            instances = trainingData;
        }

        public string Predict(double[] features)
        {
            // Find the k nearest neighbors
            List<MobileDistance> distances = new List<MobileDistance>();
            foreach (Mobile instance in instances)
            {
                double distance = EuclideanDistance(features, instance.Configuration);
                distances.Add(new MobileDistance(instance, distance));
            }
            List<MobileDistance> sortedDistances = distances.OrderBy(d => d.Distance).Take(k).ToList();

            // Count the number of neighbors in each class
            Dictionary<string, int> classCounts = new Dictionary<string, int>();
            foreach (MobileDistance distance in sortedDistances)
            {
                string label = distance.Instance.Brand;
                if (classCounts.ContainsKey(label))
                {
                    classCounts[label]++;
                }
                else
                {
                    classCounts[label] = 1;
                }
            }

            // Find the class with the most neighbors
            string predictedClass = "";
            int maxCount = -1;
            foreach (string label in classCounts.Keys)
            {
                int count = classCounts[label];
                if (count > maxCount)
                {
                    predictedClass = label;
                    maxCount = count;
                }
            }

            return predictedClass;
        }

        private double EuclideanDistance(double[] a, double[] b)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += Math.Pow(a[i] - b[i], 2);
            }
            return Math.Sqrt(sum);
        }
    }
}
