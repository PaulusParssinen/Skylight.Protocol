﻿using Skylight.Protocol.Attributes;

namespace Skylight.Protocol.Packets.Incoming.Recycler;

[RemovedOn("WIN63-202111081545-75921380")]
public interface IRecycleItemsIncomingPacket : IGameIncomingPacket
{
	public IList<int> StripIds { get; }
}
