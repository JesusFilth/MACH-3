public interface IRecordStorage
{
    RecordModel[] GetRecords();
    void AddNewRecord(RecordModel record);
}
