using System;
using Structurizr;

namespace modelc4_project.Layers
{
    internal class C2
    {
        private Workspace _workspace;
        private C4Builder _c2Builder;
        
        public C2(Workspace workspace) {
            _workspace = workspace;
            _c2Builder= new C4Builder(_workspace);

            var expirationPlatformSystem = _c2Builder
            .SelectSoftwareSystem("Expiration platform")
            .AddContainer("Expiration API", "Expiration platform core domain with endpints", "Spring Boot 2", Tags.Container)
            .AddContainer("Expiration Web Page", "ABC", "Angular 9","WebPage")
            .AddContainer("Web Admin Panel", "ABCC", "React", "WebPage")
            .AddContainer("Postgres Database", "Database expiration_db for whole application", "RDMBS", "Database")
            .ContainerUses("Expiration API", "Postgres Database", "Uses", "ORM")
            .ContainerUsesSoftwareSystem("Expiration API", "SMTP", "Send notification", "SMTP")
            .ContainerUsesSoftwareSystem("Expiration API", "System with recipes", "Request", "HTTP/GET REST")
            .SoftwareSystemUsesContainer("System with recipes", "Expiration API", "Response", "HTTP/GET REST")
            .PersonUsesContainer("User", "Expiration Web Page", "Managing products and notifications")
            .PersonUsesContainer("Admin", "Web Admin Panel", "Configuring platform")
            .ContainerUses("Expiration Web Page", "Expiration API", "Uses", "HTTPS/REST")
            .ContainerUses("Web Admin Panel", "Expiration API", "Uses", "HTTPS/REST")
            .AddStyle(new ElementStyle(Tags.Container) {
                FontSize = 30,
                Background = "#FB9D4B"
            })
            .AddStyle(new ElementStyle("Database") {
                Background = "#808080",
                Shape = Shape.Cylinder
            })
            .AddStyle(new ElementStyle("WebPage") {
                Shape = Shape.WebBrowser
            })
            .GetSoftwareSystem("Expiration platform");

            var contextView = _workspace.Views.CreateContainerView(expirationPlatformSystem, "Containers", "description");
            contextView.PaperSize = PaperSize.A3_Landscape;
            contextView.EnableAutomaticLayout(RankDirection.RightLeft, 500, 150, 150, true);
            contextView.AddAllPeople();
            contextView.AddAllSoftwareSystems();
            contextView.AddAllContainers();
            
        }
    }
}
