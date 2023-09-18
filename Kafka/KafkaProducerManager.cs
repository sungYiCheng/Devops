using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace Kafka
{
	// �o�����F�\�h ����K���X��Code�A�u�d�U²�檺kafka�������e�A�O�L�k�����ƻs�K�W���檺
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

						// ���դ��e
						string text = "TTTTTTTTTTTTTest";

						// �D�P�B�o�e�T���� broker
						var topicPart = new TopicPartition(topic, new Partition(0));   // �Ψӫ��w�e�ܭ��@�� Partition
						var deliveryReport = await producer.ProduceAsync(topicPart, new Message<Null, string>() { Value = text });

						// �i�H�����ǰe topic�A�o�|�Ѩt�ΨM�w�n������ Partition�e�A���չL�{�o�{�i��O�̫�@��(�ФF���0�M1�A�����u��1�e)�A�i���]�w�����A�λݭn�A��s
						// var deliveryReport = await producer.ProduceAsync(topic, new Message<Null, string>() { Value = text });

						Console.WriteLine($"OK, {deliveryReport.Message}");
						//Console.WriteLine($"Partition: {task.Result.Partition}, Offset: {task.Result.Offset}, Message: {task.Result.Value}");

						//�N producer request �O�d�� disk�A�T�O��Ƥ��|��
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

			// �i�H���w�q�n topic ���W�h�A�]�A�h�֭� Partition ����
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
						// ReplicationFactor ���G�O broker id�A���ծɥu�w�ˤ@�x�A��2�H�W�|��
						// �����n�� await�A���MCreateTopicsAsync�٨S�����ɡA�N�|����adminClient�A�ɭP�]�w�L�ġA�B���|�����~�A�o�I��F�p�n�`�N
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
