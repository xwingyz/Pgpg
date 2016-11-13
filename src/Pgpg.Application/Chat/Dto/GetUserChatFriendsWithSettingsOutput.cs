using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using Pgpg.Application.Friendships.Dto;

namespace Pgpg.Application.Chat.Dto
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }
        
        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}