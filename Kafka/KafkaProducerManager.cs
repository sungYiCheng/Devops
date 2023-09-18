using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace Kafka
{
	// 這移除了許多 不方便釋出的Code，只留下簡單的kafka相關內容，是無法直接複製貼上執行的
	internal partial class KafkaProducerManager : IDisposable
	{
		private readonly string IPPort = "127.0.0.1:9091";
		private ProducerConfig config;
		private AdminClientConfig adminConfig;

		public KafkaProducerManager()
		{
			config = new ProducerConfig { BootstrapServers = IPPort };
			adminConfig = new AdminClientConfig { BootstrapServers = IPPort };
		}

		public void Dispose()
		{
		}

		protected override void OnStart()
		{
			ConsoleCommandHelper.AddObject(this);

			SetProducer();
			SetOtherCommand();
		}

		private void SetProducer()
		{
			ConsoleCommandHelper.AddCommand("kafkaSend", async (args) =>
			{
				string topic = "bbtest";
				if (args.Length == 1)
				{
					topic = args[0];
				}

				using (var producer = new ProducerBuilder<Null, string>(config).Build())
				{
					try
					{
						Console.WriteLine($"{producer.Name} producing on {topic}");

						// 測試內容
						string text = "TTTTTTTTTTTTTest";

						// 非同步發送訊息至 broker
						var topicPart = new TopicPartition(topic, new Partition(0));   // 用來指定送至哪一個 Partition
						var deliveryReport = await producer.ProduceAsync(topicPart, new Message<Null, string>() { Value = text });

						// 可以直接傳送 topic，這會由系統決定要往哪個 Partition送，測試過程發現可能是最後一個(創了兩個0和1，但都只往1送)，可能跟設定有關，或需要再研究
						// var deliveryReport = await producer.ProduceAsync(topic, new Message<Null, string>() { Value = text });

						Console.WriteLine($"OK, {deliveryReport.Message}");
						//Console.WriteLine($"Partition: {task.Result.Partition}, Offset: {task.Result.Offset}, Message: {task.Result.Value}");

						//將 producer request 保留至 disk，確保資料不會遺失
						producer.Flush();
					}
					catch
					{
						producer.Dispose();
					}
				}
			});
		}

		private void SetOtherCommand()
		{
			ConsoleCommandHelper.AddCommand("kafkaDeleteTopic", (args) =>
			{
				if (args.Length == 0)
				{
					Console.WriteLine("args error");
					return;
				}

				using (var adminClient = new AdminClientBuilder(adminConfig).Build())
				{
					adminClient.DeleteTopicsAsync(args, null);
				}
			});

			// 可以先定義好 topic 的規則，包括多少個 Partition 等等
			ConsoleCommandHelper.AddCommand("kafkaAddTopicPartition", async (args) =>
			{
				if (args.Length != 1)
				{
					Console.WriteLine("args error");
					return;
				}

				using (var adminClient = new AdminClientBuilder(adminConfig).Build())
				{
					try
					{
						// ReplicationFactor 似乎是 broker id，測試時只安裝一台，填2以上會炸
						// 必須要用 await，不然CreateTopicsAsync還沒完成時，就會釋放adminClient，導致設定無效，且不會有錯誤，這點踩了雷要注意
						await adminClient.CreateTopicsAsync(new TopicSpecification[] {new TopicSpecification { Name = args[0], ReplicationFactor = 1, NumPartitions = 2 } });
					}
					catch (CreateTopicsException e)
					{
						Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
					}
				}
			});
		}
	}
}
