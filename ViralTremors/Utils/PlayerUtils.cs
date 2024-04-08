using System.Linq;
using Photon.Pun;

namespace ViralTremors.Utils;

public static class PlayerUtils
{
    public static Photon.Realtime.Player? GetPlayerWithCamera()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (!GlobalPlayerData.TryGetPlayerData(player, out var globalPlayerData)) continue;

            if (globalPlayerData.inventory.GetItems().Any(item => item.item.name == "Camera"))
            {
                return player;
            }
        }

        return null;
    }
}