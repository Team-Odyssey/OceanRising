using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSpawnCube : NetworkRequest
{
	public RequestSpawnCube()
	{
		request_id = Constants.CMSG_SPAWNCUBE;
	}

	public void send(float x, float y)
	{
		packet = new GamePacket(request_id);
		packet.addFloat32(x);
		packet.addFloat32(y);
	}
}
