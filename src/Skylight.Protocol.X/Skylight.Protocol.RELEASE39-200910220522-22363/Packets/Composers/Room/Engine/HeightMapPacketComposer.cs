﻿using System.Globalization;
using Skylight.Protocol.Extensions;
using Skylight.Protocol.Packets.Outgoing.Room.Engine;
using Net.Buffers;
using Net.Communication.Attributes;
using Net.Communication.Outgoing;

namespace Skylight.Protocol.RELEASE39_200910220522_22363.Packets.Composers.Room.Engine;

[PacketComposerId(31u)]
[PacketManagerRegister(typeof(GamePacketManager))]
internal sealed class HeightMapPacketComposer : IOutgoingPacketComposer<HeightMapOutgoingPacket>
{
	public void Compose(ref PacketWriter writer, in HeightMapOutgoingPacket packet)
	{
		writer.WriteText(string.Join('\r', packet.HeightMap.Select(i => (byte)('0' + i)).Chunk((int)packet.Width).Select(c => System.Text.Encoding.UTF8.GetString(c))));
	}
}
