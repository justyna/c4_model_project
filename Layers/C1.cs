using System;
using Structurizr;

namespace modelc4_project
{
    internal class C1
    {
        private Workspace _workspace;
        private C4Builder _c1Builder;

        public C1(Workspace workspace) {
            _workspace = workspace;
            _c1Builder = new C4Builder(_workspace);

            var expirationPlatformSystem = _c1Builder
            .SelectSoftwareSystem("Expiration platform")
            .AddPerson("User", "Using platform")
            .AddPerson("Admin", "Configuring platform")
            .AddSoftwareSystem("Expiration platform", "Inform user about product expiration")
            .AddSoftwareSystem("SMTP", "Send emails", "External")
            .AddSoftwareSystem("System with recipes", "Provide recipes", "External")
            .PersonUses("User","Expiration platform", "Provide products with expiration dates")
            .PersonUses("Admin", "Expiration platform", "Configures platform")
            .SoftwareSystemUses("Expiration platform", "System with recipes", "Request Recipe" )
            .SoftwareSystemUses("Expiration platform", "SMTP", "Send emails" )
            .SoftwareSystemUses("System with recipes", "Expiration platform", "Response Recipe")
            .SoftwareSystemDelivers("SMTP", "User", "Send email")
            .AddStyle(new ElementStyle(Tags.SoftwareSystem) {
                 Color = "#000000"
            })
            .AddStyle(new ElementStyle(Tags.Person) {
                Background = "#ffff00",
                    Color = "#000000",
                    Shape = Shape.Person,
                    FontSize = 34
            })
            .AddStyle(new ElementStyle("External") {
                Background = "#00FFFF",
                    Shape = Shape.Box,
                    FontSize = 26
            }).GetSoftwareSystem("Expiration platform");

            var contextView = _workspace.Views.CreateSystemContextView(expirationPlatformSystem, "Expiration Platform", "description");
            contextView.PaperSize = PaperSize.A4_Landscape;
            contextView.EnableAutomaticLayout(RankDirection.RightLeft, 300, 50, 50, true);
            contextView.AddAllPeople();
            contextView.AddAllSoftwareSystems();
        }
    }
}
