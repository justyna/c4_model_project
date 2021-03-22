using System;
using Structurizr;

namespace modelc4_project.Layers.C1
{
    internal class C1Builder
    {
        private Workspace _workspace;

        internal C1Builder(Workspace workspace)
        {
            _workspace = workspace;
        }

        internal C1Builder AddPerson(string name, string desc) {
            _workspace.Model.AddPerson(name, desc);
            return this;
        }

        internal C1Builder AddSoftwareSystem(String name, String description, String tag = null) {
            var system =_workspace.Model.AddSoftwareSystem(name, description);
            if (!String.IsNullOrEmpty(tag)) {
                 system.AddTags(tag);
            }
           
            return this;
        }

        internal C1Builder PersonUses(string personName, string softwareSystemName, string description) {
            var person = _workspace.Model.GetPersonWithName(personName);
            var systemDestination = _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);
            person.Uses(systemDestination, description);
            return this;
        }

        internal C1Builder SoftwareSystemUses(string sourceSoftwareSystemName, string destinationSoftwareSystemName, string description) {
            var sourceSystem = _workspace.Model.GetSoftwareSystemWithName(sourceSoftwareSystemName);
            var destinationSystem = _workspace.Model.GetSoftwareSystemWithName(destinationSoftwareSystemName);
            sourceSystem.Uses(destinationSystem, description);
            return this;
        }

        internal C1Builder SoftwareSystemDelivers(string softwareSystemName, string personName, string description) {
            var softwareSystem = _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);
            var person = _workspace.Model.GetPersonWithName(personName);
            softwareSystem.Delivers(person, description);

            return this;
        }

        internal C1Builder AddStyle(ElementStyle elementStyle) {
            _workspace.Views.Configuration.Styles.Add(elementStyle);
            return this;
        }

        internal SoftwareSystem GetSoftwareSystem(string softwareSystemName) {
            return _workspace.Model.GetSoftwareSystemWithName(softwareSystemName);
        }

        internal C1Builder BuildView() {
            return this;
        }
    }
}
