using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Mobioos.Generators.AspNetCore.Tests
{
    public class DataGeneratorTests : BaseGeneratorTests, IDisposable
    {
        string _entityId = "MyEntity";
        string _layoutId = "MyLayout";
        string _apiId = "MyApi";
        string _featureId = "MyFeature";
        string _dataModelId = "MyDataModel";
        string _dataNamespace = "DataModels";
        string _version = "v1";

        [Fact]
        public void ApiConcernController_Template_Test()
        {
            var template = new ApiConcernController(new LayoutInfo() { Id = _layoutId, IsRestricted = true, Concern = new ConcernInfo() { Id = _featureId, IsRestricted = true }, DataModel = new EntityInfo() { Id = _dataModelId }, Actions = new ActionList() }, ApplicationId, Constants.Version, new Dictionary<string, string>() { { "Test", "Test"}, {"Test2","Test2" } });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Api.{_featureId}", output);
        }

        [Fact]
        public void ApiConcernController_Template_NullParameter_Test()
        {
            var template = new ApiConcernController(null, null, null, null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ApiController_Template_Test()
        {
            var template = new ApiController(new ApiInfo() { Id = _apiId, Actions = new ApiActionList { new ApiActionInfo { Id = "GetTest", ReturnType = new EntityInfo { Id = "Test" }, Type = "Get", Url = "api/GetTest", Parameters = new List<ApiParameterInfo> { new ApiParameterInfo { Id = "name", Type = "string" } } } } }, ApplicationId, Constants.Version, new Dictionary<string, string>());
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Api.{_apiId}", output);
        }

        [Fact]
        public void ApiController_Template_NullParameter_Test()
        {
            var template = new ApiController(null, null, null, null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ViewModel_Template_Test()
        {
            var template = new ViewModelTemplate(new EntityInfo() { Id = _entityId }, ApplicationId, Constants.ViewModelNamespace, new Dictionary<string, string> { { "Test", "Test" } });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.{Constants.ViewModelNamespace}", output);
        }

        [Fact]
        public void ViewModel_Template_NullParameter_Test()
        {
            var template = new ViewModelTemplate(null, null, null, null);
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        [Fact]
        public void DataModel_Template_Test()
        {
            var template = new DataModelTemplate(new EntityInfo() { Id = _entityId }, ApplicationId, Constants.DataNamespace);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.{_dataNamespace}", output);
        }

        [Fact]
        public void DataModel_Template_NullParameter_Test()
        {
            var template = new DataModelTemplate(null, null, null);
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        [Fact]
        public void DbContext_Template_Test()
        {
            var template = new DbContext(new SmartAppInfo() { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Models", output);
        }

        [Fact]
        public void DbContext_Template_NullParameter_Test()
        {
            var template = new DbContext(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void EntityApiController_Template_Test()
        {
            var context = GetContext().DynamicContext.Manifest;
            var entity = context.DataModel.Entities[1];
            var template = new EntityApiController(entity, context.Id, Constants.Version);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Api.{_version}", output);
        }

        [Fact]
        public void EntityApiController_Template_NullParameter_Test()
        {
            var template = new EntityApiController(null, null, null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void EntityMvcController_Template_Test()
        {
            var template = new EntityMvcController(new EntityInfo() { Id = _entityId }, ApplicationId);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Controllers", output);
        }

        [Fact]
        public void EntityMvcController_Template_NullParameter_Test()
        {
            var template = new EntityMvcController(null, null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ServiceContext_Template_Test()
        {
            var template = new ServiceContext(new SmartAppInfo() { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Models", output);
        }

        [Fact]
        public void ServiceContext_Template_NullParameter_Test()
        {
            var template = new ServiceContext(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void CreateView_Template_Test()
        {
            var template = new CreateTemplate(new EntityInfo() { Id = _entityId }, ApplicationId);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.DataModels.{_entityId}", output);
        }

        [Fact]
        public void CreateView_Template_NullParameter_Test()
        {
            var template = new CreateTemplate(null, null);
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        [Fact]
        public void DeleteView_Template_Test()
        {
            var template = new DeleteTemplate(new EntityInfo() { Id = _entityId }, ApplicationId);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.DataModels.{_entityId}", output);
        }

        [Fact]
        public void DeleteView_Template_NullParameter_Test()
        {
            var template = new DeleteTemplate(null, null);
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        [Fact]
        public void DetailsView_Template_Test()
        {
            var template = new DetailsTemplate(new EntityInfo() { Id = _entityId }, ApplicationId);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.DataModels.{_entityId}", output);
        }

        [Fact]
        public void DetailsView_Template_NullParameter_Test()
        {
            var template = new DetailsTemplate(null, null);
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        [Fact]
        public void EditView_Template_Test()
        {
            var template = new EditTemplate(new EntityInfo() { Id = _entityId }, ApplicationId);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.DataModels.{_entityId}", output);
        }

        [Fact]
        public void EditView_Template_NullParameter_Test()
        {
            var template = new EditTemplate(null, null);
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        [Fact]
        public void IndexView_Template_Test()
        {
            var template = new IndexTemplate(new EntityInfo() { Id = _entityId }, ApplicationId);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model IEnumerable<{ApplicationId}.Backend.DataModels.{_entityId}>", output);
        }

        [Fact]
        public void IndexView_Template_NullParameter_Test()
        {
            var template = new IndexTemplate(null, null);
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
