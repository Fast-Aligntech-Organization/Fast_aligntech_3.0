using System.Collections.Generic;
using System.Threading.Tasks;
using Fast.Core.InternalModels;


namespace Fast.Core;
public interface ILuisTrainService
{
    Task<IList<ReviewLabel>> GetReviewLabelsAsync(uint skip = 0, uint take = 100);
    Task<bool> AddLabelAsync(Label label);
    Task<IList<LabelResult>> AddBatchLabelsAsync(IList<Label> labels);
    Task<bool> DeleteLabelAsync(string exampleId);
    Task<bool> TrainModelAsync(string mode = "Standart");
    Task<IList<TrainingVersionResult>> GetTrainingStatus();
    Task<IList<EntityInfo>> GetVersionEntityListAsync(uint skip = 0, uint take = 100);
    Task<string> CreateEntityAsync(EntityDefinition entityDefinition);
    Task<bool> DeleteEntityAsync(string entityId);



}
