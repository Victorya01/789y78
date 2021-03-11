using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace _12
{
    public class Program
    {
        public struct PointStruct
        {
            public int X;
            public int Y;
        }
       
        static void Main(string[] args)
        {

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);


        }
        [MemoryDiagnoser]
        public class BenchmarkClass
        {

            public float PointDistance(PointStruct pointOne, PointStruct pointTwo)
            {
                float x = pointOne.X - pointTwo.X;
                float y = pointOne.Y - pointTwo.Y;
                return MathF.Sqrt((x * x) + (y * y));
            }
            [Benchmark]
            public void GetPointDistance()
            {
                PointStruct startPoint = new PointStruct { X = 10, Y = 10 };
                PointStruct endPoint = new PointStruct { X = 123, Y = 123 };
                PointDistance(startPoint, endPoint);
            }
            public float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
            {
                float x = pointOne.X - pointTwo.X;
                float y = pointOne.Y - pointTwo.Y;
                return (x * x) + (y * y);
            }
            [Benchmark]
            public void GetPointDistanceShort()
            {
                PointStruct startPoint = new PointStruct { X = 10, Y = 10 };
                PointStruct endPoint = new PointStruct { X = 123, Y = 123 };
                PointDistanceShort(startPoint, endPoint);
            }
            public double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
            {

                double x = pointOne.X - pointTwo.X;
                double y = pointOne.Y - pointTwo.Y;
                return Math.Sqrt((x * x) + (y * y));
            }
            [Benchmark]
            public void GetPointDistanceDouble()
            {
                PointStruct startPoint = new PointStruct { X = 10, Y = 10 };
                PointStruct endPoint = new PointStruct { X = 123, Y = 123 };
                PointDistanceDouble(startPoint, endPoint);
            }

        }
    }
}
