namespace MongoPeopleAPI.CustomModelBinders
{
    using System.Web.Mvc;
    using MongoDB.Bson;

    public class BsonObjectIdBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext modelBindingContext)
        {
            var valueProviderResult = modelBindingContext.ValueProvider.GetValue(modelBindingContext.ModelName);
            return new ObjectId(valueProviderResult.AttemptedValue);
        }
    }
}