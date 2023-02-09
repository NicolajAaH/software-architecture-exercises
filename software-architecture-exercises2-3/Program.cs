using System;
using Confluent.Kafka;

namespace DotnetKafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            // the bootstrap server is the address of the kafka broker, i.e. the docker container. Here you can specify multiple brokers 
            // separated by a comma to enable load balancing and fault tolerance.
            var config = new ProducerConfig { BootstrapServers = "kafka1:9092" };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                Console.WriteLine("A kafka message");
                
                foreach (string line in System.IO.File.ReadLines("./alice-in-wonderland.txt"))
                {  
                    var result = producer.ProduceAsync("TEST_TOPIC", new Message<Null, string> { Value = line }).Result;
                    Console.WriteLine($"Message '{line}' sent to partition {result.Partition} with offset {result.Offset}");
                }  
                
            }
        }
    }
}