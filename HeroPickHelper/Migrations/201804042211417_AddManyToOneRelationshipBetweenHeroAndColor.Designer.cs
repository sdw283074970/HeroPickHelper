// <auto-generated />
namespace HeroPickHelper.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddManyToOneRelationshipBetweenHeroAndColor : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddManyToOneRelationshipBetweenHeroAndColor));
        
        string IMigrationMetadata.Id
        {
            get { return "201804042211417_AddManyToOneRelationshipBetweenHeroAndColor"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
