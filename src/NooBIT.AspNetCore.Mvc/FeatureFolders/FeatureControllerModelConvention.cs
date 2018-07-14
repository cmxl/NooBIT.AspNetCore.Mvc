using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace NooBIT.AspNetCore.Mvc.FeatureFolders
{
    public class FeatureControllerModelConvention : IControllerModelConvention
    {
        private readonly string _folderName;
        private readonly Func<ControllerModel, string> _nameDerivationStrategy;

        public FeatureControllerModelConvention(FeatureFolderOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _folderName = options.FeatureFolderName;
            _nameDerivationStrategy = options.DeriveFeatureFolderName ?? DeriveFeatureFolderName;
        }

        public void Apply(ControllerModel controllerModel)
        {
            if (controllerModel == null)
                throw new ArgumentNullException(nameof(controllerModel));

            var featureName = _nameDerivationStrategy(controllerModel);
            controllerModel.Properties.Add("feature", featureName);
        }

        private string DeriveFeatureFolderName(ControllerModel controllerModel)
        {
            var @namespace = controllerModel.ControllerType.Namespace;
            var result = @namespace.Split('.')
                .SkipWhile(s => s != _folderName)
                .Aggregate("", Path.Combine);

            return result;
        }
    }
}