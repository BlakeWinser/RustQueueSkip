Simple Queue Skip plugin to allow players with specific permissions to jump ahead of the queue.

# Configuration

To grant a specific player the queueskip:
```
oxide.grant user <steamid> queueskip.vip
```

To create a new Oxide group (for VIP player for example):
```
oxide.group add vip
```

To add a player to a group:
```
oxide.usergroup add <steamid> vip
```

To grant permissions to an entire group:
```
oxide.grant group vip queueskip.vip
```

To remove a player from a group:
```
oxide.usergroup remove <player_name_or_id> vip
```

To remove the entire permission from a group:
```
oxide.revoke group vip queueskip.vip
```
