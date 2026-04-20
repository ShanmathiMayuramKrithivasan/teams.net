using System.Text.Json;

using Microsoft.Teams.Api.Entities;

namespace Microsoft.Teams.Api.Tests.Entities;

public class TargetedMessageInfoEntityTests
{
    [Fact]
    public void TargetedMessageInfoEntity_JsonSerialize()
    {
        var entity = new TargetedMessageInfoEntity()
        {
            MessageId = "1772129782775"
        };

        var json = JsonSerializer.Serialize(entity, new JsonSerializerOptions()
        {
            WriteIndented = true,
            IndentSize = 2,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });

        Assert.Equal(File.ReadAllText(
            @"../../../Json/Entities/TargetedMessageInfoEntity.json"
        ), json);
    }

    [Fact]
    public void TargetedMessageInfoEntity_JsonSerialize_Derived()
    {
        Entity entity = new TargetedMessageInfoEntity()
        {
            MessageId = "1772129782775"
        };

        var json = JsonSerializer.Serialize(entity, new JsonSerializerOptions()
        {
            WriteIndented = true,
            IndentSize = 2,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });

        Assert.Equal(File.ReadAllText(
            @"../../../Json/Entities/TargetedMessageInfoEntity.json"
        ), json);
    }

    [Fact]
    public void TargetedMessageInfoEntity_JsonDeserialize()
    {
        var json = File.ReadAllText(@"../../../Json/Entities/TargetedMessageInfoEntity.json");
        var entity = JsonSerializer.Deserialize<TargetedMessageInfoEntity>(json);

        Assert.NotNull(entity);
        Assert.Equal("targetedMessageInfo", entity.Type);
        Assert.Equal("1772129782775", entity.MessageId);
    }

    [Fact]
    public void TargetedMessageInfoEntity_JsonDeserialize_Derived()
    {
        var json = File.ReadAllText(@"../../../Json/Entities/TargetedMessageInfoEntity.json");
        var entity = JsonSerializer.Deserialize<Entity>(json);

        Assert.NotNull(entity);
        Assert.IsType<TargetedMessageInfoEntity>(entity);

        var targeted = (TargetedMessageInfoEntity)entity;
        Assert.Equal("targetedMessageInfo", targeted.Type);
        Assert.Equal("1772129782775", targeted.MessageId);
    }
}
