using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Migrations {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxWidgetMigrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("AjaxWidgetPartRecord", table => table
               .ContentPartRecord()
               .Column<int>("SelectedContentItemId")
               .Column<string>("DisplayType"));

            SchemaBuilder.CreateTable("AjaxifyPartRecord", table => table
                .ContentPartRecord()
                .Column<bool>("Ajaxify"));
            
            ContentDefinitionManager.AlterPartDefinition("AjaxWidgetPart", part => part
                .Attachable(false)
                .WithDescription("A widget used to load content and other widgets asynchronously via AJAX."));

            ContentDefinitionManager.AlterPartDefinition("AjaxifyPart", part => part
                .Attachable()
                .WithDescription("Turns an existing widget type into one that can be loaded asynchronously via AJAX."));

            ContentDefinitionManager.AlterTypeDefinition("AjaxWidget", type => type
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithPart("AjaxWidgetPart")
                .WithSetting("Stereotype", "Widget")
                .Creatable(false)
                .Draftable(false));

            return 1;
        }
    }
}