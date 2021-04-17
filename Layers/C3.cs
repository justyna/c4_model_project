using System;
using Structurizr;

namespace modelc4_project.Layers
{
    public class C3
    {
        private Workspace _workspace;
        private C4Builder _c3Builder;
        public C3(Workspace workspace) {
            _workspace = workspace;
            _c3Builder = new C4Builder(_workspace);
            var expirationPlatformAPIContainer = _c3Builder
            .SelectSoftwareSystem("Expiration platform")
            .SelectContainer("Expiration API")
            .AddComponent("Product Controller", "Handle product requests", "Spring Boot 2", "Controller")
            .AddComponent("Notification Controller", "Handle notification requests", "Spring Boot 2", "Controller")
            .AddComponent("Notyfication Job", "Trigger notification sending", "Job")
            .AddComponent("Product", "Handles product logic. Uses: Database Prostgres Container to read/write [ORM].", "Service")
            .AddComponent("Notification", "Process and send notification.", "Service")
            .ContainerUsesComponent("Expiration Web Page", "Product Controller", "Uses", "[HTTPS/REST]")
            .ContainerUsesComponent("Expiration Web Page", "Notification Controller", "Uses", "[HTTPS/REST]")
            .ContainerUsesComponent("Web Admin Panel", "Product Controller", "Uses", "[HTTPS/REST]")
            .ContainerUsesComponent("Web Admin Panel", "Notification Controller", "Uses", "[HTTPS/REST]") 
            .ComponentUsesComponent("Product Controller", "Product", "Uses", "Internal")
            .ComponentUsesComponent("Notification Controller", "Notification", "Uses", "Internal")
            .ComponentUsesContainer("Product", "Postgres Database", "Read/write from", "[DB/ORM]")
            .ComponentUsesContainer("Notification", "Postgres Database", "Read/write from", "[DB/ORM]")
            .ComponentUsesSoftwareSystem("Notification", "System with recipes", "Request", "[HTTPS/POST REST]")
            .SoftwareSystemUsesComponent("System with recipes", "Notification", "Response", "[HTTPS/POST REST]")
            .ComponentUsesSoftwareSystem("Notification", "SMTP", "Send emails", "[SMTP]")

            .AddStyle(new ElementStyle(Tags.Component) {
                    Background = "#FB9D4B",
                        Shape = Shape.Component
                })
                .AddStyle(new ElementStyle("Controller") {
                    Shape = Shape.Component
                })
                .AddStyle(new RelationshipStyle(Tags.Relationship) {
                    Routing = Routing.Curved
                })
                .AddStyle(new RelationshipStyle("Internal") {
                    Dashed = false,
                        Color = "#8FD14F",
                        Routing = Routing.Curved
                })
                .GetContainer("Expiration API");

            var componentView = workspace.Views.CreateComponentView(expirationPlatformAPIContainer, "Components", null);
            componentView.PaperSize = PaperSize.A2_Landscape;
            componentView.EnableAutomaticLayout(RankDirection.LeftRight, 300, 100, 100, true);
            componentView.AddAllElements();
        }
    }
}
