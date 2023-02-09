using System;
using Confluent.Kafka;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // the bootstrap server is the address of the kafka broker, i.e. the docker container. Here you can specify multiple brokers 
            // separated by a comma to enable load balancing and fault tolerance.
            // The group id is used to identify the consumer group. All consumers with the same group id belong to the same consumer group.
            // The auto offset reset defines the behavior of the consumer if no offset is stored for a partition. Here we set it to earliest
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka1:9092",
                GroupId = "group1",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("TEST_TOPIC");

                Console.WriteLine("Kafka Consumer is running...");
                using var file = new System.IO.StreamWriter("./the-rabbit-hole.txt");
                
                while (true)
                {
                    try
                    {
                        var message = consumer.Consume();

                        Console.WriteLine($"Message received: '{message.Value}' from partition {message.Partition} with offset {message.Offset}");
                        file.WriteLine(message.Value);
                        file.Flush();
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Consumption failed: {e.Error.Reason}");
                    }
                }
            }
        }
    }
}