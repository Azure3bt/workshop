using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PostgresSample.SqlServer;


public class Instrument
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string InstrumentId { get; set; }
	public string Code { get; set; }
	public string Name { get; set; }
	public string Text { get; set; }
	public string Isin { get; set; }
	public string? TSETMCID { get; set; }
	public long BoardCode { get; set; }
	public string BoardName { get; set; }
	public string SectorCode { get; set; }
	public string SectorName { get; set; }
	public string SubSectorCode { get; set; }
	public string SubSectorName { get; set; }
	public long? AskMaxQuantity { get; set; }
	public long? BidMaxQuantity { get; set; }
	public long? MaxQuantity { get; set; }
	public long? MinQuantity { get; set; }
	public long? Tick { get; set; }
	public long? Lot { get; set; }
	public int Segment { get; set; }
	public long? BaseVolume { get; set; }
	public long? ParValue { get; set; }
	[NotMapped]
	public string? ProductCode => $"{ProductTypeCode1}{ProductTypeCode2}";
	public string? ProductTypeCode1 { get; set; }
	public string? ProductTypeCode2 { get; set; }
	public string? ProductName { get; set; }
	public int? Bourse { get; set; }
	public string GroupCode { get; set; }
	public string GroupName { get; set; }
	public int GroupState { get; set; }
	public bool IsActive { get; set; }
	public int? SettlementType { get; set; }
	public int State { get; set; }
	public long PriceMin { get; set; }
	public long PriceMax { get; set; }
	public decimal AskFeeRate { get; set; }
	public decimal BidFeeRate { get; set; }
	public int Class { get; set; }
	public int ClassChanel { get; set; }
	public int? HiddenPriceType { get; set; }
	public long? HiddenPrice { get; set; }
	public DateTime? HiddenPriceFrom { get; set; }
	public DateTime? HiddenPriceTo { get; set; }
	public bool IsBidPermitted { get; set; }
	public bool IsAskPermitted { get; set; }
	public bool IsSearchPermitted { get; set; }
	public string? PutOptionParentInstrumentId { get; set; }
	public string? PutOptionParentInstrumentName { get; set; }
	public string? PutOptionParentInstrumentText { get; set; }
	public DateTime? PutOptionPerformDate { get; set; }
	public string? NewInstrumentId { get; set; }
	public string? NewInstrumentName { get; set; }
	public string? NewInstrumentText { get; set; }
}
