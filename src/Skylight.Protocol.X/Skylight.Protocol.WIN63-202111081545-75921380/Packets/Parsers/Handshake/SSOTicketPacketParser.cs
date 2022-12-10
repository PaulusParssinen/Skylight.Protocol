﻿using System.Buffers;
using Skylight.Protocol.Extensions;
using Skylight.Protocol.Packets.Incoming.Handshake;
using Net.Buffers;
using Net.Communication.Attributes;
using Net.Communication.Incoming.Parser;

namespace Skylight.Protocol.WIN63_202111081545_75921380.Packets.Parsers.Handshake;

[PacketParserId(2616u)]
[PacketManagerRegister(typeof(GamePacketManager))]
internal sealed class SSOTicketPacketParser : IIncomingPacketParser<SSOTicketPacketParser.SSOTicketIncomingPacket>
{
	public SSOTicketIncomingPacket Parse(ref PacketReader reader)
	{
		return new SSOTicketIncomingPacket
		{
			SSOTicket = reader.ReadBytes(reader.ReadInt16()),
			Time = reader.ReadInt32()
		};
	}

	internal readonly struct SSOTicketIncomingPacket : ISSOTicketIncomingPacket
	{
		public ReadOnlySequence<byte> SSOTicket { get; init; }
		public int Time { get; init; }
	}
}
