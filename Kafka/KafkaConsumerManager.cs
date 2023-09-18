using System;
using System.Collections.Generic;
using Confluent.Kafka;

namespace Kafka
{
	// �o�����F�\�h ����K�~�S��Code�A�O�L�k�����ƻs�K�W���檺
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
						// �o�̨S�]�w���}����
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
