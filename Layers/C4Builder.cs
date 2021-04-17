using System;
using Structurizr;

namespace modelc4_project
{
    internal class C4Builder
    {
        private Workspace _workspace;
        private SoftwareSystem _currentSoftwareSystem;
        private Container _currentContainer;

        internal C4Builder(Workspace workspace)
        {
            _workspace = workspace;
        }

        internal C4Builder AddContainer(string containerName, string containerDescription, string containerTechnology, string tag = null) {
            var container = _currentSoftwareSystem.AddContainer(containerName, containerDescription, containerTechnology);
            if (!String.IsNullOrEmpty(tag)) {
                 container.AddTags(tag);
            }
            return this;
        }

        internal C4Builder AddComponent(string componentName, string componentDescription, string componentTechnology, string tag = null) {
            var component = _currentContainer.AddComponent(componentName, componentDescription, componentTechnology);

            if (!string.IsNullOrEmpty(tag)) {
                component.AddTags(tag);
            }
            return this;
        }

        internal C4Builder SelectContainer(string containerName) {
            _currentContainer = GetContainer(containerName);
            return this;
        }

        internal C4Builder SelectSoftwareSystem(string softwareSystemName) {
            _currentSoftwareSystem = GetSoftwareSystem(softwareSystemName);
            return this;
        }

        internal C4Builder ComponentUsesComponent(string sourceComponentName, string destinationComponentName, string description, string tag) {
            var sourceComponent = _currentContainer.GetComponentWithName(sourceComponentName);
            var destinationComponent = _currentContainer.GetComponentWithName(destinationComponentName);

            sourceComponent.Uses(destinationComponent, description).AddTags(tag);

            return this;
        }

        internal C4Builder ComponentUsesContainer(string componentName, string containerName, string description, string technology) {
            var component = _currentContainer.GetComponentWithName(componentName);
            var container = _currentSoftwareSystem.GetContainerWithName(containerName);

            component.Uses(container, description, technology);

            return this;
        }

        internal C4Builder SoftwareSystemUsesComponent(string softwareSytemName, string componentName, string desc, string technology) {
            var component = _currentContainer.GetComponentWithName(componentName);
            var softwareSystem = _workspace.Model.GetSoftwareSystemWithName(softwareSytemName);

            softwareSystem.Uses(component, desc, technology);

            return this;
        }

        internal C4Builder ComponentUsesSoftwareSystem(string componentName, string softwareSystemName, string description, string technology) {
            var component = _currentContainer.GetComponentWithName(componentName);
            var softwareSystem = _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);

            component.Uses(softwareSystem, description, technology);

            return this;
        }

        internal C4Builder AddPerson(string name, string desc) {
            _workspace.Model.AddPerson(name, desc);
            return this;
        }

        internal C4Builder AddSoftwareSystem(String name, String description, String tag = null) {
            var system =_workspace.Model.AddSoftwareSystem(name, description);
            if (!String.IsNullOrEmpty(tag)) {
                 system.AddTags(tag);
            }
           
            return this;
        }

        internal C4Builder PersonUses(string personName, string softwareSystemName, string description) {
            var person = _workspace.Model.GetPersonWithName(personName);
            var systemDestination = _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);
            person.Uses(systemDestination, description);
            return this;
        }

        internal C4Builder PersonUsesContainer(string personName, string containerName, string description) {
            var person = _workspace.Model.GetPersonWithName(personName);
            var container = _currentSoftwareSystem.GetContainerWithName(containerName);
            person.Uses(container, description);

            return this;
        }

        internal C4Builder SoftwareSystemUses(string sourceSoftwareSystemName, string destinationSoftwareSystemName, string description) {
            var sourceSystem = _workspace.Model.GetSoftwareSystemWithName(sourceSoftwareSystemName);
            var destinationSystem = _workspace.Model.GetSoftwareSystemWithName(destinationSoftwareSystemName);
            sourceSystem.Uses(destinationSystem, description);
            return this;
        }

        internal C4Builder SoftwareSystemUsesContainer(string softwareSystemName, string containerName, string description, string technology) {
            var container = _currentSoftwareSystem.GetContainerWithName(containerName);
            var softwareSystem = _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);

            softwareSystem.Uses(container, description, technology);

            return this;
        }

        internal C4Builder SoftwareSystemDelivers(string softwareSystemName, string personName, string description) {
            var softwareSystem = _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);
            var person = _workspace.Model.GetPersonWithName(personName);
            softwareSystem.Delivers(person, description);

            return this;
        }

        internal C4Builder ContainerUses(string sourceContainerName, string destinationContainerName, string description, string technology) {
            var sourceContainer = _currentSoftwareSystem.GetContainerWithName(sourceContainerName);
            var destinationContainer = _currentSoftwareSystem.GetContainerWithName(destinationContainerName);
            sourceContainer.Uses(destinationContainer, description, technology);
            return this;
        }

        internal C4Builder ContainerUsesSoftwareSystem(string containerName, string softwareSystemName, string description, string technology) {
            var container = _currentSoftwareSystem.GetContainerWithName(containerName);
            var softwareSystem = _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);

            container.Uses(softwareSystem, description, technology);

            return this;
        }

        internal C4Builder AddStyle(ElementStyle elementStyle) {
            _workspace.Views.Configuration.Styles.Add(elementStyle);
            return this;
        }

        internal SoftwareSystem GetSoftwareSystem(string softwareSystemName) {
            return _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);
        }

        internal Container GetContainer(string containerName) {
            return _currentSoftwareSystem.GetContainerWithName(containerName);
        }

        internal C4Builder ContainerUsesComponent(string containerName, string componentName, string description, string technology) {
            var container = _currentSoftwareSystem.GetContainerWithName(containerName);
            var component = _currentContainer.GetComponentWithName(componentName);

            container.Uses(component, description, technology);

            return this;
        }
        
        internal C4Builder AddStyle(RelationshipStyle relationshipStyle) {
            _workspace.Views.Configuration.Styles.Add(relationshipStyle);

            return this;
        }

        internal C4Builder BuildView() {
            return this;
        }
    }
}
