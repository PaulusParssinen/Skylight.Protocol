﻿using System.Buffers;
using Skylight.Protocol.Extensions;
using Skylight.Protocol.Packets.Incoming.Room.Engine;
using Net.Buffers;
using Net.Communication.Attributes;
using Net.Communication.Incoming.Parser;

namespace Skylight.Protocol.WIN63_202111081545_75921380.Packets.Parsers.Room.Engine;

[PacketParserId(2735u)]
[PacketManagerRegister(typeof(GamePacketManager))]
internal sealed class PlaceObjectPacketParser : IIncomingPacketParser<PlaceObjectPacketParser.PlaceObjectIncomingPacket>
{
	public PlaceObjectIncomingPacket Parse(ref PacketReader reader)
	{
		return new PlaceObjectIncomingPacket
		{
			Values = reader.ReadBytes(reader.ReadInt16())
		};
	}

	internal readonly struct PlaceObjectIncomingPacket : IPlaceObjectIncomingPacket
	{
		public ReadOnlySequence<byte> Values { get; init; }
	}
}
