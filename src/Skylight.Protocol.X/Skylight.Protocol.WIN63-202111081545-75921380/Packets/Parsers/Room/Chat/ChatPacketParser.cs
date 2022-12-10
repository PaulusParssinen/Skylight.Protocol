﻿using System.Buffers;
using Skylight.Protocol.Extensions;
using Skylight.Protocol.Packets.Incoming.Room.Chat;
using Net.Buffers;
using Net.Communication.Attributes;
using Net.Communication.Incoming.Parser;

namespace Skylight.Protocol.WIN63_202111081545_75921380.Packets.Parsers.Room.Chat;

[PacketParserId(3544u)]
[PacketManagerRegister(typeof(GamePacketManager))]
internal sealed class ChatPacketParser : IIncomingPacketParser<ChatPacketParser.ChatIncomingPacket>
{
	public ChatIncomingPacket Parse(ref PacketReader reader)
	{
		return new ChatIncomingPacket
		{
			Text = reader.ReadBytes(reader.ReadInt16()),
			StyleId = reader.ReadInt32(),
			TrackingId = reader.ReadInt32()
		};
	}

	internal readonly struct ChatIncomingPacket : IChatIncomingPacket
	{
		public ReadOnlySequence<byte> Text { get; init; }
		public int StyleId { get; init; }
		public int TrackingId { get; init; }
	}
}
