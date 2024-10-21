using Oxide.Core.Plugins;
using Network;

namespace Oxide.Plugins
{
    [Info("QueueSkip", "Blake Winser", "1.0.0")]
    [Description("A plugin that allows VIP players to skip the queue.")]
    public class QueueSkip : RustPlugin
    {
        private const string QueueSkipPermission = "queueskip.vip";

        // Called when the plugin is loaded
        private void Init()
        {
            permission.RegisterPermission(QueueSkipPermission, this);
        }

        // Hook for queue skipping
        private object CanBypassQueue(Connection connection)
        {
            string userId = connection.userid.ToString();

            if (permission.UserHasPermission(userId, QueueSkipPermission))
            {
                Puts($"{connection.username} has VIP, skipping the queue.");
                return true; // Allow VIP player to skip the queue
            }

            return null; // Proceed with the default queue behavior for non-VIP players
        }

        // Hook called when player disconnects
        private void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            // Log the disconnection event
            Puts($"Player {player.displayName} has disconnected. Reason: {reason}");
        }

        // Hook called when player connects
        private void OnPlayerConnected(BasePlayer player)
        {
            // Check if the player is a VIP and notify them
            if (permission.UserHasPermission(player.UserIDString, QueueSkipPermission))
            {
                PrintToChat(player, $"Welcome back, {player.displayName}!");

                // Log VIP player connecting
                Puts($"VIP Player {player.displayName} has connected.");
            }
            else
            {
                PrintToChat(player, "Welcome to the server! Enjoy your stay.");

                // Log standard player connecting
                Puts($"Player {player.displayName} has connected.");
            }
        }
    }
}