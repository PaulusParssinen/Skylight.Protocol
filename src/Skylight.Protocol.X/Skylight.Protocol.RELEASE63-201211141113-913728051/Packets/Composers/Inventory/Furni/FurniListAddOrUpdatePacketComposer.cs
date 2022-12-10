﻿using System.Globalization;
using Skylight.Protocol.Extensions;
using Skylight.Protocol.Packets.Outgoing.Inventory.Furni;
using Net.Buffers;
using Net.Communication.Attributes;
using Net.Communication.Outgoing;

namespace Skylight.Protocol.RELEASE63_201211141113_913728051.Packets.Composers.Inventory.Furni;

[PacketComposerId(1102u)]
[PacketManagerRegister(typeof(GamePacketManager))]
internal sealed class FurniListAddOrUpdatePacketComposer : IOutgoingPacketComposer<FurniListAddOrUpdateOutgoingPacket>
{
	public void Compose(ref PacketWriter writer, in FurniListAddOrUpdateOutgoingPacket packet)
	{
		foreach (var furni in packet.Furni)
		{
			writer.WriteInt32(furni.StripId);
			if (furni.Type is Skylight.Protocol.Packets.Data.Room.Object.FurnitureType.Floor)
			{
				writer.WriteFixedUInt16String("S");
			}
			else if (furni.Type is Skylight.Protocol.Packets.Data.Room.Object.FurnitureType.Wall)
			{
				writer.WriteFixedUInt16String("I");
			}
			else
			{
				throw new NotSupportedException();
			}
			writer.WriteInt32(furni.ItemId);
			writer.WriteInt32(furni.FurnitureId);
			writer.WriteInt32(furni.Category);
			if (furni.ExtraData is Skylight.Protocol.Packets.Data.Room.Object.Data.EmptyItemData emptyItemData)
			{
				writer.WriteInt32(4);
			}
			else if (furni.ExtraData is Skylight.Protocol.Packets.Data.Room.Object.Data.Wall.PostItInventoryData postItInventoryData)
			{
				writer.WriteInt32(0);
				writer.WriteFixedUInt16String(postItInventoryData.Count.ToString());
			}
			else if (furni.ExtraData is Skylight.Protocol.Packets.Data.Room.Object.Data.Wall.PostItRoomData postItRoomData)
			{
				writer.WriteFixedUInt16String($"{postItRoomData.Color.ToArgb():X6}{" "}{postItRoomData.Text}".ToString());
			}
			else
			{
				throw new NotSupportedException();
			}
			writer.WriteBool(true);
			writer.WriteBool(true);
			writer.WriteBool(true);
			writer.WriteBool(true);
			writer.WriteInt32(-1);
			if (furni.Type == Skylight.Protocol.Packets.Data.Room.Object.FurnitureType.Floor)
			{
				writer.WriteFixedUInt16String("");
			}
			if (furni.Type == Skylight.Protocol.Packets.Data.Room.Object.FurnitureType.Floor)
			{
				writer.WriteInt32(0);
			}
		}
	}
}
