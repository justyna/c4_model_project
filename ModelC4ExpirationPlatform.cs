using System;
using modelc4_project.Layers.C1;
using Structurizr;
using Structurizr.Api;

namespace modelc4_project
{
    internal class ModelC4ExpirationPlatform
    {
        private ModelC4Config _config;
        private Workspace _workspace;

        public ModelC4ExpirationPlatform(ModelC4Config config)
        {
            _config = config;
            _workspace = new Workspace("Waste minimalisation system", "Add products to be inform before the expiration date");
            new C1(_workspace);
        }
        public void Publish() 
        {
            var structurizrClient = new StructurizrClient(
                _config.ApiKey,
                _config.ApiSecret);
            
            structurizrClient.PutWorkspace(_config.WorkspaceId, _workspace);
        }

    }
}