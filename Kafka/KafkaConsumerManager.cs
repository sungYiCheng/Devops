using System;
using System.Collections.Generic;
using Confluent.Kafka;

namespace Kafka
{
	// 這移除了許多 不方便外露的Code，是無法直接複製貼上執行的
	internal class KafkaConsumerManager : IDisposable
	{
		private readonly string IPPort = "127.0.0.1:9091";
		private string topic = "bbtest";

		private ConsumerConfig config;

		public KafkaConsumerManager()
		{
			config = new ConsumerConfig()
			{
				BootstrapServers = "127.0.0.1:9091",
				GroupId = "foo",
				AutoOffsetReset = AutoOffsetReset.Earliest,
			};
		}

		public void Dispose()
		{
		}

		protected override void OnStart()
		{
			ConsoleCommandHelper.AddObject(this);

			SetConsumer();
		}

		private void SetConsumer()
		{
			ConsoleCommandHelper.AddCommand("kafkaConsumer", (args) =>
			{
				if (args.Length == 1)
				{
					config.GroupId = args[0];
				}

				if (args.Length == 2)
				{
					topic = args[1];
				}

				using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
				{
					consumerBuilder.Subscribe(topic);

					try
					{
						// 這裡沒設定離開條件
						while (true)
						{
							var consumer = consumerBuilder.Consume();
							ShareLogger.Instance.FuncWarn($"Topic: {consumer.Topic} Partition: {consumer.Partition} Offset: {consumer.Offset}, msg: {consumer.Value}");
						}

						consumerBuilder.Close();
						ShareLogger.Instance.FuncWarn($"Consumer Close");
					}
					catch (Exception ex)
					{
						consumerBuilder.Close();
						ShareLogger.Instance.FuncWarn($"Consumer Close, ex:{ex.Message}");
					}
				}
			});
		}
	}
}
