namespace PostgresSample.SqlServer;

public class InstrumentUpdaterLog
{
	public long Id { get; set; }
	//public MessageTypeEnum MessageTypeEnum { get; set; }
	public string ConsumerName { get; set; } = default!;
	public string KafkaMessage { get; set; } = default!;
	public DateTime DateTime { get; set; }
	public string ExceptionMessage { get; set; } = default!;
	public string StackTrace { get; set; } = default!;
}
